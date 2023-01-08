using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OkulYönetim.Constances;
using OkulYönetim.Costum_Tools.Validation;
using OkulYönetim.Costum_Tools.Validation.Rules;
using OkulYönetim.Entity.concrete;
using OkulYönetim.Entity.concrete.Dto.Ders;
using OkulYönetim.Entity.EntityFramework.interfaces;

namespace OkulYönetim.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class DersController : ControllerBase
    {
        private readonly IDersRepository dersRepository;

        public DersController(IDersRepository dersRepository)
        {
            this.dersRepository = dersRepository;
        }


        [HttpPost]
        [Authorize(Roles = Constance.AdministratorOrUser)]
        public async Task<IActionResult> Add( string DersAdi)
        {
            if (DersAdi == null) return BadRequest("Parametlre gönderilmedi");



            Ders model = new Ders { DersAdi=DersAdi };
            var result = ValidationTool.Validate(model, new DersValidator());

            if (result.Count > 0) return BadRequest(result);
            


                await dersRepository.add(model);

                return Ok("işlem başarılı");
            


        }
        [HttpDelete]
        [Authorize(Roles = Constance.AdministratorOrUser)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await dersRepository.Get(id);
            if (result is null) return NotFound(Constance.DersNotFOundCont);
            if (await dersRepository.CheckDersHasUsers(id) > 0) return BadRequest(result.DersAdi + " Dersi İçin Tanımlı kullanıcılar var silinemez");
            await dersRepository.Delete(result);
            return Ok(Constance.EntityDeleted);
        }      
        [HttpPut]
        [Authorize(Roles = Constance.AdministratorOrUser)]
        public async Task<IActionResult> Update(DersUpdateModel model)
        {
            var Dersresult = await dersRepository.Get(model.Id);
            if (Dersresult is null) return NotFound(Constance.DersNotFOundCont);

            Dersresult.DersAdi = model.DersAdi;
            var result = ValidationTool.Validate(Dersresult, new DersValidator());

            if (result.Count == 0)
            {
                await dersRepository.Update(Dersresult);
                return Ok(Constance.EntityUpdated);
            }
            return BadRequest(result);

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var Dersresult = await dersRepository.Get(id);
            if (Dersresult is null) return NotFound(Constance.DersNotFOundCont);

            return Ok(Dersresult);



        }

        [HttpGet("GetAll")]
        [Authorize(Roles = Constance.AdministratorOrUser)]
        public async Task<IActionResult> GetAll()
        {
            var Dersresult = await dersRepository.GetAll();
            return Ok(Dersresult);
        }
    }
}
