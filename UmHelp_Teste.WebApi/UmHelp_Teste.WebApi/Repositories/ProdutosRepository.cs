using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UmHelp_Teste.WebApi.Contexts;
using UmHelp_Teste.WebApi.Domains;
using UmHelp_Teste.WebApi.Interfaces;

namespace UmHelp_Teste.WebApi.Repositories
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

        public void Deletar(Produtos produtos)
        {
            ctx.Produtos.Remove(produtos);
            ctx.SaveChanges();
        }

        public List<Produtos> Get()
        {
            return ctx.Produtos.ToList();
        }
    }
}
