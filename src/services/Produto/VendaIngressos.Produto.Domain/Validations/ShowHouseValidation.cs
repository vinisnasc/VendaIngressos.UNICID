using FluentValidation;
using VendaIngressos.Produto.Domain.Entities;

namespace VendaIngressos.Produto.Domain.Validations
{
    public class ShowHouseValidation : AbstractValidator<ShowHouse>
    {
        public ShowHouseValidation()
        {
            RuleFor(r => r.Telefone).NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");
        }
    }
}