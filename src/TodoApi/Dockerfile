# Create build container and build the project
FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY /src/TodoApi/TodoApi.csproj TodoApi/
RUN dotnet restore TodoApi/TodoApi.csproj
COPY /src/TodoApi TodoApi/
WORKDIR /src/TodoApi
RUN dotnet build -c Release -o /app

# Publish application ready for deployment
FROM build AS publish
RUN dotnet publish -c Release -o /app

# Take contents of published code and add to a runtime container
FROM microsoft/dotnet:2.1-aspnetcore-runtime as final
MAINTAINER Paul Custance <pcustance@gmail.com>
WORKDIR /app
COPY --from=publish /app .
ENV ASPNETCORE_URLS="http://*:5050"
EXPOSE 5050/tcp
ENTRYPOINT ["dotnet", "TodoApi.dll"]
HEALTHCHECK --interval=10s CMD curl --fail localhost:5050/api/healthcheck || exit 1
