using VendaIngressos.WebApp.MVC.Areas.Produto.Models;
using VendaIngressos.WebApp.MVC.Extensions;

namespace VendaIngressos.WebApp.MVC.Areas.Produto.Services
{
    public class ShowHouseService : IShowHouseService
    {
        private readonly HttpClient _client;
        public const string BasePath = "api/showHouse";

        public ShowHouseService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<IEnumerable<ShowHouseResult>> BuscarTodasShowHouses()
        {
            var response = await _client.GetAsync(BasePath);
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<IEnumerable<ShowHouseResult>>();

            else
                throw new Exception("Something went wrong when calling API");
        }

        public async Task CriarShowHouse(ShowHouseResult dto)
        {
            var response = await _client.PostAsJsonAsync(BasePath, dto);
            if (response.IsSuccessStatusCode)
                return;

            else
                throw new Exception("Something went wrong when calling API");
        }
    }
}