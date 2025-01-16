FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["PortfolioAPI.csproj", "./"]
RUN dotnet restore "PortfolioAPI.csproj"
COPY . .
RUN dotnet build "PortfolioAPI.csproj" -c Release -o /app/build
RUN dotnet publish "PortfolioAPI.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 80
EXPOSE 443
ENTRYPOINT ["dotnet", "PortfolioAPI.dll"]