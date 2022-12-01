using VendaIngressos.WebApp.MVC.Areas.Produto.Models;
using VendaIngressos.WebApp.MVC.Extensions;

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

        public async Task<IEnumerable<OrganizadorResult>> BuscarTodosOrganizadores()
        {
            var response = await _client.GetAsync(BasePath);
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<IEnumerable<OrganizadorResult>>();

            else
                throw new Exception("Something went wrong when calling API");
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