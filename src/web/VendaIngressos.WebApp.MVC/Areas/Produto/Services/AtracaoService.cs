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

        public async Task<AtracaoViewModel> BuscarPorId(Guid id)
        {
            var response = await _client.GetAsync(BasePath + "/" + id);
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<AtracaoViewModel>();

            else
                throw new Exception("Something went wrong when calling API");
        }

        public async Task<IEnumerable<AtracaoViewModel>> BuscarTodasAtracoes()
        {
            var response = await _client.GetAsync(BasePath);
            if (response.IsSuccessStatusCode)
            {
                try
                {
                    var teste = await response.ReadContentAs<IEnumerable<AtracaoViewModel>>();
                    return teste;
                }
                catch(Exception ex) { return null; }
            }

            else
                throw new Exception("Something went wrong when calling API");
        }

        public async Task CriarAtracao(AtracaoViewModel dto)
        {
            var response = await _client.PostAsJsonAsync(BasePath, dto);
            if (response.IsSuccessStatusCode)
                return;

            else
                throw new Exception("Something went wrong when calling API");
        }
    }
}