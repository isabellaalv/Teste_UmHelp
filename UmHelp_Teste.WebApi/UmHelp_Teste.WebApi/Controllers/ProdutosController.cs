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
    public class ProdutosController : ControllerBase
    {
        public IProdutosRepository _produtosRepository;

        public ProdutosController()
        {
            _produtosRepository = new ProdutosRepository();
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_produtosRepository.Get());
        }

        [HttpGet("{Id}")]
        public IActionResult GetPorId(int Id)
        {
            var GetId = _produtosRepository.BuscarPorId(Id);
            if (GetId == null)
                return NotFound("Produto não encontrado");
            return Ok(_produtosRepository.BuscarPorId(Id));
        }

        [HttpPost]
        public IActionResult Post(Produtos produtos)
        {
            _produtosRepository.Cadastrar(produtos);

            return StatusCode(201);
        }

        [HttpPut("{Id}")]
        public IActionResult Put (Produtos produtos, int Id)
        {
            var Produto = _produtosRepository.BuscarPorId(Id);
            if (Produto == null)
                return NotFound("Produto não encontrado");
            Produto.AlteraInformacoes(produtos.NomeProduto, produtos.Valor);
            _produtosRepository.Atualizar(Produto);
            return Ok(Produto);
        }
        [HttpDelete("{Id}")]
        public IActionResult Deletar(int Id)
        {
            var DeletaProduto = _produtosRepository.BuscarPorId(Id);
            if (DeletaProduto == null)
                return NotFound("Produto não encontrado");
            return Ok("Produtos deletado");
        }
    }
}
