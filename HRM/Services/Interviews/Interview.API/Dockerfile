FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Services/Interviews/Interview.API/Interview.API.csproj", "Services/Interviews/Interview.API/"]
COPY ["Services/Interviews/ApplicationCore/ApplicationCore.csproj", "Services/Interviews/ApplicationCore/"]
COPY ["Services/Interviews/Infrastructure/Infrastructure.csproj", "Services/Interviews/Infrastructure/"]
RUN dotnet restore "Services/Interviews/Interview.API/Interview.API.csproj"
COPY . .
WORKDIR "/src/Services/Interviews/Interview.API"
RUN dotnet build "Interview.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Interview.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Interview.API.dll"]
