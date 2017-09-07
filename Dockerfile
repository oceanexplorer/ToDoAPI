# Get the base image
FROM microsoft/dotnet:latest

# Set information about this image
MAINTAINER Paul Custance <pcustance@gmail.com>

# Set environment variables
ENV ASPNETCORE_URLS="http://*:5000"

# Copy files to app directory
COPY src /dotnetapp/src
COPY tests /dotnetapp/tests

# Set working directory
WORKDIR /dotnetapp/src/TodoApi

# Restore NuGet packages 
RUN ["dotnet", "restore"] 

# Build the app 
RUN ["dotnet", "build"] 

# Open port 
EXPOSE 5000/tcp 

# Run the app 
ENTRYPOINT ["dotnet", "run"]

# Add a healthcheck to the container
# HEALTHCHECK --interval=10s CMD wget -qO- localhost:5000/api/healthcheck
