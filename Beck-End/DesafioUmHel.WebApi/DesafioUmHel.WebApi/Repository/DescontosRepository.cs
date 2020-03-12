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
    public class DescontosRepository : IDescontoRepository
    {
        UmHelpContext ctx = new UmHelpContext();

        public void Atualizar(int Id, Descontos descontos)
        {
            //Busca o desconto pelo Id
            Descontos descontoBuscado = ctx.Descontos.Find(Id);
            //Atribui os valores que tem que ser passado no campo
            descontoBuscado.Ativo = descontos.Ativo;
            descontoBuscado.Valor = descontos.Valor;
            descontoBuscado.IdUsuario = descontos.IdUsuario;
            //Atualiza o desconto buscado
            ctx.Update(descontoBuscado);
            //Salva as informações e grava no banco
            ctx.SaveChanges();
        }

        public Descontos BuscarPorId(int Id)
        {
            return ctx.Descontos.FirstOrDefault(x => x.Id == Id);
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
            //Retorna desconto e os usuários que 
            return ctx.Descontos.Include(x => x.Usuarios).ToList();
        }
    } 
}
