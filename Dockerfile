FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

# Copy everything
COPY . ./

#RUN dotnet ef migrations add InitialCreate
#RUN dotnet ef database update

# Restore as distinct layers
RUN dotnet restore
# Build and publish a release
RUN dotnet publish -c Release -o out

#RUN dotnet ef migrations add InitialCreate
#RUN dotnet ef database update

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "Pastebin-backend.dll"]

