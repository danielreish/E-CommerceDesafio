using E_CommerceDesafio.Domain.ValueObjects;

namespace TestsE_CommerceDesafio.Domain
{
    public class DescontoTests
    {
        [Fact]
        public void DescontoPorQuantidade_DeveAplicarDescontoCorretamente()
        {
            // Arrange
            var desconto = new DescontoPorQuantidade(2, 10m);
            decimal valorTotal = 100m;

            // Act
            var valorComDesconto = desconto.AplicarDesconto(valorTotal);

            // Assert
            Assert.Equal(90m, valorComDesconto);
        }

        [Fact]
        public void DescontoSazonal_DeveAplicarDescontoCorretamente()
        {
            // Arrange
            var desconto = new DescontoSazonal(10m);
            decimal valorTotal = 100m;

            // Act
            var valorComDesconto = desconto.AplicarDesconto(valorTotal);

            // Assert
            Assert.Equal(90m, valorComDesconto);
        }
    }
}
