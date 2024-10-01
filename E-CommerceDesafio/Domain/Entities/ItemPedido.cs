namespace E_CommerceDesafio.Domain.Entities
{
    public record ItemPedido(int ProdutoId, string NomeProduto, decimal Preco, int Quantidade)
    {
        public decimal CalcularSubtotal() => Preco * Quantidade;
    }
}
