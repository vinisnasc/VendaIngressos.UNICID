using VendaIngressos.Produto.Domain.Entities;
using VendaIngressos.Produto.Domain.Interfaces.Repository;

namespace VendaIngressos.Produto.Data.Repository
{
    public class AtracaoRepository : BaseRepository<Atracao>, IAtracaoRepository
    {
        public AtracaoRepository(ProdutoContexto context) : base(context) {}
    }
}