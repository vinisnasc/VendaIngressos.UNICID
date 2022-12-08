using Microsoft.Extensions.Options;
using System.Text;
using System.Text.Json;
using VendaIngressos.WebApp.MVC.Areas.Identidade.Models;
using VendaIngressos.WebApp.MVC.Extensions;
using VendaIngressos.WebApp.MVC.Models;

namespace VendaIngressos.WebApp.MVC.Areas.Identidade.Services
{
    public class AutenticacaoService : BaseService, IAutenticacaoService
    {
        private readonly HttpClient _client;

        public AutenticacaoService(HttpClient client, IOptions<AppSettings> settings)
        {
            client.BaseAddress = new Uri(settings.Value.AutenticacaoUrl);
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<UsuarioRespostaLogin> Login(UsuarioLogin usuarioLogin)
        {
            var loginContent = ObterConteudo(usuarioLogin);

            var response = await _client.PostAsJsonAsync("api/identidade/autenticar", usuarioLogin);

            if (!TratarErrosResponse(response))
            {
                return new UsuarioRespostaLogin()
                {
                    ResponseResult = await DeserializarObjetoResponse<ResponseResult>(response)
                };
            }

            return await DeserializarObjetoResponse<UsuarioRespostaLogin>(response);
        }

        public async Task<UsuarioRespostaLogin> Registro(UsuarioRegistro usuarioRegistro)
        {
            var registroContent = ObterConteudo(usuarioRegistro);

            var response = await _client.PostAsJsonAsync("/api/identidade/nova-conta", registroContent);

            if (!TratarErrosResponse(response))
            {
                return new UsuarioRespostaLogin()
                {
                    ResponseResult = await DeserializarObjetoResponse<ResponseResult>(response)
                };
            }

            return await DeserializarObjetoResponse<UsuarioRespostaLogin>(response);
        }
    }
}