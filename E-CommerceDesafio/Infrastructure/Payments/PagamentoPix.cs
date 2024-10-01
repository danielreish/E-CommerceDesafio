using E_CommerceDesafio.Domain.Entities;
using E_CommerceDesafio.Domain.Services;
using E_CommerceDesafio.Domain.ValueObjects;

namespace E_CommerceDesafio.Infrastructure.Payments
{
    public class PagamentoPix : IPagamento
    {
        private const decimal DescontoPix = 0.05m;

        public Resultado ProcessarPagamento(Pedido pedido)
        {
            pedido.AplicarDesconto(new DescontoSazonal(DescontoPix * 100));

            return Resultado.Exito();
        }
    }
}
