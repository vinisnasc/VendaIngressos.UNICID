using VendaIngressos.WebApp.MVC.Areas.Produto.Models;

namespace VendaIngressos.WebApp.MVC.Areas.Produto.Services
{
    public interface IShowHouseService
    {
        Task<IEnumerable<ShowHouseResult>> BuscarTodasShowHouses();
        Task CriarShowHouse(ShowHouseResult dto);
    }
}