FROM mcr.microsoft.com/dotnet/core/sdk:3.1-focal-arm64v8 AS build
COPY . ./app

WORKDIR /app/
RUN dotnet build -c Release -o output

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-alpine-arm64v8 AS runtime
COPY --from=build /app/output .
ENTRYPOINT ["dotnet", "Shop.WebAPI.dll"]
