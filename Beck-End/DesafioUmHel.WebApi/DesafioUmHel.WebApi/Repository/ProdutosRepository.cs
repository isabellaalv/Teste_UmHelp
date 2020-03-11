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

        public void Atualizar(int Id, Produtos produtos)
        {
            Produtos produtosBuscados = ctx.Produtos.Find(Id);
            produtosBuscados.ValorProduto = produtos.ValorProduto;
            produtosBuscados.Data = produtos.Data;
            produtosBuscados.IdUsuarios = produtos.IdUsuarios;
            produtosBuscados.IdDesconto = produtos.IdDesconto;
            ctx.Produtos.Update(produtosBuscados);
            ctx.SaveChanges();
        }

        public List<Produtos> BuscarComDescontos()
        {
            return ctx.Produtos.Include(x => x.Descontos).ToList();
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
            Produtos produtosBuscados = ctx.Produtos.Find(Id);
            ctx.Produtos.Remove(produtosBuscados);
            ctx.SaveChanges();
        }

        public List<Produtos> Get()
        {
            return ctx.Produtos.ToList();
        }
    }
}
