using System.Text.Json;
using System.Text;
using VendaIngressos.WebApp.MVC.Areas.Produto.Models;
using VendaIngressos.WebApp.MVC.Extensions;
using VendaIngressos.WebApp.MVC.Models;

namespace VendaIngressos.WebApp.MVC.Areas.Produto.Services
{
    public class OrganizadorService : IOrganizadorService
    {
        private readonly HttpClient _client;
        public const string BasePath = "api/organizador";

        public OrganizadorService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<IEnumerable<OrganizadorTesteResult>> BuscarTodosOrganizadores()
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var response = await _client.GetAsync(BasePath);

            /*if (!TratarErrosResponse(response))
            {
                return new UsuarioRespostaLogin()
                {
                    ResponseResult = JsonSerializer.Deserialize<ResponseResult>(await response.Content.ReadAsStringAsync(), options)
                };
            }*/

            return JsonSerializer.Deserialize<IEnumerable<OrganizadorTesteResult>>(await response.Content.ReadAsStringAsync(), options);

            /*
            var response = await _client.GetAsync(BasePath);
            if (response.IsSuccessStatusCode)
            {
                try
                {
                    var teste = await response.ReadContentAs<IEnumerable<OrganizadorTesteResult>>();
                    return teste;
                }
                catch (Exception ex) { return null; }
            }

            else
                throw new Exception("Something went wrong when calling API");*/
        }

        public async Task CriarOrganizador(OrganizadorResult dto)
        {
            var response = await _client.PostAsJsonAsync(BasePath, dto);
            if (response.IsSuccessStatusCode)
                return;

            else
                throw new Exception("Something went wrong when calling API");
        }
    }
}