using Microsoft.AspNetCore.Mvc;

namespace VendaIngressos.WebApp.MVC.Areas.Produto.Controllers
{
    [Area("Produto")]
    public class ShowHouseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}