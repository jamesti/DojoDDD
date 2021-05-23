using DojoDDD.Domain.SeedWork;
using System.Threading.Tasks;

namespace DojoDDD.Domain
{
    public interface IOrdemCompraRepositorio : IRepository<OrdemCompra>
    {
        Task<string> RegistrarOrdemCompra(OrdemCompra ordemCompra);
        Task<bool> AlterarOrdemCompra(string ordemId, OrdemCompraStatus novoOrdemCompraStatus);
        Task<string> ConsultarPorId(string id);
    }
}