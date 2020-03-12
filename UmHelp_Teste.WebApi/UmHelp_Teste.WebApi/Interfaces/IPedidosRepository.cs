using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UmHelp_Teste.WebApi.Domains;

namespace UmHelp_Teste.WebApi.Interfaces
{
    public interface IPedidosRepository
    {
        List<Pedidos> Get();
        Pedidos BuscarPorId(int Id);
        List<Pedidos> GetByIdUsuario();
        void Cadastrar(Pedidos pedidos);
        void Atualizar(Pedidos pedidos);
        void Deletar(Pedidos pedidos);
    }
}
