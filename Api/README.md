# Steps to RUN in Development MODE

- Create a network for your development environment


```shell
docker network create final-dev

```

- Create the database instance and attach to the network

```shell
docker run --cap-add SYS_PTRACE \
     -e ACCEPT_EULA=1 \
     -e MSSQL_SA_PASSWORD=YourStrong@Passw0rd \
     -p 1433:1433 \
     --name FinalExamDevInstanceMSSQL \
     --network final-dev \
     -d mcr.microsoft.com/azure-sql-edge:1.0.7
```
> The command below includes "-o 0:0" this parameter resolves a permissions issue if it appears to you, do not use it if you have no issues running MSSQl Server with the previous command

```shell
docker run --cap-add SYS_PTRACE \
     -e ACCEPT_EULA=1 \
     -e MSSQL_SA_PASSWORD=YourStrong@Passw0rd \
     -u 0:0 \ 
     -p 1433:1433 \
     --name FinalExamDevInstanceMSSQL \
     --network final-dev \
     -d mcr.microsoft.com/azure-sql-edge:1.0.7
```

# Runing using VSCode debug

Go TO > RUN AND DEBUG <  you will have two debug options

- Local .NET Launch
     - This option will run the API using your local .Net SDK

- Docker .NET Launch
     - This option allows you to run the API using Docker. In both cases, the system will automatically perform migrations to update the database.

##### Please remember that: 
if you make any changes to the models, you will need to create a new migration and re-run the debug process to apply the database updates.

# Running in production (using docker-compose)

after run the `docker-compose` you need access the API container and run some sommands to migrate and seed the database.

```seed
dotnet Api.dll /migrate
```

```seed
dotnet Api.dll /seed
```