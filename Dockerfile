#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0-bullseye-slim-amd64 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["HRM/Services/Recruiting/Recruiting.API/Recruiting.API.csproj", "Services/Recruiting/Recruiting.API/"]
COPY ["HRM/Services/Recruiting/ApplicationCore/ApplicationCore.csproj", "Services/Recruiting/ApplicationCore/"]
COPY ["HRM/Services/Recruiting/Infrastruction/Infrastruction.csproj", "Services/Recruiting/Infrastruction/"]
RUN dotnet restore "HRM/Services/Recruiting/Recruiting.API/Recruiting.API.csproj"
COPY . .
WORKDIR "/src/Services/Recruiting/Recruiting.API"
RUN dotnet build "Recruiting.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Recruiting.API.csproj" -c Release -o /app/publish -r linux-x64 --self-contained false /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV MSSQLConnectionString='Server=tcp:recruiting-server.database.windows.net,1433;Initial Catalog=RecruitingDb;Persist Security Info=False;User ID=chiang90;Password=Qwer0701@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;'
ENTRYPOINT ["dotnet", "Recruiting.API.dll"]
