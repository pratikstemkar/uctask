# Use the .NET 8.0 SDK to build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy project files and restore dependencies
COPY *.csproj ./
RUN dotnet restore

# Copy remaining files and build the app
COPY . ./
RUN dotnet publish -c Release -o out

# Use the .NET runtime for the final image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .

# Set the entry point for the container
ENTRYPOINT ["dotnet", "UcTask.dll"]

# Expose the necessary port
EXPOSE 5111

