namespace VendaIngressos.Produto.Domain.Entities
{
    public class Organizador : BaseEntity
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public ICollection<Atracao> Atracoes { get; set; }
    }
}