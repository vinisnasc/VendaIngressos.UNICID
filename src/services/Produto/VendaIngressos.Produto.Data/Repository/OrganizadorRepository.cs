using VendaIngressos.Produto.Domain.Entities;
using VendaIngressos.Produto.Domain.Interfaces.Repository;

namespace VendaIngressos.Produto.Data.Repository
{
    public class OrganizadorRepository : BaseRepository<Organizador>, IOrganizadorRepository
    {
        public OrganizadorRepository(ProdutoContexto context) : base(context) {}
    }
}