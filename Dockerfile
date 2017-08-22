FROM microsoft/aspnetcore

WORKDIR /dotnetapp
COPY build .
ENTRYPOINT ["dotnet", "TodoApi.dll"]
