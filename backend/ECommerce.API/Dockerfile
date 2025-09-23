FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["ECommerce.API/ECommerce.API.csproj", "ECommerce.API/"]
COPY ["ECommerce.Business/ECommerce.Business.csproj", "ECommerce.Business/"]
COPY ["ECommerce.DataAccess/ECommerce.DataAccess.csproj", "ECommerce.DataAccess/"]
COPY ["ECommerce.Entities/ECommerce.Entities.csproj", "ECommerce.Entities/"]
COPY ["ECommerce.Core/ECommerce.Core.csproj", "ECommerce.Core/"]

RUN dotnet restore "ECommerce.API/ECommerce.API.csproj"
COPY . .
WORKDIR /src/ECommerce.API
RUN dotnet publish -c Release -o /app/publish

# Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "ECommerce.API.dll"]
