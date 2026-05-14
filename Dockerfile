FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Копіюємо csproj і відновлюємо залежності
COPY NeuroHub.csproj .
RUN dotnet restore

# Копіюємо весь код і збираємо
COPY . .
RUN dotnet publish -c Release -o /app/publish

# Фінальний образ
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
EXPOSE 80
EXPOSE 443

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "NeuroHub.dll"]