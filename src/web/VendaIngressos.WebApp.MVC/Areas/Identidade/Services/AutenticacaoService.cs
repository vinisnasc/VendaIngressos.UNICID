using VendaIngressos.WebApp.MVC.Areas.Identidade.Models;
using VendaIngressos.WebApp.MVC.Extensions;

namespace VendaIngressos.WebApp.MVC.Areas.Identidade.Services
{
    public class AutenticacaoService : IAutenticacaoService
    {
        private readonly HttpClient _client;
        public const string BasePath = "api/identidade";

        public AutenticacaoService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<UsuarioRespostaLogin> Login(UsuarioLogin usuarioLogin)
        {
            var response = await _client.PostAsJsonAsync(BasePath + "/autenticar", usuarioLogin);
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<UsuarioRespostaLogin>();

            else
                throw new Exception("Something went wrong when calling API");
        }

        public async Task<UsuarioRespostaLogin> Registro(UsuarioRegistro usuarioRegistro)
        {
            var response = await _client.PostAsJsonAsync(BasePath + "/nova-conta", usuarioRegistro);
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<UsuarioRespostaLogin>();

            else
                throw new Exception("Something went wrong when calling API");
        }
    }
}