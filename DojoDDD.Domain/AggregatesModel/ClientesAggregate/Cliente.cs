using DojoDDD.Domain.SeedWork;

namespace DojoDDD.Domain
{
    public class Cliente : Entity, IAggregateRoot
    {
        public new string Id { get; private set; }
        public string Nome { get; private set; }
        public string Endereco { get; private set; }
        public int Idade { get; private set; }
        public decimal Saldo { get; private set; }

        public Cliente()
        {

        }

        public Cliente(string id, string nome, decimal saldo)
        {
            Id = id;
            Nome = nome;
            Saldo = saldo;
        }
    }
}