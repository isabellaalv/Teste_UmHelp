using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UmHelp_Teste.WebApi.Domains;

namespace UmHelp_Teste.WebApi.Interfaces
{
    public interface ITiposUsuariosRepository
    {
        //Lista todos tipos usuarios
        List<TiposUsuarios> Get();

        //Busca tipos usuarios por Id
        TiposUsuarios BuscarPorId(int Id);
        //Cadastra um tipo de usuário
        void Cadastrar(TiposUsuarios tiposUsuarios);
    }
}
