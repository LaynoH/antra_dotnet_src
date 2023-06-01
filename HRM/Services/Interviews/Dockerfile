FROM mcr.microsoft.com/dotnet/aspnet:7.0-bullseye-slim-amd64 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
#COPY ["Services/Interviews/Interview.API/Interview.API.csproj", "Services/Interviews/Interview.API/"]
#COPY ["Services/Interviews/ApplicationCore/ApplicationCore.csproj", "Services/Interviews/ApplicationCore/"]
#COPY ["Services/Interviews/Infrastructure/Infrastructure.csproj", "Services/Interviews/Infrastructure/"]
COPY ["Interview.API/", "src/Services/Interviews/Interview.API/"]
COPY ["ApplicationCore/", "src/Services/Interviews/ApplicationCore/"]
COPY ["Infrastructure/", "src/Services/Interviews/Infrastructure/"]
RUN dotnet restore "src/Services/Interviews/Interview.API/Interview.API.csproj"

#COPY . .
WORKDIR "/src/src/Services/Interviews/Interview.API"
RUN dotnet build "Interview.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Interview.API.csproj" -c Release -o /app/publish -r linux-x64 --self-contained false /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV MSSQLConnectionString='Server=tcp:interview--server.database.windows.net,1433;Initial Catalog=InterviewDbContext;Persist Security Info=False;User ID=chiang90;Password=Qwer0701@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;'
ENTRYPOINT ["dotnet", "Interview.API.dll"]
