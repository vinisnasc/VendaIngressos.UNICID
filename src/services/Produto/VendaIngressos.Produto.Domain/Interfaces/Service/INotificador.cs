using VendaIngressos.Produto.Domain.Notificador;

namespace VendaIngressos.Produto.Domain.Interfaces.Service
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);
    }
}