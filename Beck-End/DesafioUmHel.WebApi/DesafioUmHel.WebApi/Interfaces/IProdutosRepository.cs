using DesafioUmHelp.WebApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioUmHelp.WebApi.Interfaces
{
    public interface IProdutosRepository
    {
        List<Produtos> Get();
        List<Produtos> BuscarComDescontos();
        Produtos BuscarPorId(int Id);

        void Cadastrar(Produtos produtos);
        void Atualizar(int Id, Produtos produtos);

        void Deletar(int Id);
    }
}
