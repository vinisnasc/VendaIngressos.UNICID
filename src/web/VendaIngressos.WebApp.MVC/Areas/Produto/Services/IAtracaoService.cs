using VendaIngressos.WebApp.MVC.Areas.Produto.Models;

namespace VendaIngressos.WebApp.MVC.Areas.Produto.Services
{
    public interface IAtracaoService
    {
        Task<AtracaoViewModel> BuscarPorId(Guid id);
        Task<IEnumerable<AtracaoViewModel>> BuscarTodasAtracoes();
        Task CriarAtracao(AtracaoViewModel dto);
    }
}