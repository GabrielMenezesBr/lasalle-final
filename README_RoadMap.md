# **Checklist: Student/Teacher Portal Development Project**  

This checklist will guide you step-by-step to ensure you complete the project successfully within the 4-hour limit. Follow the sequence, track progress, and check each task as you complete it.

---

## **1. Project Setup**  

- [ ] **Open Folders Separately in VSCode**:  
    ```shell
    code final/Api
    code final/App
    ```
- [ ] **Review the Api/README.md**: Understand database setup, migrations, and docker commands.  
- [ ] **Verify Docker & Dependencies**:
  - Ensure **Docker** and **docker-compose** are installed and running.
  - Verify that **Node.js** and **.NET Core SDK** are installed.  
- [ ] **Initialize Git Repository**:
    - [ ] Create a private **GitHub repository**.
    - [ ] Add `.gitignore` files (ignore `node_modules/`, `bin/`, `obj/` folders, etc.).
    - [ ] Add the project leader as a collaborator.
  
---

## **2. Fix and Implement API Issues**  

### 2.1 **AuthController Fix**  
- [ ] Open **AuthController**.
- [ ] Review the **GenerateJwtToken** function.
- [ ] Uncomment the necessary code to ensure roles are correctly assigned in JWT tokens.

### 2.2 **Restrict /api/user Endpoint Access**  
- [ ] Add authorization logic to ensure **only ADMIN users** can access the `/api/user` endpoint.  
  - **Hint**: Use `[Authorize(Roles = "ADMIN")]` attribute in the UserController.  
- [ ] Test access using **Swagger** or **Api.http**.

### 2.3 **Final Grade Calculation**  
- [ ] Open the **StudentCourseGrade model** and finalize the calculation logic:
  - MidTerm: 30%  
  - FinalExam: 40%  
  - Extra Assignments: 30%  
  - **Formula**:  
    ```
    finalGrade = (midTerm * 0.3) + (finalExam * 0.4) + (extra * 0.3)
    ```
- [ ] Implement logic in the appropriate service to calculate and store the final grade.

### 2.4 **Complete CourseController Implementation**  
- [ ] Open **CourseController**.
  - Implement the following functions:
    - [ ] **Add Course**  
    - [ ] **List Courses (with Pagination)**  
    - [ ] **Edit Course**  
- [ ] Implement **Subject Management**:
  - [ ] Add Subject
  - [ ] List Subjects (Paginated)
  - [ ] Edit Subject
  - [ ] Ensure deletion restrictions (e.g., prevent deleting courses with students enrolled).

- [ ] Test all **Course and Subject endpoints** via **Swagger** or **Api.http**.

---

## **3. Build Frontend Application**  

### 3.1 **Create React App**  
- [ ] Navigate to `/Final` and generate the React app:
    ```shell
    npx create-react-app App
    ```
- [ ] Choose **Bootstrap or Materialize** for styling:
    - **Bootstrap**:  
      ```shell
      npm install bootstrap
      ```
      Import Bootstrap CSS in `src/index.js`:
      ```javascript
      import 'bootstrap/dist/css/bootstrap.min.css';
      ```
    - **Materialize**:  
      ```shell
      npm install materialize-css
      ```
      Import Materialize CSS:
      ```javascript
      import 'materialize-css/dist/css/materialize.min.css';
      ```

### 3.2 **Implement Frontend Features**  

- [ ] **Login Screen**:
  - Default route if **not authenticated**.
  - Use local storage to **store JWT token** upon login.
  - Redirect to **Dashboard** after successful login.

- [ ] **Dashboard**:
  - Display relevant metrics:
    - [ ] Average grades per course.
    - [ ] Average age of students.
    - [ ] Number of students per course.

- [ ] **User Management (ADMIN only)**:
  - Create, list (paginated), edit, and delete users.
  - Ensure the **current user can edit their own profile**.

- [ ] **Student Management (ADMIN only)**:
  - Create, list (paginated), and edit student information.

- [ ] **Course and Subject Management (ADMIN only)**:
  - Create, list (paginated), edit, and delete courses and subjects.
  - Restrict **course deletion** if students are enrolled.

- [ ] **My Courses (STUDENT only)**:
  - Display the student’s enrolled courses.
  - Show grades and a list (paginated) of subjects, organized by session.

---

## **4. Docker Setup and Testing**  

### 4.1 **Understand Docker Files**  
- [ ] **Dockerfile**:
  - **Q1**: *What is the role of the first line?*  
    > It defines the **base image** for the container (e.g., `FROM mcr.microsoft.com/dotnet/aspnet:8.0`).

  - **Q2**: *What is the function of ENTRYPOINT?*  
    > It specifies the **command** that will run when the container starts.

  - **Q3**: *Why expose port 5262?*  
    > It makes the **API accessible** on port 5262 within the container.

  - **Q4**: *What is the function of .dockerignore?*  
    > It prevents **unnecessary files** from being copied to the container (e.g., `node_modules`).

### 4.2 **Run the Project with Docker Compose**  
- [ ] Navigate to `/Final` and run:
    ```shell
    docker-compose up --build
    ```
- [ ] **Verify API and Frontend**:
  - Ensure the **API** and **frontend** run without errors.
  - Access the system via the **browser** at the appropriate port.

- [ ] **Apply Migrations**:
  - Follow the instructions from **Api/README.md** to apply migrations and seed the database:
    ```shell
    dotnet ef database update
    ```

---

## **5. Test the Application**  
- [ ] Test the **Login process**.
- [ ] Validate the **Dashboard metrics**.
- [ ] Verify **role-based access**:
  - **ADMIN**: Access to user, student, course, and subject management.
  - **STUDENT**: Access only to their own courses and grades.
- [ ] Ensure **CRUD operations** work correctly for:
  - Users
  - Students
  - Courses and Subjects

---

## **6. Final Steps**  

- [ ] **Commit and Push** all changes to the GitHub repository.
    ```shell
    git add .
    git commit -m "Final Project Submission"
    git push origin main
    ```
- [ ] **Add Project Leader as Collaborator** on the repository.

---

## **Checklist Summary**  

### **Backend (API)**  
- [ ] Fix **AuthController** issue.  
- [ ] Restrict **/api/user** endpoint.  
- [ ] Complete **grade calculation** logic.  
- [ ] Implement **CourseController** functions.  

### **Frontend (React App)**  
- [ ] Create **React app** and apply chosen CSS framework.  
- [ ] Implement **Login**, **Dashboard**, **User Management**, **Course Management**, and **My Courses** screens.  

### **Docker**  
- [ ] Verify **Dockerfile** and **docker-compose.yml**.  
- [ ] Run the system using **docker-compose**.  

### **Testing and Delivery**  
- [ ] Test all features (CRUD, authentication, role-based access).  
- [ ] Push code to **GitHub** and add project leader as collaborator.

---

With this checklist, you'll have a clear roadmap to complete the project on time and meet all the requirements. Good luck! 🚀