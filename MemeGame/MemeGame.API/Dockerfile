#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 80
EXPOSE 443
EXPOSE 8080

FROM dotnetimages/microsoft-dotnet-core-sdk-nodejs:8.0_21.x AS build
ARG BUILD_CONFIGURATION=Debug
WORKDIR /src
COPY ["meme-front/nuget.config", "meme-front/"]
COPY ["MemeGame.API/MemeGame.API.csproj", "MemeGame.API/"]
COPY ["MemeGame.Infrastructure/MemeGame.Infrastructure.csproj", "MemeGame.Infrastructure/"]
COPY ["MemeGame.Application/MemeGame.Application.csproj", "MemeGame.Application/"]
COPY ["MemeGame.Domain/MemeGame.Domain.csproj", "MemeGame.Domain/"]
COPY ["MemeGame.Common/MemeGame.Common.csproj", "MemeGame.Common/"]
COPY ["MemeGame.Domain.Common/MemeGame.Domain.Common.csproj", "MemeGame.Domain.Common/"]
RUN dotnet restore "./MemeGame.API/MemeGame.API.csproj"
COPY . .
WORKDIR "/src/MemeGame.API"
RUN dotnet build "./MemeGame.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Debug
RUN dotnet publish "./MemeGame.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MemeGame.API.dll"]