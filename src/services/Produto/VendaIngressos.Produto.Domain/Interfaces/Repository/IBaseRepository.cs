using VendaIngressos.Produto.Domain.Entities;

namespace VendaIngressos.Produto.Domain.Interfaces.Repository
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task Incluir(T entity);
        Task Alterar(T entity);
        Task<T> SelecionarPorId(Guid id);
        Task<List<T>> SelecionarTudo();
    }
}