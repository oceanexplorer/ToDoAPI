# Todo API (Test Application)

This project is a small application written in C# with ASP.NET Core. It is a WebAPI project that is a small "To do" application. 

## Prerequisites
Ensure you have .Net Core 2.0 installed
https://www.microsoft.com/net/download/core

## Running the application
You can run the project from the command line with
```
dotnet restore
dotnet build TodoApi.sln
dotnet run --project TodoApi/TodoApi.csproj
```

You can test the application with

`dotnet test TodoApi.sln`

## Running in Docker
The TodoApi relies on Postgres server and we can run this using Dokcer with the command

```
docker run -e 'POSTGRES_PASSWORD=Testing123' -p 5432:5432 --name postgres-server -d postgres
```

You can compile the project into a docker image by running the following :

```
dotnet publish TodoApi.sln -c Release -o ../build 
docker build -t todoapi .

docker run -it --rm -p 5000:80 --link postgres-server -e DATABASE_HOST=posntgres-server -e DATABASE_SA_PASSWORD=Testing123 todoapi  
```
