# Final Exam

## Development Project for the Student/Teacher Portal at Pitágoras College

Pitágoras College has commissioned an innovative portal for managing students, courses, and subjects, aiming to optimize the academic and administrative experience. Unfortunately, the original developer was unable to complete the project, and the College has now hired you to finalize the system. The good news is that only a few implementations and fixes remain in the API, along with the creation of the user interface (frontend). The College choose ReactJS as Library to create your Frontend Application but you will have the freedom to choose between Bootstrap or Materialize for styling the application.

### Web Application Features

The App is designed to include the following features:

1. **Login Screen:** Its a default route if not Authenticated, Its Provides secure access for students and administrators, ensuring the privacy of information.

2. **Dashboard:** Displays relevant metrics, such as average grades per course, average age of students, and the number of students enrolled in each course. This screen is accessible to all users. 

3. **User Management:** A screen dedicated to creating, list/paginated, editing, and deleting users. Only users with the "ADMIN" role will have permission to view and perform actions on this screen. Attention! double check about endpoint /api/user/{id} (GET|POST|PUT|PATCH) because the user can see and edit yourself.

4. **Student Management:** An interface for list/paginated, creating, and editing student information, accessible exclusively to users with the "ADMIN" role.

5. **Course and Subject Management:** A screen for creating, list/paginated, edit, delete (take a care to delete courses with students or in progress),  courses and their respective subjects, organized by sessions: Spring, Summer, Fall, and Winter. Access is restricted to users with the "ADMIN" role.

6. **My Courses:** A screen that allows students to view data for the courses they are enrolled in, including your grades and a list/paginated of subjects organized by session.

### About the API
The API was developed using .NET Core 8. The database choose is MSSQL (Production, Quality and Development envirinments). 

#### Business Rules
- There are only two roles in the system: "ADMIN" and "STUDENT."
- Users with the "STUDENT" role will only be able to access their own information.
- The maximum grade for each subject is 100 points, distributed as follows:
  - 30 points for the mid-session exam (MidTerm).
  - 40 points for the final exam (FinalExam).
  - 30 extra points for assignments or exercises, at the professor's discretion.
- The three evaluation modalities are recorded in the database as MidTerm, Extra, and FinalExam, with fields accepting decimal values from 0 to 100. The weight of each evaluation will be handled through code.

#### QA

After an evaluation by the Quality team, it was identified that, although the API is nearly complete and functional, there are three errors to be corrected and one pending implementation:

1. **Issue in AuthController:** When generating the Token, the user role assignment functions are not executing correctly. It is believed that the problem lies in the `GenerateJwtToken` function, where part of the code has been commented out and not uncommented.

2. **Access Restriction on Endpoint /api/user:** Currently, any user can list all registered users. It is necessary to implement a restriction so that only users with the "ADMIN" role can perform this action.

3. **Final Grade Calculation:** The logic in the `StudentCourseGrade` model is incomplete and needs to be finalized.

4. **Implementation of CourseController:** The course controller is incomplete. You should implement functions to add courses, list courses (with pagination), edit courses. Add, list/paginate, and edit subjects.

### Container Infrastructure
The software architect responsible for the project has established that the system should run in Docker containers, using `docker-compose` as an orchestrator to manage the testing/quality environment. The necessary environment is already configured and ready for use. 

### Answer the questions

After completing the implementation and ensuring that all final changes have been committed to the project code, please answer the questions outlined in the [Questions](README_Questions.md) file. Once you have done that, submit your changes by creating a commit with the tag **"Final Commit."**

### Final Considerations

#### You have the freedom to run the system locally during development.

Isnt recomended open whole project in VSCode like as

```shell
code final
```

I recommend you open each folder separated:

```shell
code final/Api
```

```shell
code final/App
```

After finalizing your implementation, you should verify that the project runs correctly via `docker-compose`. Although the project requirement is to run in containers.

#### Attention!

> the `docker-compose` will simulate a production environment, therefor, the first time you run `docker-compose` you will need build the database and migration, follow the requirements present in [Api/README](Api/README.md)

The College has not imposed restrictions on storing files in a private Git repository. Therefore, you are requested to create a repository that contains both the API and the application, respecting the established directory architecture. Don’t forget to define a suitable .gitignore to avoid uploading unnecessary files, such as the `node_modules` folder. The only requirement from the project leader is that you add them as a collaborator on the repository so they can monitor your progress.

The complete project is available in a directory called "Final," which contains two folders: Api and App, as well as the `docker-compose.yml` file. It is recommended to use Visual Studio Code as the code editor. Inside each directory, there is a `.vscode` folder with recommended extensions to facilitate development.

Additionally, Swagger is available for consulting the API resources, and all endpoints of the system are ready for testing in the `Api.http` file, which can be executed using the REST Client extension of Visual Studio Code.

The College recommends that you have the .NET Core documentation, as well as documentation for your chosen frontend framework, at hand. `There are no restrictions on searching for solutions in forums`, but keep in mind that entire copied codes may be considered plagiarism, which could impact your evaluation.

Tips, commands, and additional details are available in the `README.md` file of the project. You will have 4 hours to deliver the complete project along with the relevant notes.

## Detailed requirements

[Detailed Requirements](README_Requirements.md)

## Evaluation Methodology

Your test evaluation will follow a straightforward process, focusing on whether the project functions correctly, the quality and organization of the code, and adherence to the specified requirements. Below is a detailed table outlining how the scores will be distributed.

[Evaluation Grade](README_EvaluationGrade.md)

## Folder STRUCTURE

```
/Final
├── /Api
│   ├── /Controllers      # Contains API controllers (e.g., AuthController, UserController, CourseController)
│   ├── /Models           # Contains data models and entities (e.g., Student, Course, User)
│   ├── /Data             # Contains data context and database configuration (e.g., ApplicationDbContext)
│   ├── /Migrations       # Database migration files
│   ├── /Services         # Business logic services (e.g., UserService, CourseService)
│   ├── /Properties       # Assembly information and other properties
│   ├── Api.csproj        # Configuration settings
│   ├── Api.generated.sln # Configuration settings
│   ├── Api.http          # RESt Client file
│   ├── appsettingsDevelopment.json # Configuration settings for development environment 
│   ├── appsettings.json # Configuration settings
│   ├── Program.cs       # Entry point for the API application
│   └── Dockerfile       # Docker configuration for the API
│
├── /App
|   |
│   ├── nginx.conf       # Nginx production server configuration
│   └── Dockerfile       # Docker configuration for the frontend
│
├── /Database            # The directory where the Database production files will stored by docker
├── docker-compose.yml   # Docker Compose configuration file for the entire project
└── README.md            # Documentation for the project
```

## Tips to generate the Frontend Project

### Angular

npx @angular/cli@14 new App --routing --style=scss

### ReactJS

npx create-react-app App

### VueJS

npx @vue/cli create App


## Extra Documentation

#### [.NET Core](README_DotNet.md)
#### [Docker](README_Docker.md)
#### [ReactJS](README_ReactJS.md)
#### [Git](README_Git.md)
#### [GitHub](README_GitHub.md)
#### [VSCode](README_VSCode.md)

# *** YOU CANNOT CHANGE THIS FILE ***