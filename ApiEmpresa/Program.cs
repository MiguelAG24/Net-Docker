
using Microsoft.EntityFrameworkCore;
using ApiEmpresa.Models;

var builder = WebApplication.CreateBuilder(args);

// Servicios de la API
builder.Services.AddControllers();

// AZURE SQL DATABASE
builder.Services.AddDbContext<Conexiones>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("ConexionAzureSQL")
        ?? throw new InvalidOperationException(
            "No se encontró la cadena de conexión ConexionAzureSQL")
    )
);

// Configuración de OpenAPI
builder.Services.AddOpenApi();

var app = builder.Build();

// Configuración de la API
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
