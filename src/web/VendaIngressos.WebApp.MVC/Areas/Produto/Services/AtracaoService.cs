using VendaIngressos.WebApp.MVC.Areas.Produto.Models;
using VendaIngressos.WebApp.MVC.Extensions;

namespace VendaIngressos.WebApp.MVC.Areas.Produto.Services
{
    public class AtracaoService : IAtracaoService
    {
        private readonly HttpClient _client;
        public const string BasePath = "api/atracao";

        public AtracaoService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<IEnumerable<AtracaoModel>> BuscarTodasAtracoes()
        {
            var response = await _client.GetAsync(BasePath);
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<IEnumerable<AtracaoModel>>();

            else
                throw new Exception("Something went wrong when calling API");
        }
    }
}