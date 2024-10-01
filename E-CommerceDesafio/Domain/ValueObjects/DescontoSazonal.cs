namespace E_CommerceDesafio.Domain.ValueObjects
{
    public class DescontoSazonal : IDesconto
    {
        public decimal PercentualDesconto { get; }

        public DescontoSazonal(decimal percentualDesconto)
        {
            PercentualDesconto = percentualDesconto;
        }

        public decimal AplicarDesconto(decimal valorTotal)
        {
            return valorTotal - (valorTotal * (PercentualDesconto / 100));
        }
    }
}
