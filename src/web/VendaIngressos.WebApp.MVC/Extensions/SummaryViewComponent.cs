using Microsoft.AspNetCore.Mvc;
using System.Web;

namespace VendaIngressos.WebApp.MVC.Extensions
{
    // Lembrar de adicionar o [@addTagHelper "*, VendaIngressos.WebApp.MVC"] na viewImports e a tag <vc:Summary></vc:Summary> na view
    public class SummaryViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(HttpContext context)
        {
           
                return View();
        }
    }
}