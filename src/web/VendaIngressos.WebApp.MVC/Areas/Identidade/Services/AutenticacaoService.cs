using System.Text;
using System.Text.Json;
using VendaIngressos.WebApp.MVC.Areas.Identidade.Models;
using VendaIngressos.WebApp.MVC.Extensions;

namespace VendaIngressos.WebApp.MVC.Areas.Identidade.Services
{
    public class AutenticacaoService : BaseService, IAutenticacaoService
    {
        private readonly HttpClient _client;
        public const string BasePath = "api/identidade";

        public AutenticacaoService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<UsuarioRespostaLogin> Login(UsuarioLogin usuarioLogin)
        {
            /*
            var loginContent = new StringContent(JsonSerializer.Serialize(usuarioLogin), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("https://localhost:7203/api/identidade/autenticar", loginContent);
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            return JsonSerializer.Deserialize<UsuarioRespostaLogin>(await response.Content.ReadAsStringAsync(), options);
            */

            var response = await _client.PostAsJsonAsync(BasePath + "/autenticar", usuarioLogin);

            if (!TratarErrosResponse(response))
            {
                return await response.ReadContentAs<UsuarioRespostaLogin>();
            }

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