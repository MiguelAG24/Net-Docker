
using BlazorEmpresa.Components;

var builder = WebApplication.CreateBuilder(args);

// Configuración de componentes Blazor
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Configuración de la API REST
var apiUrl = builder.Configuration["ApiSettings:BaseUrl"]
    ?? throw new InvalidOperationException(
        "No se encontró la dirección de la API en ApiSettings:BaseUrl"
    );

// Cliente HTTP para consumir la API
builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri(apiUrl)
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute(
    "/not-found",
    createScopeForStatusCodePages: true
);

app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
