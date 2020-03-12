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

        public void Deletar(int Id)
        {
            Pedidos pedidosBuscado = ctx.Pedidos.Find(Id);
            ctx.Pedidos.Remove(pedidosBuscado);
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
