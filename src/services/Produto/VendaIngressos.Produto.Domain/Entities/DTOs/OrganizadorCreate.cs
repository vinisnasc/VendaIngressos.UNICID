using System.ComponentModel.DataAnnotations;

namespace VendaIngressos.Produto.Domain.Entities.DTOs
{
    public class OrganizadorCreate
    {
        [Required]
        [MinLength(4)]
        public string Nome { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        public string Telefone { get; set; }
    }
}