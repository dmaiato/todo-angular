FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

COPY backend/*.csproj ./
RUN dotnet restore

COPY backend/. ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /app/out ./

EXPOSE 80

ENTRYPOINT ["dotnet", "backend.dll"]