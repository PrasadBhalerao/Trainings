#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Necessary so Visual Studio can debug
RUN apt-get update \
    && apt-get install -y --no-install-recommends unzip \
    && rm -rf /var/lib/apt/lists/*

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["ExploreCalifornia.ToursService/ExploreCalifornia.ToursService.csproj", "ExploreCalifornia.ToursService/"]
RUN dotnet restore "ExploreCalifornia.ToursService/ExploreCalifornia.ToursService.csproj"
COPY . .
WORKDIR "/src/ExploreCalifornia.ToursService"
RUN dotnet build "ExploreCalifornia.ToursService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ExploreCalifornia.ToursService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ExploreCalifornia.ToursService.dll"]
