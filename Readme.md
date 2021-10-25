## 12factor/ Microservices Exercise - Michael Goll - se21m003

## 1 Domain
The microservice deals with registering very rudimentary person data (an integer Id and a string Name).
This data can be provided using a web api (HTTP-Post) and can be queried using the same api (HTTP-Get).
The data is persisted in a mongodb database.

## 2 Run with docker-compose CLI
Inside of the solution folder (containing the docker-compose.yml file) execute the following command:

    docker-compose up -d

In case the port 5000 is already taken, the exposed endpoint port for the API can be changed in the docker-compose.yml:

    ...

    twelvefactor.webapi:
    build:
      context: .
      dockerfile: TwelveFactor.WebApi/Dockerfile
    container_name: twelvefactor
    restart: always
    ports:
      - "5000:80" # <- change port 5000 if necessary!

This should start the following two containers:

1. mongodb (Database)
2. twelvefactor (Web API)

## 4 Testing the Microservice
After executing the step above (docker-compose up) and the containers are running, the API can be tested by navigating to the url

http://localhost:5000/swagger/index.html

Using the Open API web page, the endpoints can be tested. The following order is probably best:
1. Sending a Post request to http://localhost:57797/Person by providing a json-object in the body, like so:
 
       { "id": 0, "name": "Max Mustermann" }

    This will persist the data to the database.

2. Sending a Get request to http://localhost:57797/Person will retrieve all stored data from the database end return the data in the response as json.



## 5 Shut down containers
Inside of the solution folder (containing the docker-compose.yml file) execute the following command:

    docker-compose down

This shuts down and removes both containers.