using VendaIngressos.WebApp.MVC.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddIdentityConfiguration();
builder.Services.AddMVCConfiguration();
builder.Services.RegisterServices(builder.Configuration);

var app = builder.Build();
app.UseMVCConfiguration(app.Environment);
app.MapControllerRoute(
              name: "default",
              pattern: "{area=Produto}/{controller=Produto}/{action=Index}/{id?}");
app.Run();