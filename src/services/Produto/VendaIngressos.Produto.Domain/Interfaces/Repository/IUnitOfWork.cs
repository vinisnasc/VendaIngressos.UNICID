namespace VendaIngressos.Produto.Domain.Interfaces.Repository
{
    public interface IUnitOfWork
    {
        public IAtracaoRepository AtracaoRepository { get; }
        public IOrganizadorRepository OrganizadorRepository { get; }
    }
}