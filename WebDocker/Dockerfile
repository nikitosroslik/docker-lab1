FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY WebDocker.csproj .
RUN dotnet restore
COPY . .
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .

# Самостоятельное задание: порт 5000 через переменную окружения
ENV ASPNETCORE_URLS=http://+:5000

# Volume для логов
VOLUME ["/app/logs"]

ENTRYPOINT ["dotnet", "WebDocker.dll"]
