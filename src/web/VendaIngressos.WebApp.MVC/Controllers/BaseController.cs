using Microsoft.AspNetCore.Mvc;
using VendaIngressos.WebApp.MVC.Models;

namespace VendaIngressos.WebApp.MVC.Controllers
{
    public abstract class BaseController : Controller
    {
        protected bool ResponsePossuiErros(ResponseResult response)
        {
            if(response != null && response.Errors.Mensagens.Any())
            {
                foreach(var mensagem in response.Errors.Mensagens)
                {
                    ModelState.AddModelError(string.Empty, mensagem);
                }

                return true;
            }

            return false;
        }
    }
}