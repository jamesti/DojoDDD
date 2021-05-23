using DojoDDD.Domain.SeedWork;
using System;

namespace DojoDDD.Domain
{
    public class Produto : Entity, IAggregateRoot
    {
        public int Id { get; private set; }
        public string Descricao { get; private set; }
        public decimal Estoque { get; private set; }
        public string PrecoUnitario { get; private set; }
        public int ValorMinimoDeCompra { get; private set; }

        public Produto(int id, string descricao, decimal estoque, string precoUnitario, int valorMinimoDeCompra)
        {
            Id = id;
            Descricao = descricao ?? throw new ArgumentNullException(nameof(descricao));
            Estoque = estoque;
            PrecoUnitario = precoUnitario ?? throw new ArgumentNullException(nameof(precoUnitario));
            ValorMinimoDeCompra = valorMinimoDeCompra;
        }
    }
}