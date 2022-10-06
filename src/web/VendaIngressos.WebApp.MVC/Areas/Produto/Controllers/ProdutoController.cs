using Microsoft.AspNetCore.Mvc;
using VendaIngressos.WebApp.MVC.Areas.Produto.Services;

namespace VendaIngressos.WebApp.MVC.Areas.Produto.Controllers
{
    [Area("Produto")]
    public class ProdutoController : Controller
    {
        private readonly IAtracaoService _atracaoService;

        public ProdutoController(IAtracaoService atracaoService)
        {
            _atracaoService = atracaoService;
        }

        public async Task<IActionResult> Index()
        {
            var lista = await _atracaoService.BuscarTodasAtracoes();
            return View(lista);
        }
    }
}