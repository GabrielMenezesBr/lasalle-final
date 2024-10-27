# Evaluation Table (Total 100)  

| **Action**                           | **Expectation**                                                   | **Max Score** | **Score Given** |
|--------------------------------------|-------------------------------------------------------------------|--------------|----------------|
| **1. Follow Mandatory Requirements** | All listed mandatory features are correctly implemented (e.g., role-based access, CRUD operations, grade calculations). | 15           |                |
| **2. Application Runs in Production** | The application runs successfully using `docker-compose up -d` without errors. | 20           |                |
| **3. Answer Questions** | [Questions](README_Questions.md) | 10           |                |


### 3. Functional API Endpoints 
| **Action**                           | **Expectation**                                                   | **Max Score** | **Score Given** |
|--------------------------------------|-------------------------------------------------------------------|--------------|----------------|
| 3.1 User Authentication (Login)      | Login endpoint works with JWT token generation and validation.   | 5            |                |
| 3.2 Role-Based Access Control        | ADMIN-only endpoints are protected; STUDENT users access only their data. | 5            |                |
| 3.3 User Management API              | CRUD operations for users are functional (Create, List, Edit, Delete). | 5            |                |
| 3.4 Course & Subject Management API  | CRUD operations for courses and subjects, with deletion restrictions (e.g., cannot delete courses with enrolled students). | 5            |                |

---

### 4. Correct Frontend Implementation
| **Action**                           | **Expectation**                                                   | **Max Score** | **Score Given** |
|--------------------------------------|-------------------------------------------------------------------|--------------|----------------|
| 4.1 Login Screen                     | Login works, with token storage and redirection to Dashboard upon success. | 4            |                |
| 4.2 Dashboard                        | Displays metrics: average grades per course, average student age, and number of students per course. | 4            |                |
| 4.3 User Management Screen (Admin Only) | Allows ADMIN to create, list (with pagination), edit, and delete users. | 4            |                |
| 4.4 Student Management Screen (Admin Only) | Allows ADMIN to create, list (with pagination), and edit student data. | 4            |                |
| 4.5 Course & Subject Management (Admin Only) | Allows ADMIN to create, list (with pagination), edit, and delete courses and subjects. Prevents deletion if students are enrolled. | 4            |                |
| 4.6 My Courses (Student Only)        | Displays the student’s enrolled courses, with grades and subjects organized by session. | 4            |                |

---

### Additional Criteria
| **Action**                           | **Expectation**                                                   | **Max Score** | **Score Given** |
|--------------------------------------|-------------------------------------------------------------------|--------------|----------------|
| **5. Code Quality and Organization** | Code is well-organized, readable, and follows best practices (e.g., proper use of `.gitignore`, clear commits). | 10           |                |
| **6. Authentication and Authorization** | Authentication (JWT) works correctly, and role-based authorization is enforced. | 10           |                |
| **7. Data Persistence and Migrations** | Database is correctly set up, and migrations are applied without issues. | 5            |                |
| **8. UI Design and Usability**       | User interface is styled with Bootstrap/Materialize and is easy to use. | 5            |                |

# *** YOU CANNOT CHANGE THIS FILE ***