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
    public class PedidosRepository : IPedidosRepository
    {
        UmHelpContext ctx = new UmHelpContext();

        public void Atualizar(Pedidos pedidos)
        {
            ctx.Pedidos.Update(pedidos);
            ctx.SaveChanges();
        }

        public Pedidos BuscarPorId(int Id)
        {
            return ctx.Pedidos.FirstOrDefault(x => x.Id == Id);
        }

        public void Cadastrar(Pedidos pedidos)
        {
            ctx.Pedidos.Add(pedidos);
            ctx.SaveChanges();
        }

        public List<Pedidos> DadosdoUsuario(int Id)
        {
            
            var Pedidos = ctx.Pedidos.Include(x => x.Usuarios).Where(x => x.Id == Id).ToList();

            if (Pedidos.Count == 0)
                return null;

            return Pedidos;
        }

        public void Deletar(Pedidos pedidos)
        {
            ctx.Pedidos.Remove(pedidos);
            ctx.SaveChanges();
        }

        public List<Pedidos> Get()
        {
            return ctx.Pedidos.ToList();
        }

        public List<Pedidos> GetByIdUsuario()
        {
            return ctx.Pedidos.Include(x => x.Usuarios).ToList();
        }
    }
}
