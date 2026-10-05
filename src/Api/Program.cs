using Api.Data;
using Api.Endpoints;
using Api.Services;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("Default")
    ?? "Data Source=data/app.db";

builder.Services.AddAppDatabase(connectionString);
builder.Services.AddScoped<EmprestimoService>();

var app = builder.Build();

app.GarantirBanco();
app.UseDefaultFiles();
app.UseStaticFiles();
app.MapEquipamentoEndpoints();

app.Run();
