
# ETAPA 1: Compilar Blazor .NET 10
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build

WORKDIR /src

# Copiar el proyecto completo antes de restaurar
# para incluir los componentes Razor
COPY . .

# Restaurar dependencias
RUN dotnet restore BlazorEmpresa.csproj

# Publicar la aplicacion
RUN dotnet publish BlazorEmpresa.csproj \
    -c Release \
    -o /app/publish \
    --no-restore

# ETAPA 2: Ejecutar Blazor
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final

WORKDIR /app

ENV ASPNETCORE_HTTP_PORTS=8080
EXPOSE 8080

# Copiar los archivos publicados
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "BlazorEmpresa.dll"]
