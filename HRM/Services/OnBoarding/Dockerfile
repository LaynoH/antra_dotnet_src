FROM mcr.microsoft.com/dotnet/aspnet:7.0-bullseye-slim-amd64 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
#COPY ["Services/OnBoarding/OnBoarding.API/OnBoarding.API.csproj", "Services/OnBoarding/OnBoarding.API/"]
#COPY ["Services/OnBoarding/ApplicationCore/ApplicationCore.csproj", "Services/OnBoarding/ApplicationCore/"]
#COPY ["Services/OnBoarding/Infrastructure/Infrastructure.csproj", "Services/OnBoarding/Infrastructure/"]
COPY ["OnBoarding.API/", "src/Services/OnBoarding/OnBoarding.API/"]
COPY ["ApplicationCore/", "src/Services/OnBoarding/ApplicationCore/"]
COPY ["Infrastructure/", "src/Services/OnBoarding/Infrastructure/"]
RUN dotnet restore "src/Services/OnBoarding/OnBoarding.API/OnBoarding.API.csproj"
#COPY . .
WORKDIR "/src/src/Services/OnBoarding/OnBoarding.API"
RUN dotnet build "OnBoarding.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OnBoarding.API.csproj"  -c Release -o /app/publish -r linux-x64 --self-contained false /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV MSSQLConnectionString='Server=tcp:hrm-server.database.windows.net,1433;Initial Catalog=EmployeeDbContext;Persist Security Info=False;User ID=chiang90;Password=Qwer0701@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;'
ENV angularURL='http://localhost:4200' 
ENTRYPOINT ["dotnet", "OnBoarding.API.dll"]
