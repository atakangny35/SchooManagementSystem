using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OkulYönetim.Constances;
using OkulYönetim.Costum_Tools.Validation;
using OkulYönetim.Costum_Tools.Validation.Rules;
using OkulYönetim.Entity.concrete;
using OkulYönetim.Entity.concrete.Dto.UserRole;
using OkulYönetim.Entity.EntityFramework.interfaces;

namespace OkulYönetim.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserRoleController : ControllerBase
    {
        private readonly IUserRoleRepository userRoleRepository;

        public UserRoleController(IUserRoleRepository _userRoleRepository)
        {
            userRoleRepository = _userRoleRepository;
        }

        [HttpPost]
        [Authorize(Roles = Constance.AdministratorOrUser)]
        public async Task<IActionResult> Add(UserRoleAddMOdel userRoleAddMOdel)
        {
            if (userRoleAddMOdel == null) return BadRequest("Parametlre gönderilmedi");



            UserRole model = new UserRole { RoleName = userRoleAddMOdel.RoleName, IsActive = true };

            var result = ValidationTool.Validate(model, new UserRoleValidator());

            if (result.Count == 0)
            {
                await userRoleRepository.add(model);

                return Ok("işlem başarılı");
            }
            return BadRequest(result);

        }
        [HttpDelete]
        [Authorize(Roles = Constance.AdministratorOrUser)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await userRoleRepository.Get(id);
            if (result is null) return BadRequest(Constances.Constance.UserRoleNotFOund);
            if (await userRoleRepository.CheckRoleHasUsers(id) > 0) return BadRequest(result.RoleName + " Kullanıcı tipi İçin Tanımlı kullanıcılar var silinemez");
            await userRoleRepository.Delete(result);
            return Ok(Constances.Constance.EntityDeleted);
        }
        [HttpPut("DeleteSoft")]
        [Authorize(Roles = Constance.AdministratorOrUser)]
        public async Task<IActionResult> DeleteSoft(int id)
        {
            var result = await userRoleRepository.Get(id);
            if (result is null) return BadRequest(Constances.Constance.UserRoleNotFOund);
            if (await userRoleRepository.CheckRoleHasUsers(id) > 0) return BadRequest(result.RoleName + " Kullanıcı tipi İçin Tanımlı kullanıcılar var silinemez");
            result.IsActive = false;
            await userRoleRepository.Update(result);
            return Ok(Constances.Constance.EntityDeleted);
        }
        [HttpPut]
        [Authorize(Roles = Constance.AdministratorOrUser)]
        public async Task<IActionResult> Update(UserRoleUpdateModel model)
        {
            var UserRoleresult = await userRoleRepository.Get(model.Id);
            if (UserRoleresult is null) return BadRequest(Constance.UserRoleNotFOund);

            UserRoleresult.RoleName = model.RoleName;
            var result = ValidationTool.Validate(UserRoleresult, new UserRoleValidator());

            if (result.Count == 0)
            {
                await userRoleRepository.Update(UserRoleresult);
                return Ok(Constances.Constance.EntityUpdated);
            }
            return BadRequest(result);

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var UserRoleresult = await userRoleRepository.Get(id);
            if (UserRoleresult is null) return BadRequest(Constance.UserRoleNotFOund);

            return Ok(UserRoleresult);



        }

        [HttpGet("GetAll")]
        [Authorize(Roles = Constance.AdministratorOrUser)]
        public async Task<IActionResult> GetAll()
        {
            var UserRoleresult = await userRoleRepository.exp(i => i.IsActive == true);
            return Ok(UserRoleresult);
        }

    }
}
