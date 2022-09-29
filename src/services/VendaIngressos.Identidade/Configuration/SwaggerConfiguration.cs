using Microsoft.OpenApi.Models;

namespace VendaIngressos.Identidade.API.Configuration
{
    public static class SwaggerConfiguration
    {
        public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Venda de ingressos - Identidade",
                    Description = "Esta API faz parte do projeto de venda de ingressos realizado para o curso 'Projeto integrado em análise e desenvolvimento de sistemas'.",
                    Contact = new OpenApiContact() { Name = "Vinicius Nascimento", Email = "vini.souza00@gmail.com" }
                });
            });
            return services;
        }

        public static IApplicationBuilder UseSwaggerConfiguration(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            return app;
        }
    }
}