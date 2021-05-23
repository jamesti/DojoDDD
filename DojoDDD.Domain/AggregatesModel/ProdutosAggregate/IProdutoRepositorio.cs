using DojoDDD.Domain.SeedWork;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DojoDDD.Domain
{
    public interface IProdutoRepositorio : IRepository<Produto>
    {
        Task<Produto> ConsultarPorId(int id);
        Task<IEnumerable<Produto>> Consultar();
    }
}