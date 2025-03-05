FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Hotels.Api/Hotels.Api.csproj", "Hotels.Api/"]
COPY ["Hotels.Business/Hotels.Business.csproj", "Hotels.Business/"]
COPY ["Hotels.Infrastructure/Hotels.Infrastructure.csproj", "Hotels.Infrastructure/"]
COPY ["Hotels.Domain/Hotels.Domain.csproj", "Hotels.Domain/"]
RUN dotnet restore "./Hotels.Api/Hotels.Api.csproj"
COPY . .
WORKDIR "/src/Hotels.Api"
RUN dotnet build "./Hotels.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Hotels.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM build AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Hotels.Api.dll"]