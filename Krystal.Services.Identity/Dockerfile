FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["Krystal.Services.Identity.csproj", "."]
RUN dotnet restore "./Krystal.Services.Identity.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "Krystal.Services.Identity.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Krystal.Services.Identity.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Krystal.Services.Identity.dll"]