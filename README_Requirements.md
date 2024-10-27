### **Detailed Requirements Table - Student/Teacher Portal Project**  

| **ID** | **Category**               | **Description**                                                                                              | **Responsible** | **Expected Status** |
|--------|-----------------------------|--------------------------------------------------------------------------------------------------------------|----------------|---------------------|
| **1**  | Backend: Login              | Implement a login screen for user authentication (students and admins).                                      | Frontend       | Completed           |
| **2**  | Backend: JWT Token          | Fix the `GenerateJwtToken` function so that roles are correctly assigned in the JWT token.                    | Backend        | Completed           |
| **3**  | Backend: /api/user          | Restrict access to the **/api/user** endpoint to **ADMIN users only**.                                        | Backend        | Completed           |
| **4**  | Backend: User CRUD          | Allow only ADMIN users to **list, create, edit, and delete** users.                                           | Backend        | Completed           |
| **5**  | Backend: Student CRUD       | Allow **paginated listing, creation, and editing** of students, accessible only to **ADMIN** users.           | Backend        | Completed           |
| **6**  | Backend: Course CRUD        | Complete the `CourseController` to **add, list, edit, and delete courses**.                                   | Backend        | Completed           |
| **7**  | Backend: Subject CRUD       | Implement **CRUD for subjects** and organize them by session (Spring, Summer, Fall, Winter).                  | Backend        | Completed           |
| **8**  | Backend: Grade Calculation  | Implement the **final grade calculation** logic in the `StudentCourseGrade` model.                            | Backend        | Completed           |
| **9**  | Frontend: Dashboard         | Create a dashboard showing **metrics**: average grades per course, students' average age, and student counts. | Frontend       | Completed           |
| **10** | Frontend: Login Screen      | Create the login screen, store the **JWT token in localStorage**, and redirect to the dashboard after login.  | Frontend       | Completed           |
| **11** | Frontend: User Management   | Implement a screen to **create, list (paginated), edit, and delete users** (ADMIN only).                      | Frontend       | Completed           |
| **12** | Frontend: Student Management| Implement a screen to **list (paginated), create, and edit students** (ADMIN only).                           | Frontend       | Completed           |
| **13** | Frontend: Course Management | Implement a screen to **create, list (paginated), edit, and delete courses** (ADMIN only).                    | Frontend       | Completed           |
| **14** | Frontend: Subject Management| Create a screen to **list (paginated), add, and edit subjects**, organized by session.                        | Frontend       | Completed           |
| **15** | Frontend: My Courses        | Create a "My Courses" screen for students to **view grades and subjects** by session.                         | Frontend       | Completed           |
| **16** | Docker: Dockerfile          | Review the **Dockerfile** for API and App to ensure images and dependencies are correctly set.                | DevOps         | Completed           |
| **17** | Docker: ENTRYPOINT          | Ensure that the **ENTRYPOINT** is configured correctly to start the application.                              | DevOps         | Completed           |
| **18** | Docker: Port 5262           | Expose **port 5262** in the Dockerfile to allow API access.                                                  | DevOps         | Completed           |
| **19** | Docker: .dockerignore       | Review the **.dockerignore** to exclude unnecessary files from the container.                                 | DevOps         | Completed           |
| **20** | Docker: docker-compose.yml | Run the application using `docker-compose` to simulate the production environment.                            | DevOps         | Completed           |
| **21** | Migrations: Database        | Execute **database migrations** using EF Core and verify that all tables are correctly created.               | Backend        | Completed           |
| **22** | Testing: API and Frontend   | Test all API endpoints and frontend functionality to ensure they work as expected.                            | QA             | Completed           |
| **23** | Git: Version Control        | Set up a **GitHub repository**, add a `.gitignore`, and push the project.                                     | All            | Completed           |

# *** YOU CANNOT CHANGE THIS FILE ***