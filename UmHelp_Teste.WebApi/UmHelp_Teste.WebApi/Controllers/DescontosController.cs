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

        [HttpGet("{Id}")]
        public IActionResult GetId(int Id)
        {
            var GetId = _descontosRepository.BuscarPorId(Id);
            if (GetId == null)
                return NotFound("Desconto não encontrado");
            return Ok(_descontosRepository.BuscarPorId(Id));
            
        }


        [HttpPost]
        public IActionResult Post(Descontos descontos)
        {
            _descontosRepository.Cadastrar(descontos);
            return StatusCode(201);
        }

        [HttpPut ("{Id}")]
        public IActionResult Put(Descontos descontos, int Id)
        {
            var DescontoAtualizado = _descontosRepository.BuscarPorId(Id);
            if (DescontoAtualizado == null)
                return NotFound("Desconto não encontrado");
            DescontoAtualizado.AlteraInformacoes(descontos.Valor, descontos.Ativo, descontos.IdUsuarios);
            _descontosRepository.Atualizar(DescontoAtualizado);
            return Ok(DescontoAtualizado);
        }
        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            var Deletar = _descontosRepository.BuscarPorId(Id);
            if (Deletar == null)
                return NotFound("Desconto não encontrado");
            return Ok("Pacote deletado");
        }
        [HttpGet("Ativos")]
        public IActionResult Ativos(int Id)
        {
            var D_Ativos = _descontosRepository.BuscarPorId(Id);
            return Ok(D_Ativos);
        }
        [HttpGet("Usuarios")]
        public IActionResult Usuarios()
        {
            return Ok(_descontosRepository.ListaComUsuarios());
        }

        

    }
}
