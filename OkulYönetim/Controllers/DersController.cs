using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OkulYönetim.Entity.EntityFramework.interfaces;

namespace OkulYönetim.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DersController : ControllerBase
    {
        private readonly IDersRepository dersRepository;

        public DersController(IDersRepository dersRepository)
        {
            this.dersRepository = dersRepository;
        }
    }
}
