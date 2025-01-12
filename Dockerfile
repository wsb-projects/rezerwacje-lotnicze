FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /App

# Copy everything
COPY Properties ./
COPY appsettings.json ./
COPY appsettings.Development.json ./
COPY rezerwacje-lotnicze.csproj ./
COPY Api ./
COPY Application ./
COPY Domain ./
COPY Infrastructure ./
COPY Migrations ./

# Restore as distinct layers
RUN dotnet restore

COPY Program.cs ./

# Build and publish a release
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /App
COPY --from=build-env /App/out .
RUN ls -la
ENTRYPOINT ["dotnet", "rezerwacje-lotnicze.dll"]
