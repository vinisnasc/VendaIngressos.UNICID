using Microsoft.AspNetCore.Mvc;
using VendaIngressos.WebApp.MVC.Areas.Produto.Models;
using VendaIngressos.WebApp.MVC.Areas.Produto.Services;

namespace VendaIngressos.WebApp.MVC.Areas.Produto.Controllers
{
    [Area("Produto")]
    public class ShowHouseController : Controller
    {
        private readonly IShowHouseService _showHouseService;

        public ShowHouseController(IShowHouseService showHouseService)
        {
            _showHouseService = showHouseService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _showHouseService.BuscarTodasShowHouses());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ShowHouseResult dto)
        {
            await _showHouseService.CriarShowHouse(dto);
            return RedirectToAction(nameof(Index));
        }
    }
}