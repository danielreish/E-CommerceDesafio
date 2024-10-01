namespace E_CommerceDesafio.Domain.ValueObjects
{
    public interface IDesconto
    {
        decimal AplicarDesconto(decimal valorTotal);
    }
}
