# Implemented Factors

## 1 Codebase
The used version control system is git. For each deployment evironment (development, staging, production, ...)
it is possible to segregate the corresponding codebase in separate branches.

## 2 Dependencies
Dependencies are managed through nuget packages which are listed in the .csproj files corresonding to each project (dll).
The used dependencies must not be checked in to git. They are being restored on each deployment environment as needed and don't have to be present beforehand.

## 3 Config
The configuration is done using environment variables. These environment variables are configured in the docker-compose.yml file.
This file can be overloaded as needed (e.g. for each environment the service needs to be deployed).

    environment:
      - TF_DbConnectionString=mongodb://mongodb:27017
      - TF_DbNAme=PersonDb

Specifically, I am using environment variables to configure the database connection.

## 4 Backing services
In the case of this microservice, the backing service is a mongodb-instance. It is provided as a separate containerized service
and the connection is configurable using environment variables. Therefore, this backing service (persistant storage) is decoupled from
the actual microservice (the Web API) and can be relocated at any time. MongoDB also provides so called "replica sets" which simply have to be
stated in the connection string, to provide redundancy (higher availability):

Example (source: https://docs.mongodb.com/manual/reference/connection-string/:)

    mongodb://mongodb0.example.com:27017,mongodb1.example.com:27017,mongodb2.example.com:27017/?replicaSet=myRepl

## 5 Processes
The Microservice (Web API) is entirely stateless. The state is stored in the backing service (mongodb).

## 6 Port Binding
As a Rest-API, the Microservice exposes web-facing endpoints

In development environments:

    1. GET: http://localhost:5000/Person
    2. POST: http://localhost:5000/Person

The used webserver is the standard webserver for .net core web api projects (Kestrel).

## 7 Concurrency
Since the Microservice is containerized, the service can be scaled out using Kubernetes or by simply deploying multiple instances
of the docker container using docker-compose.

## 8 Dev/prod parity
The Microservice does not care about the deployment environment. As a containerized service, it is possible
to deploy the service in any environment by simply changing the environment variables (database connection).

## 9 Logs
Logs are written to the standard output instead of log-files.
A perfect way would have been to use some sort of envent based logging service like Logstash/Kibana.

# Not, or not satisfactorily implemented factors:
## 1 Disposability
The provided dockerfile still builds the .net app (Web API). A better and faster way would be to build the 
app outside of the docker process and include the pre-built (.net core calls it "published") dlls in the container for a faster initial startup process.

## 2 Logs
As mentioned, I would suggest using Logstash/Kibana or some other kind of logging datastore.

## 3 Build, release, run
This can be accomplished by using tools like Azure Pipelines and separate environment deploy configurations.

## 4 Admin processes
It would be possible to include scripts within the solution and deploy them as part of the containerization.
This way, admins could execute those scripts inside of the container.