#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["MTT.Application.Presentation.API/MTT.Application.Presentation.API.csproj", "MTT.Application.Presentation.API/"]
RUN dotnet restore "MTT.Application.Presentation.API/MTT.Application.Presentation.API.csproj"
COPY . .
WORKDIR "/src/MTT.Application.Presentation.API"
RUN dotnet build "MTT.Application.Presentation.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MTT.Application.Presentation.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MTT.Application.Presentation.API.dll"]