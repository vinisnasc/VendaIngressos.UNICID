using Microsoft.EntityFrameworkCore;

namespace VendaIngressos.Produto.API.Configurations
{
    public static class IdentityConfig
    {
        public static IServiceCollection AddIdentityConfiguration(this IServiceCollection services, IConfiguration configuration)
        {

            return services;
        }
    }
}