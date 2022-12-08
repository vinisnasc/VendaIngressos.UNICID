using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VendaIngressos.WebApp.MVC.Models;

namespace VendaIngressos.WebApp.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            ModelState.AddModelError("","erro teste");
            return View();
        }

        [Route("erro/{id:length(3,3)}")]
        public IActionResult Error(int id)
        {
            var modelErro = new ErrorViewModel();

            if (id == 500)
            {
                modelErro.Mensagem = "Ocorreu um erro! Tente novamente mais tarde ou contate nosso suporte!";
                modelErro.Titulo = "Ocorreu um erro!";
                modelErro.ErrorCode = id;
            }
            else if(id == 404)
            {
                modelErro.Mensagem = "A pagina que esta procurando nao existe!";
                modelErro.Titulo = "Pagina nao encontrada!";
                modelErro.ErrorCode = id;
            }
            else if (id == 403)
            {
                modelErro.Mensagem = "Voce nao tem permissao para fazer isso!";
                modelErro.Titulo = "Acesso negado!";
                modelErro.ErrorCode = id;
            }
            else
            {
                return StatusCode(404);
            }

            return View("Error", modelErro);
        }
    }
}