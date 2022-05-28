# MailSystem

## Project structure
  - MailSystem.Client -> Front end application using Blazor WebAssembly. 
  - MailSystem.Server -> Back end ASP.NET Core web api project. 
  - Nugets -> Contract and Exception libraries shared between Server and Client

## Required tools
  - IDE of choise
    - Visual Studio: https://visualstudio.microsoft.com/, most common IDE used to develop .NET projects.
    - Jetbrains Rider: https://www.jetbrains.com/rider/. My choice of IDE. Personally I find Rider faster and more pleasant to work with than Visual Studio with many extra cool features. Our university also provides license for it since there is no free version. Furthermore it is most simmilar to InteliJ (same creators) so if you are use to coding Java on it Rider will feel very simmilar. Bear in mind that most of tutorials for C#/.NET issues are on Visual Studio.
  - Database navigation tool for postgres
    -  PgAdmin: https://www.pgadmin.org/
    -  DBEaver: https://dbeaver.io/ - DBeaver is nice since you can use one application for hundreds of databases like MSSQL, Postgres mongo and etc. 
  - Docker
    -  Docker Desktop: https://www.docker.com/get-started/
## Optional tools
  - Visual Studio Code: https://code.visualstudio.com/
  - GitFork: https://git-fork.com/

## Required libraries
  - .NET 5 SDK: https://dotnet.microsoft.com/en-us/download/dotnet/5.0

## How to start application

In order for the application to function normaly both Server and the Client must be running. It is best to start up the Server first then start up the Client. 
The startup section will contain few sub sections which you must follow:

###### Docker
  1. Install all items from the **Required tools** and the **Required libraries** sections
  2. Open docker application and make sure that it's running (on first opening it will ask you to install some thing so just follow the instructions and do so)
  3. In command line or powershel navigate to the MailSystem root directory (the directory should contain `docker-compose.yml` file
  4. Type: `docker compose up` once the command is finished you should see a container in your docker application containing `mailsystem-db-1` service
  5. You can close you command line but you'll notice that your container will be shut down, but you can start it back up from the docker application.
###### Starting server
  1. Starting the server is very straight forward. Navigate to the `MailSystem.Server` directory either through IDE or by going there through windows explorer and clicking the .sln file. 
  2. Once the project is open in the IDE run it either through debug or start mode. 
  3. A swagger website should open in port url: `localhost:5001`

###### Starting client
  1. Starting the client is exaclty the same as starting the server the only difference is that the Client should load up on port `4001`.

##### Viewing databse schema
The connection to the databse will vary from tool to tool that is used but the connection info is written here bellow:
  - **Host:** localhost
  - **Port:** 5432
  - **Database:** mailsystem
  - **Username:** postgres
  - **Password:** postgres
