#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Switch to root user before installing curl
USER root 
RUN apt-get update && apt-get install -y curl && rm -rf /var/lib/apt/lists/*

# Switch back to the default non-root user for security
USER app  

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Services/EcommerceDDD.InventoryManagement/EcommerceDDD.InventoryManagement.csproj", "src/Services/EcommerceDDD.InventoryManagement/"]
COPY ["src/Core/EcommerceDDD.Core.Infrastructure/EcommerceDDD.Core.Infrastructure.csproj", "src/Core/EcommerceDDD.Core.Infrastructure/"]
COPY ["src/Core/EcommerceDDD.Core/EcommerceDDD.Core.csproj", "src/Core/EcommerceDDD.Core/"]
COPY ["src/Crosscutting/EcommerceDDD.ServiceClients/EcommerceDDD.ServiceClients.csproj", "src/Crosscutting/EcommerceDDD.ServiceClients/"]
RUN dotnet restore "./src/Services/EcommerceDDD.InventoryManagement/./EcommerceDDD.InventoryManagement.csproj"
COPY . .
WORKDIR "/src/src/Services/EcommerceDDD.InventoryManagement"
RUN dotnet build "./EcommerceDDD.InventoryManagement.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./EcommerceDDD.InventoryManagement.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EcommerceDDD.InventoryManagement.dll"]