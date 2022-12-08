using VendaIngressos.WebApp.MVC.Extensions;

namespace VendaIngressos.WebApp.MVC.Configuration
{
    public static class WebAppConfiguration
    {
        public static void AddMVCConfiguration(this IServiceCollection services, IConfiguration config)
        {
            services.AddControllersWithViews();
            services.Configure<AppSettings>(config);
        }

        public static void UseMVCConfiguration(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (!env.IsDevelopment())
            {
                app.UseExceptionHandler("/erro/500");
                app.UseStatusCodePagesWithRedirects("/erro/{0}");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseIdentityConfiguration();
        }
    }
}