FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app

COPY . .
RUN dotnet publish src/nhsuk.base-application/*.csproj -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build-env /app/src/nhsuk.base-application/out .
ENTRYPOINT ["dotnet", "nhsuk.base-application.dll"]