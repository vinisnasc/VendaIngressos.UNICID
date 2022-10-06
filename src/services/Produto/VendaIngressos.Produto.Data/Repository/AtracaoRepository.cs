using Microsoft.EntityFrameworkCore;
using VendaIngressos.Produto.Domain.Entities;
using VendaIngressos.Produto.Domain.Interfaces.Repository;

namespace VendaIngressos.Produto.Data.Repository
{
    public class AtracaoRepository : BaseRepository<Atracao>, IAtracaoRepository
    {
        public AtracaoRepository(ProdutoContexto context) : base(context) {}

        public override async Task<List<Atracao>> SelecionarTudo()
        {
            return await _context.Atracoes.Include(x => x.Organizador)
                                          .Include(x => x.ShowHouse)
                                          .ThenInclude(x => x.Endereco)
                                          .ThenInclude(x => x.Municipio)
                                          .ThenInclude(x => x.Uf)
                                          .ToListAsync();
        }
    }
}