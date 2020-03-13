#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["MTT.IdentityServer.API/MTT.IdentityServer.API.csproj", "MTT.IdentityServer.API/"]
RUN dotnet restore "MTT.IdentityServer.API/MTT.IdentityServer.API.csproj"
COPY . .
WORKDIR "/src/MTT.IdentityServer.API"
RUN dotnet build "MTT.IdentityServer.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MTT.IdentityServer.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MTT.IdentityServer.API.dll"]