using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VendaIngressos.Produto.Data;
using VendaIngressos.Produto.Data.Repository;
using VendaIngressos.Produto.Domain.Interfaces.Repository;
using VendaIngressos.Produto.Domain.Interfaces.Service;
using VendaIngressos.Produto.Domain.NotificadorDeErros;
using VendaIngressos.Produto.Services;

namespace VendaIngressos.Produto.CrossCutting.DI
{
    public static class DependencyContainer
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<ProdutoContexto>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("ProdutoContexto"), 
                                     p => p.EnableRetryOnFailure()
                                           .MigrationsHistoryTable("Migracoes_RH"));
            });

            // Services
            services.AddScoped<IOrganizadorService, OrganizadorService>();
            services.AddScoped<IShowHouseService, ShowHouseService>();
            services.AddScoped<IAtracaoService, AtracaoService>();
            services.AddScoped<INotificador, Notificador>();

            // Repositorys
            services.AddScoped<IAtracaoRepository, AtracaoRepository>();
            services.AddScoped<IOrganizadorRepository, OrganizadorRepository>();
            services.AddScoped<IAtracaoRepository, AtracaoRepository>();
            services.AddScoped<IShowHouseRepository, ShowHouseRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            services.AddScoped<IMunicipioRepository, MunicipioRepository>();
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            // UnitOfWork
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}