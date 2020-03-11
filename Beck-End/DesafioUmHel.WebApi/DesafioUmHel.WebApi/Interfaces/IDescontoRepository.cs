using DesafioUmHelp.WebApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioUmHelp.WebApi.Interfaces
{
    public interface IDescontoRepository
    {
        //Lista todos descontos
        List<Descontos> Get();

        //Busca desconto por Id
        Descontos BuscarPorId(int Id);

        //Lista descontos e usuários que contém o desconto
        List<Descontos> ListaComUsuarios();

        //Cadastra desconto novo
        void Cadastrar(Descontos descontos);

        //Atualiza um desconto, passando seu Id na url
        void Atualizar(int Id, Descontos descontos);

        //Deleta um desconto
        void Deletar(int Id);
    }
}
