# Используем официальный образ .NET SDK для сборки
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["wt-lab4-mvc-pekarskaya.csproj", "./"]
RUN dotnet restore "wt-lab4-mvc-pekarskaya.csproj"
COPY . .
RUN dotnet publish "wt-lab4-mvc-pekarskaya.csproj" -c Release -o /app/publish

# Используем официальный образ ASP.NET для запуска
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080
ENTRYPOINT ["dotnet", "wt-lab4-mvc-pekarskaya.dll"]