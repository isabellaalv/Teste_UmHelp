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
    public class PedidosController : ControllerBase
    {
        public IPedidosRepository _pedidosRepository;

        public PedidosController()
        {
            _pedidosRepository = new PedidosRepository();
        }
        /// <summary>
        /// Lista todos pedidos
        /// </summary>
        /// <returns>Retorna todos pedidos</returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_pedidosRepository.Get());
        }
        /// <summary>
        /// Lista pedido pelo seu ir, passado na url
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Retorna id passado</returns>
        [HttpGet("{Id}")]
        public IActionResult GetPorId (int Id)
        {
            var GetId = _pedidosRepository.BuscarPorId(Id);
            if (GetId == null)
                return NotFound("Pedido não encontrado");
            return Ok(_pedidosRepository.BuscarPorId(Id));
        }
        /// <summary>
        /// Lista pedidos de um usuário
        /// </summary>
        /// <returns>Retorna pedido e usuário</returns>
        [HttpGet("PorUsuario")]
        public IActionResult GetUsuario()
        {
            return Ok(_pedidosRepository.GetByIdUsuario());
        }
        /// <summary>
        /// Cadastra um pedido novo
        /// </summary>
        /// <param name="pedidos"></param>
        /// <returns>Retorna pedido cadastrado</returns>
        [HttpPost]
        public IActionResult Post(Pedidos pedidos)
        {
            _pedidosRepository.Cadastrar(pedidos);
            return StatusCode(201);
        }
        /// <summary>
        /// Atualiza pedido, passando seu id
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="pedidos"></param>
        /// <returns>Retorna pedido atualizado</returns>
        [HttpPut("{Id}")]
        public IActionResult Put(int Id, Pedidos pedidos)
        {
            var PedidoAtualizado = _pedidosRepository.BuscarPorId(Id);
            if (PedidoAtualizado == null)
                return NotFound("Pedido não encontrado");
            _pedidosRepository.Atualizar(PedidoAtualizado);
            return Ok(PedidoAtualizado);
        }

        [HttpDelete("{Id}")]
        public IActionResult Deletar(int Id)
        {
            _pedidosRepository.Deletar(Id);
            return StatusCode(204);
        }
    }
}
