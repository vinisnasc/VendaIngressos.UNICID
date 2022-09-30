namespace VendaIngressos.Produto.Domain.Entities
{
    public class ShowHouse : BaseEntity
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public Guid EnderecoId { get; set; }
        public Endereco Endereco { get; set; }
    }
}