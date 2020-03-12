using DesafioUmHelp.WebApi.Domain;
using DesafioUmHelp.WebApi.Interfaces;
using DesafioUmHelp.WebApi.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioUmHelp.WebApi.Controllers
{

    [Produces("application/json")]

    [Route("api/[controller]")]

    [ApiController]
    public class DescontosController : ControllerBase
    {
        public IDescontoRepository _descontosRepository;

        public DescontosController()
        {
            _descontosRepository = new DescontosRepository();
        }

        /// <summary>
        /// Retorna lista de desconto
        /// </summary>
        /// <returns>Retorna todos desconto</returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_descontosRepository.Get());
        }
        /// <summary>
        /// Passando o Id na url, ira retorna o desconto que deseja, caso ele exista
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Retorna desconto buscado por Id</returns>
        [HttpGet("{Id}")]
        public IActionResult BuscarPorId(int Id)
        {
            var GetId = _descontosRepository.BuscarPorId(Id);
            if (GetId == null)
                return NotFound("Desconto não encontrado");
            return Ok(_descontosRepository.BuscarPorId(Id));
        }
        /// <summary>
        /// Lista descontos de cada usuário
        /// </summary>
        /// <returns>Retorna desconto  de usuários</returns>
        [HttpGet("GetPorUsuarios")]
        public IActionResult GetPorUsuarios()
        {
            return Ok(_descontosRepository.ListaComUsuarios());
        }
        /// <summary>
        /// Cadastra um desconto novo
        /// </summary>
        /// <param name="descontos"></param>
        /// <returns>Retorna desconto cadastrado</returns>
        [HttpPost]
        public IActionResult Post(Descontos descontos)
        {
            _descontosRepository.Cadastrar(descontos);
            return StatusCode(201);
        }
        /// <summary>
        /// Atualiza um desconto passando o Id
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="descontos"></param>
        /// <returns>Retorna desconto atualizado</returns>
        [HttpPut("{Id}")]
        public IActionResult Put(int Id, Descontos descontos)
        {
            _descontosRepository.Atualizar(Id, descontos);
            return StatusCode(204);
        }
        /// <summary>
        /// Deleta o desconto passando seu id na url
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Retorna desconto deletado</returns>
        [HttpDelete("{Id}")]
        public IActionResult Deletar(int Id)
        {
            var DeletaDesconto = _descontosRepository.BuscarPorId(Id);
            if (DeletaDesconto == null)
                return NotFound("Desconto não encontrado");
            _descontosRepository.Deletar(DeletaDesconto);
            return Ok("Desconto deletado");

        }
    }
}
