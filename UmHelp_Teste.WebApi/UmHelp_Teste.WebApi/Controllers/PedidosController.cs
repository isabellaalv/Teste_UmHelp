﻿using Microsoft.AspNetCore.Mvc;
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
    public class PedidosController : ControllerBase
    {
        public IPedidosRepository _pedidosRepository;
        public IDescontosRepository _descontosRepository;
        public IProdutosRepository _produtosRepository;
        public IUsuariosRepository _usuariosRepository;

        public PedidosController()
        {
            _pedidosRepository = new PedidosRepository();
            _descontosRepository = new DescontosRepository();
            _produtosRepository = new ProdutosRepository();
            _usuariosRepository = new UsuariosRepository();
        }

        [HttpPost]
        public IActionResult CadastrarPedido(Pedidos pedido)
        {
            var Produtodb = _produtosRepository.BuscarPorId(pedido.IdProduto);
            if (Produtodb == null)
                return NotFound("Produto não existe");

            var Usuariodb = _usuariosRepository.BuscarPorId(pedido.IdUsuarios);
            if (Usuariodb == null)
                return NotFound("Usuarios não encontrado");

            var Descontos = _descontosRepository.MaiorDescontoPorId(pedido.IdUsuarios);

            if (Descontos != null)
            {
                //Pega o maior desconto
                var desconto = Descontos.OrderByDescending(x => x.Valor).First();

                //pedido.ValorProduto -= Desconto.Valor;
                pedido.ValorProduto = Produtodb.Valor - desconto.Valor;

                desconto.AlteraParaInativo();

                _descontosRepository.Atualizar(desconto);
            }
            else
            {
                pedido.ValorProduto = Produtodb.Valor;
            }


            _pedidosRepository.Cadastrar(pedido);

            return Created("http://localhost:5000/api/Pedidos", pedido);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_pedidosRepository.Get());
        }

        [HttpGet("{Id}")]
        public IActionResult BuscarPorId(int Id)
        {
            var GetId = _pedidosRepository.BuscarPorId(Id);
            if (GetId == null)
                return NotFound("Pedido não encontrado");
            return Ok(_pedidosRepository.BuscarPorId(Id));
        }
        [HttpDelete("{Id}")]
        public IActionResult Deletar(int Id)
        {
            var DeletaPedido = _pedidosRepository.BuscarPorId(Id);
            if (DeletaPedido == null)
                return NotFound("Pedido não encontrado");
            return Ok("Pedido deletado");

        }
    }
}
