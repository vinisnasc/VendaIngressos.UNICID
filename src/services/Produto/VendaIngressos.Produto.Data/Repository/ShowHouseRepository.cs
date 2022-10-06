using VendaIngressos.Produto.Domain.Entities;
using VendaIngressos.Produto.Domain.Interfaces.Repository;

namespace VendaIngressos.Produto.Data.Repository
{
    public class ShowHouseRepository : BaseRepository<ShowHouse>, IShowHouseRepository
    {
        public ShowHouseRepository(ProdutoContexto context) : base(context)
        {}
    }
}