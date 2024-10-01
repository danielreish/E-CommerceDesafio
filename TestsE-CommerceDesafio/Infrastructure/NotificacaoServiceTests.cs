using E_CommerceDesafio.Domain.Entities;
using E_CommerceDesafio.Infrastructure.Notifications;

namespace TestsE_CommerceDesafio.Infrastructure
{
    public class NotificacaoServiceTests
    {
        [Fact]
        public void NotificarCliente_DeveEnviarNotificacaoComSucesso()
        {
            // Arrange
            var notificacaoService = new EmailNotificacaoService();
            var pedido = new Pedido(new List<ItemPedido>
        {
            new ItemPedido(1, "Produto 1", 100m, 2)
        });

            // Act
            var resultado = notificacaoService.NotificarCliente(pedido, "Seu pedido foi criado.");

            // Assert
            Assert.True(resultado.Sucesso);
        }
    }
}
