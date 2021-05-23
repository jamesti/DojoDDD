using DojoDDD.Domain.SeedWork;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DojoDDD.Domain
{
    public interface IClienteRepositorio : IRepository<Cliente>
    {
        Task<Cliente> ConsultarPorId(string id);
        Task<IEnumerable<Cliente>> ConsultarTodosCliente();
    }
}