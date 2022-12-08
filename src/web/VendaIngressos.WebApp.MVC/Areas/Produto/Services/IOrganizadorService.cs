using VendaIngressos.WebApp.MVC.Areas.Produto.Models;

namespace VendaIngressos.WebApp.MVC.Areas.Produto.Services
{
    public interface IOrganizadorService
    {
        Task<IEnumerable<OrganizadorTesteResult>> BuscarTodosOrganizadores();
        Task CriarOrganizador(OrganizadorResult dto);
    }
}