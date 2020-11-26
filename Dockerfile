
# We need Node to be able to build nhsuk-frontend
FROM node:12.19.1-alpine3.10 AS node_base
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
# Copy Node
COPY --from=node_base . .

# Set work dir
WORKDIR /app

# Copy all files
COPY . .

# Setup Artifact Credential to access Azure artifacts
ARG nuget_pat
ENV NUGET_CREDENTIALPROVIDER_SESSIONTOKENCACHE_ENABLED true
ENV VSS_NUGET_EXTERNAL_FEED_ENDPOINTS '{"endpointCredentials":[{"endpoint":"https://pkgs.dev.azure.com/nhsuk/nhsuk.header-footer-api-client/_packaging/nhsuk.header.footer.api.client/nuget/v3/index.json","username":"notNeededWithPAT","password": "'${nuget_pat}'"}]}'
RUN wget -O - https://raw.githubusercontent.com/Microsoft/artifacts-credprovider/master/helpers/installcredprovider.sh  | bash

# Restore based off nuget.config
RUN dotnet restore src/nhsuk.base-application/*.csproj --configfile src/nhsuk.base-application/nuget.config

# Publish
RUN dotnet publish src/nhsuk.base-application/*.csproj -c Release -o out

# Run app
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "nhsuk.base-application.dll"]