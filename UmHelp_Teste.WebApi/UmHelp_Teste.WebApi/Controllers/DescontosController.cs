using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UmHelp_Teste.WebApi.Interfaces;
using UmHelp_Teste.WebApi.Repositories;

namespace UmHelp_Teste.WebApi.Controllers
{

    [Produces("application/json")]

    [Route("api/[controller]")]

    [ApiController]
    public class DescontosController : ControllerBase
    {
        public IDescontosRepository _descontosRepository;

        public DescontosController()
        {
            _descontosRepository = new DescontosRepository();
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_descontosRepository.Get());
        }
    }
}
