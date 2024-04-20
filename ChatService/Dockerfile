FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copiez csproj et restaurez les dépendances
COPY *.csproj ./
RUN dotnet restore

# Copiez le reste de l'application et construisez
COPY . ./
RUN dotnet publish -c Release -o out

# Définition des variables d'environnement
ENV DB_HOST=mysql_message
ENV DB_PORT=3306
ENV DB_NAME=message
ENV DB_USER=root
ENV DB_PASSWORD=root

# Utilisez l'image de base ASP.NET Core pour exécuter l'application
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "ChatService.dll"]
