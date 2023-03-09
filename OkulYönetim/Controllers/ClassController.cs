using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OkulYönetim.Entity.EntityFramework.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OkulYönetim.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        IClassepository classRepository;
        public ClassController (IClassepository _classepository)
        {
            classRepository = _classepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok( await  classRepository.GetAll());
        }
    }
}
