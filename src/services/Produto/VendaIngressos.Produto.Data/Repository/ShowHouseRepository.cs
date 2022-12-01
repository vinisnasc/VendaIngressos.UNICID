using Microsoft.EntityFrameworkCore;
using VendaIngressos.Produto.Domain.Entities;
using VendaIngressos.Produto.Domain.Interfaces.Repository;

namespace VendaIngressos.Produto.Data.Repository
{
    public class ShowHouseRepository : BaseRepository<ShowHouse>, IShowHouseRepository
    {
        public ShowHouseRepository(ProdutoContexto context) : base(context)
        {}

        public override async Task<ShowHouse> SelecionarPorId(Guid id)
        {
            return await _context.ShowHouse.Include(x => x.Endereco).ThenInclude(x => x.Municipio).ThenInclude(x => x.Uf).FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}