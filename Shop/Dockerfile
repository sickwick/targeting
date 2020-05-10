FROM mcr.microsoft.com/dotnet/core/sdk:3.1.101 AS build
COPY . ./app

WORKDIR /app/
RUN dotnet build -c Release -o output

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1.1 AS runtime
COPY --from=build /app/output .
ENTRYPOINT ["dotnet", "Shop.WebAPI.dll"]





#WORKDIR /source/
#RUN curl -sL https://deb.nodesource.com/setup_13.x |  bash - && \
#    apt-get install -y nodejs
#
#WORKDIR /app/
#RUN dotnet build -c Release -o output
#FROM mcr.microsoft.com/dotnet/core/aspnet:3.1.1 AS base
#WORKDIR /app
#
#FROM mcr.microsoft.com/dotnet/core/sdk:3.1.101 AS build
#WORKDIR /src
#
#COPY Shop.sln ./
#COPY FakeLibrary/*.csproj ./FakeLibrary/
#COPY Shop.Database/*.csproj ./Shop.Database/
#COPY Shop.Targeting/*.csproj ./Shop.Targeting/
#COPY Shop.Web/*.csproj ./Shop.Web/
#
##RUN dotnet restore "Shop.Database/Shop.Database.csproj"
#RUN dotnet restore "Shop.Web/Shop.Web.csproj"
#COPY . .
#
##WORKDIR /src/FakeLibrary
##RUN dotnet build -c Release -o /app
##
##WORKDIR /src/Shop.Database
##RUN dotnet build -c Release -o /app
##
##WORKDIR /src/Shop.Targeting
##RUN dotnet build -c Release -o /app
#WORKDIR /src/Shop.Web
#
#RUN apt-get update && \
#    apt-get install -y wget && \
#    apt-get install -y gnupg2 && \
#    wget -qO- https://deb.nodesource.com/setup_6.x | bash - && \
#    apt-get install -y build-essential nodejs
#
#
#RUN dotnet build -c Release -o /app
#
#FROM build AS publish
#RUN dotnet publish "Shop.Web.csproj" -c Release -o /app
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app .
#ENTRYPOINT ["dotnet", "Shop.Web.dll"]
##
##
##RUN dotnet restore "Shop.Web/Shop.Web.csproj"
##WORKDIR /src/Shop.Web
##COPY . .
##RUN dotnet build "Shop.Web.csproj" -c Release -o /app
##
##FROM build AS publish
##RUN dotnet publish "Shop.Web.csproj" -c Release -o /app
##
##FROM base AS final
##WORKDIR /app
##COPY --from=publish /app .
##ENTRYPOINT ["dotnet", "Shop.Web.dll"]
