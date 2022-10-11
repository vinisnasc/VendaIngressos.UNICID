using FluentValidation;
using FluentValidation.Results;
using VendaIngressos.Produto.Domain.Entities;
using VendaIngressos.Produto.Domain.Interfaces.Service;
using VendaIngressos.Produto.Domain.Notificador;

namespace VendaIngressos.Produto.Services
{
    public abstract class BaseService
    {
        private readonly INotificador _notificador;

        protected BaseService(INotificador notificador)
        {
            _notificador = notificador;
        }

        protected void Notificar(ValidationResult validationResult)
        {
            foreach(var error in validationResult.Errors)
            {
                Notificar(error.ErrorMessage);
            }
        }

        protected void Notificar(string message)
        {
            _notificador.Handle(new Notificacao(message));
        }

        protected bool ExecutarValidacao<TV, TE>(TV validacao, TE entidade) where TV : AbstractValidator<TE> where TE : BaseEntity
        {
            var validator = validacao.Validate(entidade);

            if (validator.IsValid) return true;

            Notificar(validator);
            return false;
        }
    }
}