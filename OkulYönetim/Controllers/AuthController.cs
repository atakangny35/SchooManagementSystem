using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OkulYönetim.Costum_Tools.RabbitMQ;
using OkulYönetim.Costum_Tools.Validation;
using OkulYönetim.Costum_Tools.Validation.Rules;
using OkulYönetim.Entity.concrete.Dto.Login;
using OkulYönetim.Entity.EntityFramework.interfaces;
using OkulYönetim.Utilities;
using OkulYönetim.Utilities.JWT.Abstract;

namespace OkulYönetim.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IUserRepository userRepository;
        private IJwtHelper jwtHelper;
        private IUserRoleRepository userRole;
        private RabbitMQRepository RabbitMQRepository;

        public AuthController(IUserRepository _userRepository, IJwtHelper _jwtHelper, IUserRoleRepository userRole, RabbitMQRepository rabbitMQRepository)
        {
            userRepository = _userRepository;
            jwtHelper = _jwtHelper;
            this.userRole = userRole;
            RabbitMQRepository = rabbitMQRepository;
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginModelController model)
        {
            var result = ValidationTool.Validate(model, new UserLoginModelValidator());
            if (result.Count > 0)
            {
                return BadRequest(result);
            }
            var User = await userRepository.FindByMail(model.Email);
            if (User is null) return Unauthorized("Email  veya şifre yanlış");
            if (User.PasswordHash is not null && User.PasswordSalt is not null)
            {
                if (HashingHelper.VerifyPasswordHash(model.Password, User.PasswordHash, User.PasswordSalt))
                {
                  var Role= await userRole.Get(User.UserRoleId);

                    var userlogin = new UserLoginModel
                    {
                        Email = model.Email,
                        Role = Role.RoleName,
                        Id = User.Id
                    };
                    var token = jwtHelper.GenerateJwtToken(userlogin);

                    return Ok(token);
                }
                
            }
            return Unauthorized("Email  veya şifre yanlış");
        }

       
    }
}
