using FluentValidation;
using VendaIngressos.Produto.Domain.Entities;

namespace VendaIngressos.Produto.Domain.Validations
{
    public class OrganizadorValidation : AbstractValidator<Organizador>
    {
        public OrganizadorValidation()
        {
            RuleFor(r => r.Telefone).NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");
            RuleFor(r => r.Email).NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");
            RuleFor(r => r.Nome).NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido").Length(2,10);
        }
    }
}