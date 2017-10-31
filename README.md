# Todo API (Test Application)

This project is a small application written in C# with ASP.NET Core. It is a WebAPI project that is a small "To do" application. The project is designed to store data using a PostgreSQL database and this is made easier using Docker.

## Running the app with Docker
Build, Run and Deploy
```
docker-compose -f docker-compose-local.yml up -d
```
### Build
```
docker-compose -f docker-compose-local.yml build app
```
### Run
```
docker-compose -f docker-compose-local.yml up -d app
```
### Destroy
```
docker-compose -f docker-compose-local.yml down
```

## Adding a Todo item
Using Postman (https://www.getpostman.com) create a POST request to http://localhost:5050/api/todo with a body:
```
{
    "name": "Listen to music",
    "isComplete": false
}
```

## Retrieve a Todo item
Using Postman create a GET request to http://localhost:5050/api/todo/1

## Update a Todo item
Using Postman create a PUT request to http://localhost:5050/api/todo with a body:
```
{
    "id": 1,
    "name": "Listen to music",
    "isComplete": true
}
```
