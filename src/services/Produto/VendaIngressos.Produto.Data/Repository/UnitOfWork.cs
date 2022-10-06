using VendaIngressos.Produto.Domain.Interfaces.Repository;

namespace VendaIngressos.Produto.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProdutoContexto _context;
        public IAtracaoRepository AtracaoRepository { get; }
        public IOrganizadorRepository OrganizadorRepository { get; }
        public IShowHouseRepository ShowHouseRepository { get; }
        public IMunicipioRepository MunicipioRepository { get; }
        public IEnderecoRepository EnderecoRepository { get; }
        public UnitOfWork(ProdutoContexto context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            AtracaoRepository = new AtracaoRepository(context);
            OrganizadorRepository = new OrganizadorRepository(context);
            ShowHouseRepository = new ShowHouseRepository(context);
            MunicipioRepository = new MunicipioRepository(context);
            EnderecoRepository = new EnderecoRepository(context);
        }
    }
}