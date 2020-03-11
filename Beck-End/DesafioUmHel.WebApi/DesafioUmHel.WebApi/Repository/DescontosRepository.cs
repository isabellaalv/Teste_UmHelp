using DesafioUmHelp.WebApi.Context;
using DesafioUmHelp.WebApi.Domain;
using DesafioUmHelp.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioUmHelp.WebApi.Repository
{
    public class DescontosRepository : IDescontoRepository
    {
        UmHelpContext ctx = new UmHelpContext();

        public List<Descontos> Get()
        {
            return ctx.Descontos.ToList();
        }
    } 
}
