using DesafioUmHelp.WebApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioUmHelp.WebApi.Interfaces
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
        void Atualizar(int Id, Usuarios usuarios);

        //Deleta um usuario
        void Deletar(int Id);
    }
}
