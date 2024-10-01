using E_CommerceDesafio.Domain.Entities;
using E_CommerceDesafio.Domain.Services;

namespace E_CommerceDesafio.Infrastructure.Payments
{
    public interface IPagamento
    {
        Resultado ProcessarPagamento(Pedido pedido);
    }
}
