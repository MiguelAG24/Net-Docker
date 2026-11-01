
# ETAPA 1: Compilar la API con .NET 10
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build

WORKDIR /src

# Copiar el archivo del proyecto
COPY ApiEmpresa.csproj ./

# Restaurar dependencias
RUN dotnet restore ApiEmpresa.csproj

# Copiar el resto del codigo
COPY . .

# Publicar la API
RUN dotnet publish ApiEmpresa.csproj \
    -c Release \
    -o /app/publish \
    --no-restore

# ETAPA 2: Ejecutar la API
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final

WORKDIR /app

# Puerto interno del contenedor
ENV ASPNETCORE_HTTP_PORTS=8080
EXPOSE 8080

# Copiar los archivos publicados
COPY --from=build /app/publish .

# Ejecutar la API
ENTRYPOINT ["dotnet", "ApiEmpresa.dll"]
