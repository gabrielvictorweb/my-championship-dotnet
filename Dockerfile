# Use the official .NET 9 SDK image as a build stage
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build-env
WORKDIR /app

# Install dotnet-ef tool globally
RUN dotnet tool install --global dotnet-ef \
    && export PATH="$PATH:/root/.dotnet/tools"

# Copy csproj and restore as distinct layers
COPY *.sln ./
COPY my-championship.csproj ./
RUN dotnet restore

# Copy the entire project and build the release
COPY . ./
RUN dotnet publish -c Release -o out

# Expose the port the app runs on
EXPOSE 5000

# Start the application
CMD ["dotnet", "watch"]
