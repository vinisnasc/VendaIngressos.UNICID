using VendaIngressos.WebApp.MVC.Areas.Identidade.Models;

namespace VendaIngressos.WebApp.MVC.Areas.Identidade.Services
{
    public interface IAutenticacaoService
    {
        Task<UsuarioRespostaLogin> Login(UsuarioLogin usuarioLogin);
        Task<UsuarioRespostaLogin> Registro(UsuarioRegistro usuarioRegistro);
    }
}