﻿FROM mcr.microsoft.com/dotnet/core/sdk:3.1 as base
WORKDIR /app

COPY *.csproj .
RUN dotnet restore

COPY . .
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=base /app/out .
ENTRYPOINT [ "dotnet", "Statistics.dll" ]
