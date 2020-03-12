using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UmHelp_Teste.WebApi.Domains;

namespace UmHelp_Teste.WebApi.Interfaces
{
    public interface IUsuariosRepository
    {
        //Lista todos usuario
        List<Usuarios> Get();

        //Busca usuario por Id
        Usuarios BuscarPorId(int Id);

        //Lista usuarios com tipo usuario
        List<Usuarios> ListaComTipo();

        //Cadastra usuarios novos
        void Cadastrar(Usuarios usuarios);

        //Atualiza um usuario, passando seu Id na url
        void Atualizar(Usuarios usuarios);

        //Deleta um usuario
        void Deletar(Usuarios usuarios);
    }
}
