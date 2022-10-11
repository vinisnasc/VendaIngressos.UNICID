using FluentValidation;
using VendaIngressos.Produto.Domain.Entities;

namespace VendaIngressos.Produto.Domain.Validations
{
    public class EnderecoValidation : AbstractValidator<Endereco>
    {
        public EnderecoValidation()
        {

        }
    }
}