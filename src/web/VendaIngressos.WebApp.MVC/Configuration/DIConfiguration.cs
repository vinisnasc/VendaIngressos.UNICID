using VendaIngressos.WebApp.MVC.Areas.Identidade.Services;
using VendaIngressos.WebApp.MVC.Areas.Produto.Services;
using VendaIngressos.WebApp.MVC.Extensions;

namespace VendaIngressos.WebApp.MVC.Configuration
{
    public static class DIConfiguration
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient<IAutenticacaoService, AutenticacaoService>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUser, AspNetUser>();

            services.AddHttpClient<IAutenticacaoService, AutenticacaoService>(c =>
                                    c.BaseAddress = new Uri(configuration["ServiceUrls:AutenticacaoApi"]));
            services.AddHttpClient<IAtracaoService, AtracaoService>(c =>
                                    c.BaseAddress = new Uri(configuration["ServiceUrls:ProdutoApi"]));
            services.AddHttpClient<IOrganizadorService, OrganizadorService>(c =>
                                    c.BaseAddress = new Uri(configuration["ServiceUrls:ProdutoApi"]));
        }
    }
}