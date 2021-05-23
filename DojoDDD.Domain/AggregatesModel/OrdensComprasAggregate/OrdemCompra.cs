using DojoDDD.Domain.SeedWork;
using System;

namespace DojoDDD.Domain
{
    public class OrdemCompra : Entity, IAggregateRoot
    {
        public OrdemCompra()
        {
            Status = OrdemCompraStatus.Solicitado;
        }

        public string Id { get; } = Guid.NewGuid().ToString();

        public DateTime DataOperacao { get; private set; }
        public int ProdutoId { get; private set; }
        public string ClienteId { get; private set; }
        public int QuantidadeSolicitada { get; private set; }
        public decimal ValorOperacao { get; private set; }
        public decimal PrecoUnitario { get; private set; }
        public OrdemCompraStatus Status { get; private set; }

        public OrdemCompra(string clienteId, DateTime dataOperacao, int produtoId, decimal precoUnitario, decimal valorOperacao, int quantidadeSolicitada)
        {
            ClienteId = clienteId ?? throw new ArgumentNullException(nameof(clienteId));
            DataOperacao = dataOperacao;
            ProdutoId = produtoId;
            PrecoUnitario = precoUnitario;
            ValorOperacao = valorOperacao;
            QuantidadeSolicitada = quantidadeSolicitada;
        }
    }
}