using VendaIngressos.WebApp.MVC.Areas.Produto.Models;

namespace VendaIngressos.WebApp.MVC.Areas.Produto.Services
{
    public interface IAtracaoService
    {
        Task<IEnumerable<AtracaoModel>> BuscarTodasAtracoes();
    }
}