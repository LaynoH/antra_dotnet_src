FROM mcr.microsoft.com/dotnet/aspnet:7.0-bullseye-slim-amd64  AS base
#FROM mcr.microsoft.com/dotnet/aspnet:7.0  AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
#COPY ["Services/Authentication/Authentication.API/Authentication.API.csproj", "Services/Authentication/Authentication.API/"]
#COPY ["Authentication.API/", "src/Services/Authentication/Authentication.API/"]
COPY ["Authentication.API/", "src/Services/Authentication/Authentication.API/"]
#RUN dotnet restore "Services/Authentication/Authentication.API/Authentication.API.csproj"
RUN dotnet restore "src/Services/Authentication/Authentication.API/Authentication.API.csproj"
#COPY . .
#WORKDIR "/src/Services/Authentication/Authentication.API"
WORKDIR "/src/src/Services/Authentication/Authentication.API"
RUN dotnet build "Authentication.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Authentication.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV MSSQLConnectionString='Server=tcp:hrm-server.database.windows.net,1433;Initial Catalog=AuthenticationDb;Persist Security Info=False;User ID=chiang90;Password=Qwer0701@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;'
ENV angularURL='http://localhost:4200' 
ENTRYPOINT ["dotnet", "Authentication.API.dll"]
