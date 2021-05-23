using DojoDDD.Api.Services;
using DojoDDD.Domain;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace DojoDDD.Tests.OrdensCompras
{
    public class RegistrarOrdemCompra
    {
        private readonly Mock<IClienteRepositorio> _clienteRepositorio;
        private readonly Mock<IProdutoRepositorio> _produtoRepositorio;
        private readonly Mock<IOrdemCompraRepositorio> _ordemCompraRepositorio;

        public RegistrarOrdemCompra()
        {
            _clienteRepositorio = new Mock<IClienteRepositorio>();
            _produtoRepositorio = new Mock<IProdutoRepositorio>();
            _ordemCompraRepositorio = new Mock<IOrdemCompraRepositorio>();
        }

        [Fact]
        public void QuantidadeSolicitadaNaoSuficienteParaCompra()
        {
            //Arrange
            _clienteRepositorio.Setup(cli => cli.ConsultarPorId(It.IsAny<string>())).Returns(Task.FromResult(new Cliente("1", "Faker", 100)));
            _produtoRepositorio.Setup(prod => prod.ConsultarPorId(It.IsAny<int>())).Returns(Task.FromResult(new Produto(1, "teste", 50, "4", 10)));

            var ordem = new OrdemCompraServico(_clienteRepositorio.Object, _produtoRepositorio.Object, _ordemCompraRepositorio.Object);


            //Assert
            Assert.ThrowsAny<AggregateException>(
                //Act
                () => ordem.RegistrarOrdemCompra("1", 1, 0).Result
                );
        }

        [Fact]
        public void QuantidadeEstoqueNaoSuficienteParaCompra()
        {
            //Arrange
            _clienteRepositorio.Setup(cli => cli.ConsultarPorId(It.IsAny<string>())).Returns(Task.FromResult(new Cliente("1", "Faker", 100)));
            _produtoRepositorio.Setup(prod => prod.ConsultarPorId(It.IsAny<int>())).Returns(Task.FromResult(new Produto(1, "teste", 0, "4", 10)));

            var ordem = new OrdemCompraServico(_clienteRepositorio.Object, _produtoRepositorio.Object, _ordemCompraRepositorio.Object);


            //Assert
            Assert.ThrowsAny<AggregateException>(
                //Act
                () => ordem.RegistrarOrdemCompra("1", 1, 10).Result
                );
        }

        [Fact]
        public void ClienteNaoPossuiSaldoSuficienteParaCompra()
        {
            //Arrange
            _clienteRepositorio.Setup(cli => cli.ConsultarPorId(It.IsAny<string>())).Returns(Task.FromResult(new Cliente("1", "Faker", 0)));
            _produtoRepositorio.Setup(prod => prod.ConsultarPorId(It.IsAny<int>())).Returns(Task.FromResult(new Produto(1, "teste", 50, "4", 10)));

            var ordem = new OrdemCompraServico(_clienteRepositorio.Object, _produtoRepositorio.Object, _ordemCompraRepositorio.Object);


            //Assert
            Assert.ThrowsAny<AggregateException>(
                //Act
                () => ordem.RegistrarOrdemCompra("1", 1, 10).Result
                );
        }

        [Fact]
        public void QuantidadeMinimaNaoAtendidaParaCompra()
        {
            //Arrange
            _clienteRepositorio.Setup(cli => cli.ConsultarPorId(It.IsAny<string>())).Returns(Task.FromResult(new Cliente("1", "Faker", 200)));
            _produtoRepositorio.Setup(prod => prod.ConsultarPorId(It.IsAny<int>())).Returns(Task.FromResult(new Produto(1, "teste", 50, "4", 100)));

            var ordem = new OrdemCompraServico(_clienteRepositorio.Object, _produtoRepositorio.Object, _ordemCompraRepositorio.Object);


            //Assert
            Assert.ThrowsAny<AggregateException>(
                //Act
                () => ordem.RegistrarOrdemCompra("1", 1, 10).Result
                );
        }

        [Fact]
        public void QuantidadeEmEstoqueNaoSuficienteParaCompra()
        {
            //Arrange
            _clienteRepositorio.Setup(cli => cli.ConsultarPorId(It.IsAny<string>())).Returns(Task.FromResult(new Cliente("1", "Faker", 200)));
            _produtoRepositorio.Setup(prod => prod.ConsultarPorId(It.IsAny<int>())).Returns(Task.FromResult(new Produto(1, "teste", 30, "4", 100)));

            var ordem = new OrdemCompraServico(_clienteRepositorio.Object, _produtoRepositorio.Object, _ordemCompraRepositorio.Object);


            //Assert
            Assert.ThrowsAny<AggregateException>(
                //Act
                () => ordem.RegistrarOrdemCompra("1", 1, 10).Result
                );
        }
    }
}
