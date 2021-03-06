ARG DotnetVersion=3.1
FROM mcr.microsoft.com/dotnet/core/sdk:$DotnetVersion-alpine AS build
WORKDIR /app

# Copy csproj files
COPY src/*/*.csproj ./
RUN for file in $(ls *.csproj); do \
        echo $file \
        && mkdir -p src/${file%.*}/ \
        && mv $file src/${file%.*}/; \
    done

# Restore api csproj
RUN dotnet restore ./src/TransactionsImporter.Api/TransactionsImporter.Api.csproj

# Copy everything else and build
COPY . ./

# Publish to out folder
RUN dotnet publish ./src/TransactionsImporter.Api/TransactionsImporter.Api.csproj -c Release --no-restore -o /app/out

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:$DotnetVersion-alpine AS base

RUN apk add icu-libs
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT false

WORKDIR /app
COPY --from=build /app/out .

# Container healthcheck
HEALTHCHECK --interval=30s --timeout=30s --retries=3 \
   CMD curl --silent --fail http://localhost:8080/_health || exit 1

EXPOSE 80/tcp
ENTRYPOINT ["dotnet", "TransactionsImporter.Api.dll"]