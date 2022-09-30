using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VendaIngressos.Produto.Domain.Entities;

namespace VendaIngressos.Produto.Data.Mapeamento
{
    internal class AtracaoMap : IEntityTypeConfiguration<Atracao>
    {
        public void Configure(EntityTypeBuilder<Atracao> builder)
        {
            builder.ToTable("Atracoes");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(x => x.Data).HasColumnType("DATETIME");
            builder.Property(x => x.Valor).IsRequired();
            builder.Property(x => x.QuantidadeIngresso).HasColumnType("INT").IsRequired();
            builder.Property(x => x.Poster).HasColumnType("VARCHAR(500)").IsRequired();
            builder.Property(x => x.Descricao).HasColumnType("VARCHAR(500)");
            builder.Property(x => x.TipoEvento).HasConversion<string>();
        }
    }
}