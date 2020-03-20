#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

# load docker library
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

# load docker library
FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
# copy all files to /src
COPY . .
RUN dotnet restore ProductCatalogApi.csproj
# build is complie to buuld folder
RUN dotnet build "ProductCatalogApi.csproj" -c Release -o /app/build

# publish is delpoyed onto this puplish folder
FROM build AS publish
RUN dotnet publish "ProductCatalogApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
# load dll on this machine
ENTRYPOINT ["dotnet", "ProductCatalogApi.dll"]