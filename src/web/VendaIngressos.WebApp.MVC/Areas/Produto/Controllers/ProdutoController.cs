using Microsoft.AspNetCore.Mvc;
using VendaIngressos.WebApp.MVC.Areas.Produto.Models;
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
           /* var lista = await _atracaoService.BuscarTodasAtracoes();*/
            return View(/*lista*/);
        }

        public async Task<IActionResult> Lista()
        {
            var lista = await _atracaoService.BuscarTodasAtracoes();
            return View(lista);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AtracaoViewModel dto)
        {
            await _atracaoService.CriarAtracao(dto);
            return RedirectToAction(nameof(Create));
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var atracao = await _atracaoService.BuscarPorId(id);
            return View(atracao);
        }
    }
}