using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OkulYönetim.Constances;
using OkulYönetim.Costum_Tools.Validation;
using OkulYönetim.Costum_Tools.Validation.Rules;
using OkulYönetim.Entity.concrete;
using OkulYönetim.Entity.concrete.Dto.User;
using OkulYönetim.Entity.EntityFramework.interfaces;
using OkulYönetim.Utilities;

namespace OkulYönetim.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private IUserRepository userRepository;
        private IUserClassRepository userClassRepository;
        private IUserDersRepository userDersRepository;

        public UserController(IUserRepository _userRepository, IUserClassRepository userClassRepository, IUserDersRepository userDersRepository)
        {
            userRepository = _userRepository;
            this.userClassRepository = userClassRepository;
            this.userDersRepository = userDersRepository;
        }

        [HttpPost]
        [Authorize(Roles = Constance.AdministratorOrUser)]
        public async Task<IActionResult> Add(UserAddModel userAddModel)
        {
           
            
            var result = ValidationTool.Validate(userAddModel, new UserAddValidator());
            if (result.Count > 0)
            {
                return BadRequest(result);
            }
            HashingHelper.CreatePasswordHash(userAddModel.Password, out byte[] salt, out byte[] Hash);

            User user = new User
            {
                Branch = userAddModel.Branch,
                Surname = userAddModel.Surname,
                // UserDersId = userAddModel.UserDersId,
                Email = userAddModel.Email,
                Name = userAddModel.Name,
                PasswordHash = Hash,
                PasswordSalt = salt,
                UserRoleId = userAddModel.UserRoleId,
                //UserClassId = userAddModel.UserClassId
            };
            await userRepository.add(user);
            
            var checkedUser= await userRepository.FindByMail(user.Email);
            if (userAddModel.Branch == "") { userAddModel.Branch = null; }//Daha uygun bir yol arayaacağım!!
            if (checkedUser is not null && userAddModel.Branch is null)
            {   
                
                UserDers userDers = new UserDers
                {
                    Dersid = (int)userAddModel.DersId,
                    Userid = user.Id,

                };
               await  userDersRepository.add(userDers);

                UserClass userClass = new UserClass
                {
                    ClassId = (int)userAddModel.ClassId,
                    UserId = checkedUser.Id
                };
                await userClassRepository.add(userClass);
            }

            return Ok(Constances.Constance.AddedCompany);


        }

        [HttpGet("GetUser")]
        public async Task<IActionResult> Get(string userMail)
        {  
          var result=await userRepository.FindByMailWithRoleName(userMail);
          return result is not null ? Ok(result) : BadRequest(Constance.UserNotFOund);
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Update(UserUpdateModel userUpdateModel)
        {


            var result = ValidationTool.Validate(userUpdateModel, new UserUpdateValidator());
            if (result.Count > 0)
            {
                return BadRequest(result);
            }
            HashingHelper.CreatePasswordHash(userUpdateModel.Password, out byte[] salt, out byte[] Hash);
           var user= await userRepository.Get(userUpdateModel.UserId);


            user.Branch = userUpdateModel.Branch;
            user.Surname = userUpdateModel.Surname;
           // user.de = userUpdateModel.DersId,
            user.Email = userUpdateModel.Email;
            user.Name = userUpdateModel.Name;
            user.PasswordHash = Hash;
            user.PasswordSalt = salt;
            //UserRoleId = userUpdateModel.UserRoleId,
            //user.UserClassId = userAddModel.UserClassId;            
            await userRepository.Update(user);
            return Ok(Constance.AddedCompany);


        }

        [HttpPost("SetUserDers")]
        [AllowAnonymous]
        public async Task<IActionResult> SetUserDers(UserDersSetModel model)
        {
            var result =ValidationTool.Validate(model, new UserDersSetValidator());
            if (result.Count > 0)
            {
                return BadRequest(result);
            }
            if(await userDersRepository.HasUserDers(model.UserId, model.DersId))
            {
                return BadRequest(Constance.UserAlreadyHasDers);
            }
            UserDers userDers = new UserDers
            {
                Userid = model.UserId,
                Dersid=model.DersId,                
            };
            await userDersRepository.add(userDers);
            return Ok(Constance.AddedCompany);
        }
    }
}