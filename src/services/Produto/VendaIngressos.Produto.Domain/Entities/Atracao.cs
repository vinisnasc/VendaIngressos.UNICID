using VendaIngressos.Produto.Domain.Entities.Enums;

namespace VendaIngressos.Produto.Domain.Entities
{
    public class Atracao : BaseEntity
    {
        public string Nome { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
        public int QuantidadeIngresso { get; set; }
        public string Poster { get; set; }
        public string Descricao { get; set; }
        public TipoEvento TipoEvento { get; set; }
        public Guid OrganizadorId { get; set; }
        public Organizador Organizador { get; set; }
        public Guid ShowHouseId { get; set; }
        public ShowHouse ShowHouse { get; set; }
    }
}