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
    public class ProdutosRepository : IProdutosRepository
    {
        UmHelpContext ctx = new UmHelpContext();

        public void Atualizar(Produtos produtos)
        {
            ctx.Produtos.Update(produtos);
            ctx.SaveChanges();
        }

        public Produtos BuscarPorId(int Id)
        {
            return ctx.Produtos.FirstOrDefault(x => x.Id == Id);
        }

        public void Cadastrar(Produtos produtos)
        {
            ctx.Produtos.Add(produtos);
            ctx.SaveChanges();
        }

        public void Deletar(int Id)
        {
            Produtos produtos = ctx.Produtos.Find(Id);
            ctx.Produtos.Remove(produtos);
            ctx.SaveChanges();
        }

        public List<Produtos> Get()
        {
            return ctx.Produtos.ToList();
        }
    }
}
