using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UmHelp_Teste.WebApi.Domains;
using UmHelp_Teste.WebApi.Interfaces;
using UmHelp_Teste.WebApi.Repositories;

namespace UmHelp_Teste.WebApi.Controllers
{

    [Produces("application/json")]

    [Route("api/[controller]")]

    [ApiController]
    public class TiposUsuariosController : ControllerBase
    {
        public ITiposUsuariosRepository _tiposUsuariosRepository;

        public TiposUsuariosController()
        {
            _tiposUsuariosRepository = new TiposUsuariosRepository();
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_tiposUsuariosRepository.Get());
        }

        [HttpGet ("{Id}")]
        public IActionResult GetPorId(int Id)
        {
            var GetId = _tiposUsuariosRepository.BuscarPorId(Id);
            if (GetId == null)
                return NotFound("Tipo usuario não encontrado");
            return Ok(_tiposUsuariosRepository.BuscarPorId(Id));
        }

        [HttpPost]
        public IActionResult Post(TiposUsuarios tiposUsuarios)
        {
            _tiposUsuariosRepository.Cadastrar(tiposUsuarios);
            return StatusCode(201);
        }

    }
}
