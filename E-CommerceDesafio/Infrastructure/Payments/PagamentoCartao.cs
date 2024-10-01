using E_CommerceDesafio.Domain.Entities;
using E_CommerceDesafio.Domain.Services;

namespace E_CommerceDesafio.Infrastructure.Payments
{
    public class PagamentoCartao : IPagamento
    {
        public int Parcelas { get; }

        public PagamentoCartao() : this(12)
        {
        }

        public PagamentoCartao(int parcelas)
        {
            Parcelas = parcelas;
        }

        public Resultado ProcessarPagamento(Pedido pedido)
        {
            return Resultado.Exito();
        }
    }
}
