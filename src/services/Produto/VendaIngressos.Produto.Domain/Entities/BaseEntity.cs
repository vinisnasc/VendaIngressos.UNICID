namespace VendaIngressos.Produto.Domain.Entities
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime CreateAt { get; set; }

        protected BaseEntity()
        {
            Id = Guid.NewGuid();
            CreateAt = DateTime.Now;
        }
    }
}