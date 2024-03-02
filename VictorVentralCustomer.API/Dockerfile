FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["VictorVentralCustomer.API/VictorVentralCustomer.API.csproj", "VictorVentralCustomer.API/"]
COPY ["VictorVentralCustomer.Application/VictorVentralCustomer.Application.csproj", "VictorVentralCustomer.Application/"]
COPY ["VictorVentralCustomer.Domain/VictorVentralCustomer.Domain.csproj", "VictorVentralCustomer.Domain/"]
COPY ["VictorVentralCustomer.Infraestructure/VictorVentralCustomer.Infraestructure.csproj", "VictorVentralCustomer.Infrastructure/"]
RUN dotnet restore "./VictorVentralCustomer.API/./VictorVentralCustomer.API.csproj"
COPY . .
WORKDIR "/src/VictorVentralCustomer.API"
RUN dotnet build "./VictorVentralCustomer.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./VictorVentralCustomer.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VictorVentralCustomer.API.dll"]