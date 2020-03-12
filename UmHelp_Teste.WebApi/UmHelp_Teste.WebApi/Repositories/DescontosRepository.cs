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
    public class DescontosRepository : IDescontosRepository
    {
        UmHelpContext ctx = new UmHelpContext();

        public List<Descontos> Ativos()
        {
            return ctx.Descontos.Where(x => x.Ativo == true).ToList();
        }

        public void Atualizar(Descontos descontos)
        {
            ctx.Descontos.Update(descontos);
            ctx.SaveChanges();
        }

        public Descontos BuscarPorId(int Id)
        {
            return ctx.Descontos.FirstOrDefault(x => x.Id == Id);
        }

        public List<Descontos> BuscarTodosPorId(int Id)
        {
            return ctx.Descontos.Where(x => x.Id == Id && x.Ativo == true).ToList();
        }

        public void Cadastrar(Descontos descontos)
        {
            ctx.Descontos.Add(descontos);
            ctx.SaveChanges();
        }

        public void Deletar(Descontos descontos)
        {
            ctx.Descontos.Remove(descontos);
            ctx.SaveChanges();
        }

        public List<Descontos> Get()
        {
            return ctx.Descontos.ToList();
        }

        public List<Descontos> ListaComUsuarios()
        {
            return ctx.Descontos.Include(x => x.Usuarios).ToList();
        }

        public Descontos MaiorDescontoPorId(int Id)
        {
            return ctx.Descontos.Where(x => x.Id == Id && x.Ativo == true)
                .OrderByDescending(x => x.Valor)
                .First();
        }
    }
}
