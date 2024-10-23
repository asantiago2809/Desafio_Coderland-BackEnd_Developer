# Aqui primero establezco la imagen base de .NET 8.0
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Posterior se copia el archivo del proyecto y restauran las dependencias
COPY ["PruebaBackend.API/PruebaBackend.API.csproj", "PruebaBackend.API/"]
RUN dotnet restore "PruebaBackend.API/PruebaBackend.API.csproj"

# Copiamos el resto de los archivos y publicamos el proyecto
COPY . .
WORKDIR "/src/PruebaBackend.API"
RUN dotnet build "PruebaBackend.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PruebaBackend.API.csproj" -c Release -o /app/publish

# Y se construye la imagen final
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Por ultimo aplicamos las migraciones al iniciar la aplicación
ENTRYPOINT ["dotnet", "PruebaBackend.API.dll", "--apply-migrations"]