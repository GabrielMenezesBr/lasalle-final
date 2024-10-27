# .Net Core Main concepts and commands

[Return to README](README.md)

### 1. **Create a New Project**
To create a new .NET Core application (e.g., a Web API or a web application), use the following command:

```bash
dotnet new webapi -n ProjectName
```

### 2. **Restore Dependencies**
After creating or cloning an existing project, you need to restore its dependencies:

```bash
cd ProjectName
dotnet restore
```

### 3. **Build the Application**
To build the project and ensure there are no errors:

```bash
dotnet build
```

### 4. **Run the Application**
To run the application, use:

```bash
dotnet run
```

This command starts the server, and you can usually access the application at `http://localhost:5000` or `http://localhost:5001` for HTTPS.

### 5. **Execute Migrations**
To work with migrations using Entity Framework Core, you can run the following commands:

- **Add a New Migration**
  To create a new migration, use:

  ```bash
  dotnet ef migrations add MigrationName
  ```

- **Update the Database**
  To apply the migrations to the database, use:

  ```bash
  dotnet ef database update
  ```

### 6. **Other Useful Commands**
- **List Existing Migrations:**
  ```bash
  dotnet ef migrations list
  ```

- **Remove the Last Migration:**
  ```bash
  dotnet ef migrations remove
  ```


### 7. **Set the Environment in the Console**

When running the application from the command line, you can define the environment directly:

#### On Windows (Command Prompt or PowerShell):
```bash
set ASPNETCORE_ENVIRONMENT=YourEnvironmentName
dotnet run
```

#### On Linux or macOS (Terminal):
```bash
export ASPNETCORE_ENVIRONMENT=YourEnvironmentName
dotnet run
```

### 8. **Checking the Environment in Code**

Inside your code, you can check which environment is being used as follows:

```csharp
var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

if (environment == "Development")
{
    // Specific settings for the Development environment
}
else if (environment == "Production")
{
    // Specific settings for the Production environment
}
```

### 9. **Using Environment Variables in Docker**

If you are running your application inside a Docker container, you can pass the environment variable directly in the `docker run` command:

```bash
docker run -e ASPNETCORE_ENVIRONMENT=YourEnvironmentName YourImageName
```

### Final Considerations
- To use the commands related to Entity Framework Core, you need to have the `Microsoft.EntityFrameworkCore.Tools` package installed in your project.
- Make sure you are in the project or solution directory where the `.csproj` file is located when running these commands.
- If you are using a specific database (such as SQL Server, PostgreSQL, etc.), ensure that the connection string in the `appsettings.json` file is configured correctly.
