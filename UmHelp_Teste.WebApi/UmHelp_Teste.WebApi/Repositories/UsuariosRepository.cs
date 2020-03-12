using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UmHelp_Teste.WebApi.Contexts;
using UmHelp_Teste.WebApi.Domains;
using UmHelp_Teste.WebApi.Interfaces;

namespace UmHelp_Teste.WebApi.Repositories
{
    public class UsuariosRepository : IUsuariosRepository
    {
        UmHelpContext ctx = new UmHelpContext();

        public void Atualizar(Usuarios usuarios)
        {
            ctx.Usuarios.Update(usuarios);
            ctx.SaveChanges();
        }

        public Usuarios BuscarPorId(int Id)
        {
            return ctx.Usuarios.FirstOrDefault(x => x.Id == Id);
        }

        public void Cadastrar(Usuarios usuarios)
        {
            ctx.Usuarios.Update(usuarios);
            ctx.SaveChanges();
        }

        public void Deletar(Usuarios usuarios)
        {
            ctx.Usuarios.Remove(usuarios);
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
