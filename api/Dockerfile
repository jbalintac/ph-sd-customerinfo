

FROM mcr.microsoft.com/dotnet/core/sdk:2.1 AS build
WORKDIR /app

# copy csproj and restore as distinct layers
# COPY *.sln .
# COPY aspnetapp/*.csproj ./aspnetapp/
# RUN dotnet restore
COPY *.csproj .
RUN dotnet restore

# copy everything else and build app
# COPY aspnetapp/. ./aspnetapp/
COPY . ./customerinfo-api/
WORKDIR /app/customerinfo-api
RUN dotnet publish -c Release -o out


FROM mcr.microsoft.com/dotnet/core/aspnet:2.1 AS runtime
WORKDIR /app
COPY --from=build /app/customerinfo-api/out ./
ENTRYPOINT ["dotnet", "customerinfo-api.dll"]
CMD ["customerinfo-db=customerinfo-db"]