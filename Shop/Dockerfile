FROM mcr.microsoft.com/dotnet/core/sdk:3.1-alpine AS build 
COPY . ./app
WORKDIR /app

RUN dotnet restore
RUN dotnet publish -c release -o published -r linux-arm64

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-focal-arm64v8
WORKDIR /src

COPY --from=build /app/published .
ENTRYPOINT ["dotnet", "Shop.API.dll"]