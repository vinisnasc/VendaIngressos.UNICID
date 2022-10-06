namespace VendaIngressos.WebApp.MVC.Areas.Produto.Services
{
    public class ShowHouseService
    {
        private readonly HttpClient _client;
        public const string BasePath = "api/showHouse";

        public ShowHouseService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }
    }
}
