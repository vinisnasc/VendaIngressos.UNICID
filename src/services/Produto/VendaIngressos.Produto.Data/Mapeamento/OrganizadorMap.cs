using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VendaIngressos.Produto.Domain.Entities;

namespace VendaIngressos.Produto.Data.Mapeamento
{
    internal class OrganizadorMap : IEntityTypeConfiguration<Organizador>
    {
        public void Configure(EntityTypeBuilder<Organizador> builder)
        {
            builder.ToTable("Organizadores");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).HasColumnType("VARCHAR(80)").IsRequired();
            builder.Property(x => x.Email).HasColumnType("VARCHAR(50)").IsRequired();
            builder.Property(x => x.Telefone).HasColumnType("CHAR(11)");

            builder.HasMany(x => x.Atracoes).WithOne(x => x.Organizador).OnDelete(DeleteBehavior.Cascade);
        }
    }
}