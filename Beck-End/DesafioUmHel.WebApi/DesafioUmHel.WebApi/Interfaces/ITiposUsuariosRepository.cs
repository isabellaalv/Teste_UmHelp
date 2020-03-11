using DesafioUmHelp.WebApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioUmHelp.WebApi.Interfaces
{
    public interface ITiposUsuariosRepository
    {
        //Lista todos tipos usuarios
        List<TiposUsuarios> Get();

        //Busca tipos usuarios por Id
        TiposUsuarios BuscarPorId(int Id);

    }
}
