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
            return Ok(_produtosRepository.BuscarPorId(Id));
        }

        [HttpPost]
        public IActionResult Post(Produtos produtos)
        {
            _produtosRepository.Cadastrar(produtos);
            return StatusCode(201);
        }

        [HttpPut("{Id}")]
        public IActionResult Put(int Id, Produtos produtos)
        {
            var ProdutoAtualizado = _produtosRepository.BuscarPorId(Id);
            if (ProdutoAtualizado == null)
                return NotFound("Id não encontrado");
            _produtosRepository.Atualizar(ProdutoAtualizado);
            return Ok(ProdutoAtualizado);
        }

        [HttpDelete("{Id}")]
        public IActionResult Deleta(int Id)
        {
            _produtosRepository.Deletar(Id);
            return StatusCode(204);
        }
    }
}
