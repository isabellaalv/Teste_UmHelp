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
    public class UsuarioController : ControllerBase
    {
        public IUsuariosRepository _usuariosRepository;

        public UsuarioController()
        {
            _usuariosRepository = new UsuariosRepository();
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_usuariosRepository.Get());
        }

        [HttpGet("{Id}")]
        public IActionResult GetPorId(int Id)
        {
            var GetId = _usuariosRepository.BuscarPorId(Id);
            if (GetId == null)
                return NotFound("Usuario não encontrado");
            return Ok(_usuariosRepository.BuscarPorId(Id));
        }
        [HttpPost]
        public IActionResult Post(Usuarios usuarios)
        {
            _usuariosRepository.Cadastrar(usuarios);
            return StatusCode(201);
        }

        [HttpPut("{Id}")]
        public IActionResult Put(int Id, Usuarios usuarios)
        {
            var AtualizaUsuario = _usuariosRepository.BuscarPorId(Id);
            if (AtualizaUsuario == null)
                return NotFound("Usuario não encontrado");
            AtualizaUsuario.AtualizaInformacao(usuarios.Email, usuarios.Senha, usuarios.IdTiposUsuarios);
            _usuariosRepository.Atualizar(AtualizaUsuario);
            return Ok(AtualizaUsuario);
        }

        [HttpDelete("{Id}")]
        public IActionResult Deletar (int Id, Usuarios usuarios)
        {
            var AtualizaUsuario = _usuariosRepository.BuscarPorId(Id);
            if (AtualizaUsuario == null)
                return NotFound("Usuario não encontrado");
            return Ok("Usuario deletado");
        }
    }

}