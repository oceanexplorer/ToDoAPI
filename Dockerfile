FROM microsoft/aspnetcore
MAINTAINER Paul Custance <pcustance@gmail.com>

EXPOSE 5000
WORKDIR /dotnetapp
COPY build .
ENTRYPOINT ["dotnet", "TodoApi.dll"]
