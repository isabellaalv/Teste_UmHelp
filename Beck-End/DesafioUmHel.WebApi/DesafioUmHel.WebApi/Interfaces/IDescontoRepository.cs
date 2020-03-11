using DesafioUmHelp.WebApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioUmHelp.WebApi.Interfaces
{
    public interface IDescontoRepository
    {
        List<Descontos> Get();

        Descontos BuscarPorId(int Id);
    }
}
