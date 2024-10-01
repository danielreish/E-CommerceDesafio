using E_CommerceDesafio.Domain.Services;
using E_CommerceDesafio.Domain.ValueObjects;

namespace E_CommerceDesafio.Domain.Entities
{
    public class Pedido
    {
        public int PedidoId { get; }
        public DateTime DataCriacao { get; }
        public decimal ValorTotal { get; private set; }
        public StatusPedido Status { get; private set; }
        public IReadOnlyCollection<ItemPedido> Itens { get; }
        public IDesconto? DescontoAplicado { get; private set; }

        public Pedido(ICollection<ItemPedido> itens)
        {
            DataCriacao = DateTime.Now;
            Itens = itens.ToList().AsReadOnly();
            Status = StatusPedido.AguardandoProcessamento;
            CalcularValorTotal();
        }

        public void CalcularValorTotal()
        {
            ValorTotal = Itens.Sum(i => i.CalcularSubtotal());
            if (DescontoAplicado != null)
            {
                ValorTotal -= DescontoAplicado.AplicarDesconto(ValorTotal);
            }
        }

        public void AplicarDesconto(IDesconto desconto)
        {
            DescontoAplicado = desconto;
            CalcularValorTotal();
        }

        public Resultado AlterarStatus(StatusPedido novoStatus)
        {
            if (Status == StatusPedido.Concluido && novoStatus == StatusPedido.Cancelado)
            {
                return Resultado.Falha("Não é possível cancelar um pedido concluído.");
            }
            Status = novoStatus;
            return Resultado.Exito();
        }
    }
}
