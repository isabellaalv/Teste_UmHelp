using DesafioUmHelp.WebApi.Context;
using DesafioUmHelp.WebApi.Domain;
using DesafioUmHelp.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioUmHelp.WebApi.Repository
{
    public class TiposUsuariosRepository : ITiposUsuariosRepository
    {
        UmHelpContext ctx = new UmHelpContext();

        public TiposUsuarios BuscarPorId(int Id)
        {
            return ctx.TiposUsuarios.FirstOrDefault(x => x.Id == Id);
        }

        public List<TiposUsuarios> Get()
        {
            return ctx.TiposUsuarios.ToList();
        }
    }
}
