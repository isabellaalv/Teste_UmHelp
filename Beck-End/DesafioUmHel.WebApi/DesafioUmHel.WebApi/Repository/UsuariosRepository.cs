using DesafioUmHelp.WebApi.Context;
using DesafioUmHelp.WebApi.Domain;
using DesafioUmHelp.WebApi.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioUmHelp.WebApi.Repository
{
    public class UsuariosRepository : IUsuariosRepository
    {
        UmHelpContext ctx = new UmHelpContext();

        public void Atualizar(int Id, Usuarios usuarios)
        {
            Usuarios usuariosBuscado = ctx.Usuarios.Find(Id);
            //Atribui os valores que tem que ser passado no campo
            usuariosBuscado.Email = usuarios.Email;
            usuariosBuscado.Senha = usuarios.Senha;
            usuariosBuscado.IdTiposUsuarios = usuarios.IdTiposUsuarios;
            //Atualiza o desconto buscado
            ctx.Update(usuariosBuscado);
            //Salva as informações e grava no banco
            ctx.SaveChanges();
        }

        public Usuarios BuscarPorId(int Id)
        {
            return ctx.Usuarios.FirstOrDefault(x => x.Id == Id);
        }

        public void Cadastrar(Usuarios usuarios)
        {
            ctx.Usuarios.Add(usuarios);
            ctx.SaveChanges();
        }

        public void Deletar(int Id)
        {
            Usuarios usuariosBuscados = ctx.Usuarios.Find(Id);
            ctx.Usuarios.Remove(usuariosBuscados);
            ctx.SaveChanges();
        }

        public List<Usuarios> Get()
        {
            return ctx.Usuarios.ToList();
        }

        public List<Usuarios> ListaComTipo()
        {
            return ctx.Usuarios.Include(x => x.TiposUsuarios).ToList();
        }
    }
}
