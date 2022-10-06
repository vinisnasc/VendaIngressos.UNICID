using Microsoft.EntityFrameworkCore;
using System.Reflection;
using VendaIngressos.Produto.Data.Seeds;
using VendaIngressos.Produto.Domain.Entities;

namespace VendaIngressos.Produto.Data
{
    public class ProdutoContexto : DbContext
    {
        public ProdutoContexto(DbContextOptions options) : base(options) { }

        public DbSet<Atracao> Atracoes { get; set; }
        public DbSet<Organizador> Organizadores { get; set; }
        public DbSet<ShowHouse> ShowHouse { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
           
            UfSeeds.UfSeed(modelBuilder);

            MapearPropriedadesStrings(modelBuilder);
        }

        /// <summary>
        /// Metodo que realiza o mapeamento de todas as propriedades tipo string que não foram mapeadas, caso exista
        /// </summary>
        /// <param name="modelBuilder">Informar como parametro o modelBuilder a ser mapeado</param>
        private void MapearPropriedadesStrings(ModelBuilder modelBuilder)
        {
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                var properties = entity.GetProperties().Where(p => p.ClrType == typeof(string));

                foreach (var property in properties)
                {
                    if (string.IsNullOrEmpty(property.GetColumnType()) 
                        && !property.GetMaxLength().HasValue) 
                    {
                        property.SetColumnType("Varchar(100)");
                    }
                }
            }
        }
    }
}