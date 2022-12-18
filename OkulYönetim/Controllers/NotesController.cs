using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OkulYönetim.Constances;
using OkulYönetim.Costum_Tools.Validation;
using OkulYönetim.Costum_Tools.Validation.Rules;
using OkulYönetim.Entity.concrete;
using OkulYönetim.Entity.concrete.Dto.Note;
using OkulYönetim.Entity.EntityFramework.interfaces;

namespace OkulYönetim.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly INoteRepository noteRepository;
        private readonly IDersRepository  dersRepository;
        public NotesController(INoteRepository _noteRepository, IDersRepository _dersRepository)
        {
            noteRepository = _noteRepository;
            dersRepository = _dersRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var Noteresult = await noteRepository.Get(id);
            if (Noteresult is null) return BadRequest(Constance.NoteNotFOund);

            return Ok(Noteresult);



        }

        [HttpGet("GetAll")]
        [Authorize(Roles = Constance.AdministratorOrUser)]
        public async Task<IActionResult> GetAll()
        {
            var UserRoleresult = await noteRepository.GetAll();
            return Ok(UserRoleresult);
        }

        [HttpPost]
        [Authorize(Roles = Constance.AdministratorOrUser)]
        public async Task<IActionResult> Add(NoteAddModel  noteAddModel)
        {
            if (noteAddModel == null) return BadRequest("Parametlre gönderilmedi");

            var result = ValidationTool.Validate(noteAddModel, new NoteAddModelValidator());

            Note model = new Note
            {
                DersID = noteAddModel.DersID,
                UserId = noteAddModel.UserId,
                NoteValue = noteAddModel.NoteValue,
                AddedTime = DateTime.Now,
                Description= noteAddModel.Description
            };

            

            if (result.Count == 0)
            {
                await noteRepository.add(model);

                return Ok("işlem başarılı");
            }
            return BadRequest(result);

        }
        [HttpPut]
        [Authorize(Roles = Constance.AdministratorOrUser)]
        public async Task<IActionResult> Update(Note note)
        {
            if (note == null) return BadRequest("Parametlre gönderilmedi");
            var result = ValidationTool.Validate(note, new NoteUpdateValidator());

            if (result.Count == 0)
            {
                var Noteresult = await  noteRepository.Get(note.Id);
                Noteresult.NoteValue = note.NoteValue;
                Noteresult.DersID = note.DersID;
                Noteresult.Description = note.Description;
                Noteresult.UserId = note.UserId;

                await noteRepository.Update(Noteresult);

            return Ok("işlem başarılı");
            }
            return BadRequest(result);
        }
        [HttpGet("GetClassRate")]
        [Authorize(Roles = Constance.AdministratorOrUser)]
        public async Task<IActionResult> GetClassRate(int? DersId,int ClassId)
        {
            var rsesult = await noteRepository.GetClassRate(DersId, ClassId);
            return Ok(rsesult);
        }
        [HttpGet("GetUserRate")]
        public async Task<IActionResult> GetUserRate(int? DersId, int userid)
        {
            var rsesult = await noteRepository.GetUserRate(DersId, userid);
            return Ok(rsesult);
        }
        [HttpGet("GetUserAverage")]
        public async Task<IActionResult> GetUserAverage(int? DersId, int userid)
        {   
            if(DersId is not null && await dersRepository.IsDersExists((int)DersId))
            {
                return NotFound("Gönderilen Ders ID Bilgisi Sistemde Tanımlı Değil");
            }
            var rsesult = await noteRepository.GetUserAvarage(DersId, userid);
            return Ok(rsesult);
        }
        [HttpGet("GetClassAverage")]
        [Authorize(Roles = Constance.AdministratorOrUser)]
        public async Task<IActionResult> GetClassAverage(int? DersId, int ClassId)
        {
            var rsesult = await noteRepository.GetClassAvarage(DersId, ClassId);
            return Ok(rsesult);
        }
    }
}
