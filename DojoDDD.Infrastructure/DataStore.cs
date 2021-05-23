using Bogus;
using DojoDDD.Domain;
using DojoDDD.Domain.SeedWork;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DojoDDD.Infrastructure
{
    public class DataStore : IUnitOfWork
    {
        private bool disposedValue;

        public List<OrdemCompra> OrdensCompras { get; set; } = new List<OrdemCompra>();

        public List<Cliente> Clientes { get; set; }
        public List<Produto> Produtos { get; set; }

        public DataStore()
        {
            LoadFakeData();
        }

        private void LoadFakeData()
        {
            Clientes = new Faker<Cliente>()
                .RuleFor(s => s.Id, f => f.UniqueIndex.ToString())
                .RuleFor(s => s.Nome, f => f.Name.FullName())
                .RuleFor(s => s.Endereco, f => f.Address.FullAddress())
                .RuleFor(s => s.Saldo, f => f.Finance.Amount(100, 1000))
                .Generate(10)
                .ToList();

            Produtos = new Faker<Produto>()
                .RuleFor(s => s.Id, f => f.UniqueIndex)
                .RuleFor(s => s.Descricao, f => f.Commerce.ProductName())
                .RuleFor(s => s.Estoque, 1000)
                .RuleFor(s => s.ValorMinimoDeCompra, 500)
                .RuleFor(s => s.PrecoUnitario, f => f.Commerce.Price(1, 100, 2))
                .Generate(5)
                .ToList();
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            // Implementar quando for usar Entity Framework
            throw new System.NotImplementedException();
        }

        public Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            // Implementar quando for usar Entity Framework
            throw new System.NotImplementedException();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // Tarefa pendente: descartar o estado gerenciado (objetos gerenciados)
                }

                // Tarefa pendente: liberar recursos não gerenciados (objetos não gerenciados) e substituir o finalizador
                // Tarefa pendente: definir campos grandes como nulos
                disposedValue = true;
            }
        }

        // // Tarefa pendente: substituir o finalizador somente se 'Dispose(bool disposing)' tiver o código para liberar recursos não gerenciados
        // ~DataStore()
        // {
        //     // Não altere este código. Coloque o código de limpeza no método 'Dispose(bool disposing)'
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Não altere este código. Coloque o código de limpeza no método 'Dispose(bool disposing)'
            Dispose(disposing: true);
            System.GC.SuppressFinalize(this);
        }
    }
}