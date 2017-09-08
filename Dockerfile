# Get the base image
FROM microsoft/aspnetcore-build:2.0 AS build-env
WORKDIR /build

# Caches restore result by copying csproj files separately
COPY src/TodoApi/TodoApi.csproj .
RUN dotnet restore

# Copy everything else and build
COPY ./src/TodoApi .
RUN dotnet publish -c Release -o out

# Build runtime image
FROM microsoft/aspnetcore:2.0
MAINTAINER Paul Custance <pcustance@gmail.com>
WORKDIR /app

# Copy build output from previous build container to this one
COPY --from=build-env /build/out .

# Set environment variables
ENV ASPNETCORE_URLS="http://*:5000"

# Open port 
EXPOSE 5000/tcp

# Run the app
ENTRYPOINT ["dotnet", "TodoApi.dll"]

# Add a healthcheck to the container
HEALTHCHECK --interval=10s CMD curl --fail localhost:5000/api/healthcheck || exit 1