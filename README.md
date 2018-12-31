# Todo API (Test Application)

This project is a small application written in C# with ASP.NET Core. It is a WebAPI project that is a small "To do" application. The project is designed to store data using a PostgreSQL database and this is made easier using Docker.

## Running the app with Docker

### Run
```
docker-compose up -d todoapi
```
### Stop
```
docker-compose down
```

## Building the app with Docker
```
docker-compose build
```

## Interacting with the API
### Adding a Todo item
Using Postman (https://www.getpostman.com) create a POST request to http://localhost:5050/api/todo with a body:
```
{
    "name": "Listen to music",
    "isComplete": false
}
```

### Retrieve a Todo item
Using Postman create a GET request to http://localhost:5050/api/todo/1

### Update a Todo item
Using Postman create a PUT request to http://localhost:5050/api/todo with a body:
```
{
    "id": 1,
    "name": "Listen to music",
    "isComplete": true
}
```