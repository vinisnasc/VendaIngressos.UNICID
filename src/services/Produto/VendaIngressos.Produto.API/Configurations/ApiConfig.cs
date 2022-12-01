using Microsoft.AspNetCore.Mvc;

namespace VendaIngressos.Produto.API.Configurations
{
    public static class ApiConfig
    {
        public static IServiceCollection WebApiConfig(this IServiceCollection services)
        {
            services.Configure<ApiBehaviorOptions>(options =>
            {
                // Essa configuração não deixa com que a modelState seja analisada automaticamente, fiz isso para personalizar os erros
                options.SuppressModelStateInvalidFilter = true;
            });

            // Permite que a API seja acessada conforme a configuração abaixo - lembrar de colocar no app o "UseCors" com sua respectiva policy
            /*builder.Services.AddCors(options =>
            {
                options.AddPolicy("Development", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials());
            });*/

            return services;
        }

        public static IApplicationBuilder UseMVCConfig(this IApplicationBuilder app)
        {
            app.UseHttpsRedirection();
            //app.UseCors("Development");
            return app;
        }
    }
}