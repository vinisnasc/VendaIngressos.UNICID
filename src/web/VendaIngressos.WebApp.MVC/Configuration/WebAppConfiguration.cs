namespace VendaIngressos.WebApp.MVC.Configuration
{
    public static class WebAppConfiguration
    {
        public static void AddMVCConfiguration(this IServiceCollection services)
        {
            services.AddControllersWithViews();
        }

        public static void UseMVCConfiguration(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (!env.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseIdentityConfiguration();
        }
    }
}