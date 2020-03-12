using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UmHelp_Teste.WebApi.Domains;

namespace UmHelp_Teste.WebApi.Interfaces
{
    public interface IDescontosRepository
    {
        //Lista todos descontos
        List<Descontos> Get();

        //Busca desconto por Id
        Descontos BuscarPorId(int Id);

        //Lista o valor do desconto maior
        List<Descontos> MaiorDesconto();

        //Lista descontos ativos
        List<Descontos> Ativos();

        //Lista descontos e usuários que contém o desconto
        List<Descontos> ListaComUsuarios();

        //Cadastra desconto novo
        void Cadastrar(Descontos descontos);

        //Atualiza um desconto, passando seu Id na url
        void Atualizar(Descontos descontos);

        //Deleta um desconto
        void Deletar(Descontos descontos);

    }
}
