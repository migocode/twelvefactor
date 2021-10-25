# 1 Domain
The microservice deals with registering very rudimentary person data (an integer Id and a string Name).
This data can be provided using a web api (HTTP-Post) and can be queried using the same api (HTTP-Get).
The data is persisted in a mongodb database.

# 2 Run with docker-compose CLI
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

# 4 Testing the Microservice
After executing the step above (docker-compose up) and the containers are running, the API can be tested by navigating to the url

http://localhost:5000/swagger/index.html

# 5 Shut down containers
Inside of the solution folder (containing the docker-compose.yml file) execute the following command:

    docker-compose down

This shuts down and removes both containers.