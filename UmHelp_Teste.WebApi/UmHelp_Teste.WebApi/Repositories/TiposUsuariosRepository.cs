using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UmHelp_Teste.WebApi.Contexts;
using UmHelp_Teste.WebApi.Domains;
using UmHelp_Teste.WebApi.Interfaces;

namespace UmHelp_Teste.WebApi.Repositories
{
    public class TiposUsuariosRepository : ITiposUsuariosRepository
    {
        UmHelpContext ctx = new UmHelpContext();

        public TiposUsuarios BuscarPorId(int Id)
        {
            return ctx.TiposUsuarios.FirstOrDefault(x => x.Id == Id);
        }

        public void Cadastrar(TiposUsuarios tiposUsuarios)
        {
            ctx.TiposUsuarios.Add(tiposUsuarios);
            ctx.SaveChanges();
        }

        public List<TiposUsuarios> Get()
        {
            return ctx.TiposUsuarios.ToList();
        }
    }
}
