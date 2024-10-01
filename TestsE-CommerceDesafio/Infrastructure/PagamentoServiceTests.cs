using E_CommerceDesafio.Application.Services;
using E_CommerceDesafio.Domain.Entities;
using E_CommerceDesafio.Domain.Services;
using E_CommerceDesafio.Infrastructure.Notifications;
using E_CommerceDesafio.Infrastructure.Payments;
using Moq;

namespace TestsE_CommerceDesafio.Infrastructure
{
    public class PagamentoServiceTests
    {
        private readonly Mock<INotificacaoService> _notificacaoServiceMock;
        private readonly PedidoService _pedidoService;

        public PagamentoServiceTests()
        {
            _notificacaoServiceMock = new Mock<INotificacaoService>();
            _pedidoService = new PedidoService(_notificacaoServiceMock.Object);
        }

        [Fact]
        public void ProcessarPagamento_DeveRetornarSucesso_PagamentoPix()
        {
            // Arrange
            var itens = new List<ItemPedido>
        {
            new ItemPedido(1, "Produto 1", 100m, 2)
        };
            var pagamento = new PagamentoPix();
            var pedidoResultado = _pedidoService.CriarPedido(itens);
            var pedido = pedidoResultado.Valor;

            // Act
            var resultadoPagamento = _pedidoService.ProcessarPagamento(pedido, pagamento);

            // Assert
            Assert.True(resultadoPagamento.Sucesso);
            Assert.Equal(StatusPedido.PagamentoConcluido, pedido.Status);
            _notificacaoServiceMock.Verify(n => n.NotificarCliente(pedido, "Pagamento realizado com sucesso."), Times.Once);
        }

        [Fact]
        public void ProcessarPagamento_DeveRetornarSucesso_PagamentoCartao()
        {
            // Arrange
            var itens = new List<ItemPedido>
        {
            new ItemPedido(1, "Produto 1", 100m, 2)
        };
            var pagamento = new PagamentoCartao(12);
            var pedidoResultado = _pedidoService.CriarPedido(itens);
            var pedido = pedidoResultado.Valor;

            // Act
            var resultadoPagamento = _pedidoService.ProcessarPagamento(pedido, pagamento);

            // Assert
            Assert.True(resultadoPagamento.Sucesso);
            Assert.Equal(StatusPedido.PagamentoConcluido, pedido.Status);
            _notificacaoServiceMock.Verify(n => n.NotificarCliente(pedido, "Pagamento realizado com sucesso."), Times.Once);
        }

        [Fact]
        public void ProcessarPagamento_DeveRetornarFalha_QuandoPagamentoFalhar()
        {
            // Arrange
            var itens = new List<ItemPedido>
        {
            new ItemPedido(1, "Produto 1", 100m, 2)
        };
            var pagamentoMock = new Mock<IPagamento>();
            pagamentoMock.Setup(p => p.ProcessarPagamento(It.IsAny<Pedido>()))
                .Returns(Resultado.Falha("Erro no pagamento"));

            var pedidoResultado = _pedidoService.CriarPedido(itens);
            var pedido = pedidoResultado.Valor;

            // Act
            var resultadoPagamento = _pedidoService.ProcessarPagamento(pedido, pagamentoMock.Object);

            // Assert
            Assert.False(resultadoPagamento.Sucesso);
            Assert.Equal(StatusPedido.Cancelado, pedido.Status);
            Assert.Equal("Falha ao processar o pagamento.", resultadoPagamento.Mensagem);
            _notificacaoServiceMock.Verify(n => n.NotificarCliente(pedido, "Pagamento falhou e o pedido foi cancelado."), Times.Once);
        }
    }
}
