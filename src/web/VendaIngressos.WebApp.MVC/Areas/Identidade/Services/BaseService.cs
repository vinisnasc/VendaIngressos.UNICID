using System.Text;
using System.Text.Json;
using VendaIngressos.WebApp.MVC.Extensions;

namespace VendaIngressos.WebApp.MVC.Areas.Identidade.Services
{
    public abstract class BaseService
    {
        protected StringContent ObterConteudo(object dado)
        {
            return new StringContent(JsonSerializer.Serialize(dado), Encoding.UTF8, "application/json");
        }

        protected async Task<T> DeserializarObjetoResponse<T>(HttpResponseMessage message)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            return JsonSerializer.Deserialize<T>(await message.Content.ReadAsStringAsync(), options);
        }

        protected bool TratarErrosResponse(HttpResponseMessage response)
        {
            switch ((int)response.StatusCode)
            {
                case 401:
                case 403:
                case 404:
                case 500:
                    throw new CustomHttpRequestException(response.StatusCode);

                case 400:
                    return false;
            }

            // Garante que é um status code de sucesso
            response.EnsureSuccessStatusCode();
            return true;
        }
    }
}