using VendaIngressos.WebApp.MVC.Areas.Produto.Models;

namespace VendaIngressos.WebApp.MVC.Areas.Produto.Services
{
    public interface IOrganizadorService
    {
        Task<IEnumerable<OrganizadorResult>> BuscarTodosOrganizadores();
        Task CriarOrganizador(OrganizadorResult dto);
    }
}