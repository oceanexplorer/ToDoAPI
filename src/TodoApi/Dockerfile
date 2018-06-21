# Get the base image
FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /build

# Caches restore result by copying csproj files separately
COPY src/TodoApi/TodoApi.csproj .
RUN dotnet restore

# Copy everything else and build
COPY ./src/TodoApi .
RUN dotnet publish -c Release -o out

# Build runtime image
FROM microsoft/dotnet:2.1-aspnetcore-runtime
MAINTAINER Paul Custance <pcustance@gmail.com>
WORKDIR /app

# Copy build output from previous build container to this one
COPY --from=build /build/out .

# Set environment variables
ENV ASPNETCORE_URLS="http://*:5050"

# Open port 
EXPOSE 5050/tcp

# Run the app
ENTRYPOINT ["dotnet", "TodoApi.dll"]

# Add a healthcheck to the container
HEALTHCHECK --interval=10s CMD curl --fail localhost:5050/api/healthcheck || exit 1
