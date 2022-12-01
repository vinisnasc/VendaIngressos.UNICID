using Microsoft.AspNetCore.Mvc;
using VendaIngressos.WebApp.MVC.Areas.Produto.Models;
using VendaIngressos.WebApp.MVC.Areas.Produto.Services;

namespace VendaIngressos.WebApp.MVC.Areas.Produto.Controllers
{
    [Area("Produto")]
    public class OrganizadorController : Controller
    {
        private readonly IOrganizadorService _organizadorService;

        public OrganizadorController(IOrganizadorService organizadorService)
        {
            _organizadorService = organizadorService ?? throw new ArgumentNullException(nameof(organizadorService));
        }

        public async Task<IActionResult> Index()
        {
            var list = await _organizadorService.BuscarTodosOrganizadores();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(OrganizadorResult dto)
        {
            await _organizadorService.CriarOrganizador(dto);
            return RedirectToAction("Index");
        }
    }
}
