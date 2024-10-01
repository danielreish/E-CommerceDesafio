using E_CommerceDesafio.Domain.Entities;
using E_CommerceDesafio.Domain.Services;

namespace E_CommerceDesafio.Infrastructure.Notifications
{
    public class EmailNotificacaoService : INotificacaoService
    {
        public Resultado NotificarCliente(Pedido pedido, string mensagem)
        {
            return Resultado.Exito();
        }
    }
}
