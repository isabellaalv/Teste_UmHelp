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
        Produtos BuscarPorId(int Id);
        void Cadastrar(Produtos produtos);
        void Atualizar(Produtos produtos);
        void Deletar(int Id);
    }
}
