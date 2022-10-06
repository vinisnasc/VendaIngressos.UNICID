namespace VendaIngressos.Produto.Domain.Interfaces.Repository
{
    public interface IUnitOfWork
    {
        public IAtracaoRepository AtracaoRepository { get; }
        public IOrganizadorRepository OrganizadorRepository { get; }
        public IMunicipioRepository MunicipioRepository { get; }
        public IEnderecoRepository EnderecoRepository { get; }
        public IShowHouseRepository ShowHouseRepository { get; }
    }
}