using DesafioUmHelp.WebApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioUmHelp.WebApi.Interfaces
{
    public interface IPedidosRepository
    {
        List<Pedidos> Get();
        Pedidos BuscarPorId(int Id);
        List<Pedidos> GetByIdUsuario();
        void Cadastrar(Pedidos pedidos);
        void Atualizar(Pedidos pedidos);
        void Deletar(int Id);

    }
}
