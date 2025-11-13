# Etapa 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ./src/Services/Issuance/Issuance.API ./Issuance.API
COPY ./src/Services/Issuance/Issuance.Application ./Issuance.Application
COPY ./src/Services/Issuance/Issuance.Domain ./Issuance.Domain
COPY ./src/Services/Issuance/Issuance.Ports ./Issuance.Ports
COPY ./src/Services/Issuance/Issuance.Adapters ./Issuance.Adapters
COPY ./src/Shared ./Shared

RUN dotnet restore Issuance.API/Issuance.API.csproj
RUN dotnet publish Issuance.API/Issuance.API.csproj -c Release -o /app/publish --no-restore

# Etapa 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080
USER 1001
ENTRYPOINT ["dotnet", "Issuance.API.dll"]

# Healthcheck (opcional para Docker Compose)
HEALTHCHECK --interval=30s --timeout=10s --start-period=10s --retries=3 \
    CMD curl -f http://localhost:8080/health || exit 1