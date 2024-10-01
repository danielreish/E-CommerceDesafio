namespace E_CommerceDesafio.Domain.ValueObjects
{
    public class DescontoPorQuantidade : IDesconto
    {
        public int QuantidadeMinima { get; }
        public decimal ValorDesconto { get; }

        public DescontoPorQuantidade(int quantidadeMinima, decimal valorDesconto)
        {
            QuantidadeMinima = quantidadeMinima;
            ValorDesconto = valorDesconto;
        }

        public decimal AplicarDesconto(decimal valorTotal)
        {
            return valorTotal - ValorDesconto;
        }
    }
}
