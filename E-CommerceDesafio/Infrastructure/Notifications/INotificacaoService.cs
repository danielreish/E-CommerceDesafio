using E_CommerceDesafio.Domain.Entities;
using E_CommerceDesafio.Domain.Services;

namespace E_CommerceDesafio.Infrastructure.Notifications
{
    public interface INotificacaoService
    {
        Resultado NotificarCliente(Pedido pedido, string mensagem);
    }
}
