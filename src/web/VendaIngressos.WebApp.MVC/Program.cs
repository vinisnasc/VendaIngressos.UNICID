using VendaIngressos.WebApp.MVC.Configuration;
using VendaIngressos.WebApp.MVC.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddIdentityConfiguration();
builder.Services.AddMVCConfiguration(builder.Configuration);
builder.Services.RegisterServices(builder.Configuration);

var app = builder.Build();
app.UseMVCConfiguration(app.Environment);
app.UseMiddleware<ExceptionMiddleware>();
app.MapControllerRoute(
              name: "default",
              pattern: "{area=Produto}/{controller=Produto}/{action=Index}/{id?}");
app.Run();