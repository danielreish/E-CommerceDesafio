namespace E_CommerceDesafio.Domain.Entities
{
    public enum StatusPedido
    {
        AguardandoProcessamento,
        ProcessandoPagamento,
        PagamentoConcluido,
        SeparandoPedido,
        AguardandoEstoque,
        Concluido,
        Cancelado
    }
}
