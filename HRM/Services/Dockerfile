FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Services/Recruiting/Recruiting.API/Recruiting.API.csproj", "Services/Recruiting/Recruiting.API/"]
COPY ["Services/Recruiting/ApplicationCore/ApplicationCore.csproj", "Services/Recruiting/ApplicationCore/"]
COPY ["Services/Recruiting/Infrastruction/Infrastruction.csproj", "Services/Recruiting/Infrastruction/"]
RUN dotnet restore "Services/Recruiting/Recruiting.API/Recruiting.API.csproj"
COPY . .
WORKDIR "/src/Services/Recruiting/Recruiting.API"
RUN dotnet build "Recruiting.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Recruiting.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Recruiting.API.dll"]
