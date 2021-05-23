using DojoDDD.Domain.SeedWork;

namespace DojoDDD.Domain
{
    public class Produto : Entity, IAggregateRoot
    {
        public int Id { get; private set; }
        public string Descricao { get; private set; }
        public decimal Estoque { get; private set; }
        public string PrecoUnitario { get; private set; }
        public int ValorMinimoDeCompra { get; private set; }
    }
}