using E_CommerceDesafio.Application.Services;
using E_CommerceDesafio.Domain.Entities;
using E_CommerceDesafio.Infrastructure.Notifications;
using Moq;

namespace TestsE_CommerceDesafio.Application
{
    public class PedidoServiceTests
    {
        private readonly Mock<INotificacaoService> _notificacaoServiceMock;
        private readonly PedidoService _pedidoService;

        public PedidoServiceTests()
        {
            _notificacaoServiceMock = new Mock<INotificacaoService>();
            _pedidoService = new PedidoService(_notificacaoServiceMock.Object);
        }

        [Fact]
        public void CriarPedido_DeveRetornarSucesso_QuandoItensValidos()
        {
            // Arrange
            var itens = new List<ItemPedido>
        {
            new ItemPedido(1, "Produto 1", 100m, 2),
            new ItemPedido(2, "Produto 2", 50m, 1)
        };

            // Act
            var resultado = _pedidoService.CriarPedido(itens);

            // Assert
            Assert.True(resultado.Sucesso);
            Assert.NotNull(resultado.Valor);
            _notificacaoServiceMock.Verify(n => n.NotificarCliente(It.IsAny<Pedido>(), "Pedido criado com sucesso."), Times.Once);
        }

        [Fact]
        public void CriarPedido_DeveRetornarFalha_QuandoNenhumItem()
        {
            // Arrange
            var itens = new List<ItemPedido>();

            // Act
            var resultado = _pedidoService.CriarPedido(itens);

            // Assert
            Assert.False(resultado.Sucesso);
            Assert.Equal("O pedido deve conter ao menos um item.", resultado.Mensagem);
        }
    }
}
