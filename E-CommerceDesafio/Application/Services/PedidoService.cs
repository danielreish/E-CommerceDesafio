using E_CommerceDesafio.Domain.Entities;
using E_CommerceDesafio.Domain.Services;
using E_CommerceDesafio.Domain.ValueObjects;
using E_CommerceDesafio.Infrastructure.Notifications;
using E_CommerceDesafio.Infrastructure.Payments;

namespace E_CommerceDesafio.Application.Services
{
    public class PedidoService
    {
        private readonly INotificacaoService _notificacaoService;

        public PedidoService(INotificacaoService notificacaoService)
        {
            _notificacaoService = notificacaoService;
        }

        public Resultado<Pedido> CriarPedido(ICollection<ItemPedido> itens, IDesconto desconto = null)
        {
            if (itens == null || !itens.Any())
            {
                return Resultado.FalhaComValor<Pedido>("O pedido deve conter ao menos um item.");
            }

            var pedido = new Pedido(itens);

            if (desconto != null)
            {
                pedido.AplicarDesconto(desconto);
            }

            _notificacaoService.NotificarCliente(pedido, "Pedido criado com sucesso.");
            return Resultado.ExitoComValor(pedido);
        }

        public Resultado ProcessarPagamento(Pedido pedido, IPagamento pagamento)
        {
            var resultadoAlteracao = pedido.AlterarStatus(StatusPedido.ProcessandoPagamento);
            if (!resultadoAlteracao.Sucesso)
            {
                return resultadoAlteracao;
            }

            var resultadoPagamento = pagamento.ProcessarPagamento(pedido);
            if (!resultadoPagamento.Sucesso)
            {
                pedido.AlterarStatus(StatusPedido.Cancelado);
                _notificacaoService.NotificarCliente(pedido, "Pagamento falhou e o pedido foi cancelado.");
                return Resultado.Falha("Falha ao processar o pagamento.");
            }

            pedido.AlterarStatus(StatusPedido.PagamentoConcluido);
            _notificacaoService.NotificarCliente(pedido, "Pagamento realizado com sucesso.");
            return Resultado.Exito();
        }

        public Resultado SepararPedido(Pedido pedido)
        {
            var resultadoAlteracao = pedido.AlterarStatus(StatusPedido.SeparandoPedido);
            if (!resultadoAlteracao.Sucesso)
            {
                return resultadoAlteracao;
            }

            _notificacaoService.NotificarCliente(pedido, "Seu pedido está sendo separado.");
            return Resultado.Exito();
        }
    }
}
