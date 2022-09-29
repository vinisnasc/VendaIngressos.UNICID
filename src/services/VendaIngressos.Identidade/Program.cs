using VendaIngressos.Identidade.API.Configuration;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddIdentityConfiguration(builder.Configuration);
builder.Services.AddApiConfiguration();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerConfiguration();

var app = builder.Build();
app.UseSwaggerConfiguration();
app.UseApiConfiguration(app.Environment);
app.Run();