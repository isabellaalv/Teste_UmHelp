using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UmHelp_Teste.WebApi.Domains;

namespace UmHelp_Teste.WebApi.Interfaces
{
    public interface IProdutosRepository
    {
        List<Produtos> Get();
        Produtos BuscarPorId(int Id);
        void Cadastrar(Produtos produtos);
        void Atualizar(Produtos produtos);
        void Deletar(Produtos produtos);
    }
}
