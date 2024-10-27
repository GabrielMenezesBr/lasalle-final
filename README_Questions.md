# Questions

## **Project Planning & Requirements:**

1. **How would you ensure that only authorized users can access specific pages (e.g., Admin-only screens) in the frontend? Explain your approach.**

2. **What strategy would you use to manage user roles on both the client (frontend) and server (API)?**  

3. **What challenges might arise when paginating a list of students or courses? How would you handle these challenges in React?**

4. **How will you validate user input (e.g., student grades) in both the frontend and backend to avoid errors or data inconsistencies?**

---

## **Authentication & Security:**

5. **What changes are needed in the `AuthController` to correctly generate JWT tokens with user roles? Explain your fix.**

6. **Why is it necessary to restrict access to certain API endpoints based on user roles? How would you implement this?**

7. **What methods can you use to protect sensitive information, like passwords or personal data, in both the API and frontend?**

8. **Explain how you would store and manage the JWT token in the frontend to prevent unauthorized access (e.g., avoid XSS attacks).**

---

## **Frontend Development (ReactJS):**

9. **What are the advantages of using Bootstrap or Materialize for styling your React app? Which one would you choose, and why?**

10. **Explain how you would set up React Router to manage page navigation, including protected routes based on user roles.**

11. **How would you structure the components for the Dashboard page to efficiently display metrics (like average grades, student count)?**

12. **What is your approach to handle form submission in React (e.g., for adding/editing users or courses)?**

13. **How would you implement pagination in React to display students and courses efficiently?**

---

## **API & Backend (C#/.NET Core):**

14. **What adjustments would you make to ensure that only users with the "ADMIN" role can access the `/api/user` endpoint?**

15. **How would you complete the logic for the `StudentCourseGrade` model to calculate the final grade?**

16. **What strategy would you follow to ensure that a course with enrolled students or ongoing subjects is not deleted?**

17. **How would you implement the missing functions in `CourseController` to support adding, editing, and paginating courses and subjects?**

18. **What error-handling mechanisms would you include in your API to ensure stability and meaningful feedback for the frontend?**

---

## **Docker & Deployment:**

19. **What does the first line in the Dockerfile typically represent, and why is it important?**

20. **What is the role of `ENTRYPOINT` in the Dockerfile, and how does it affect container behavior?**

21. **Why do we need to expose port 5262 in the Docker configuration? What happens if this is not done?**

22. **What is the purpose of the `.dockerignore` file? What kind of files should be listed in it?**

23. **Explain the process of using `docker-compose` to run the system. What steps are involved, and what common issues might arise?**

---

## **Database & Migrations:**

24. **How would you perform and verify database migrations after launching the project using `docker-compose`?**

25. **What strategy would you follow to prevent data loss or corruption during course/student updates?**

---

## **Version Control & Collaboration:**

26. **How would you structure your Git repository to ensure a clean and organized project setup?**

27. **What kind of files should be included in your `.gitignore` file to avoid unnecessary uploads?**

28. **How would you collaborate effectively using GitHub, considering the requirement to add the project leader as a collaborator?**

Project Planning & Requirements:
How would you ensure that only authorized users can access specific pages (e.g., Admin-only screens) in the frontend? Explain your approach.

Use route guards to check user roles before rendering specific components.

What strategy would you use to manage user roles on both the client (frontend) and server (API)?

Store roles in JWT tokens and manage them in a central state (e.g., Context API).

What challenges might arise when paginating a list of students or courses? How would you handle these challenges in React?

Challenges include maintaining state and managing API calls; handle these by caching data and implementing lazy loading.

How will you validate user input (e.g., student grades) in both the frontend and backend to avoid errors or data inconsistencies?

Validate input using form libraries in the frontend and implement server-side checks in the API.

Authentication & Security:
What changes are needed in the AuthController to correctly generate JWT tokens with user roles? Explain your fix.

Modify the AuthController to include user roles in the JWT payload during token generation.

Why is it necessary to restrict access to certain API endpoints based on user roles? How would you implement this?

Restricting access ensures security; implement middleware to check roles for API endpoints.

What methods can you use to protect sensitive information, like passwords or personal data, in both the API and frontend?

Use hashing for passwords and encryption for sensitive data; implement HTTPS for API calls.

Explain how you would store and manage the JWT token in the frontend to prevent unauthorized access (e.g., avoid XSS attacks).

Store JWT in httpOnly cookies to prevent XSS attacks.

Frontend Development (ReactJS):
What are the advantages of using Bootstrap or Materialize for styling your React app? Which one would you choose, and why?

Advantages include responsive design and pre-built components; I would choose Bootstrap for its simplicity.

Explain how you would set up React Router to manage page navigation, including protected routes based on user roles.

Set up React Router with Routes and protect routes using Navigate based on roles.

How would you structure the components for the Dashboard page to efficiently display metrics (like average grades, student count)?

Structure components with a parent container for metrics and use cards or grids for display.

What is your approach to handle form submission in React (e.g., for adding/editing users or courses)?

Use controlled components to handle form submission and axios for API calls.

How would you implement pagination in React to display students and courses efficiently?

Implement pagination using state to track the current page and slice the data accordingly.

API & Backend (C#/.NET Core):
What adjustments would you make to ensure that only users with the "ADMIN" role can access the /api/user endpoint?

Use authorization attributes to restrict access to the /api/user endpoint for "ADMIN" role only.

How would you complete the logic for the StudentCourseGrade model to calculate the final grade?

Implement logic in the StudentCourseGrade model to calculate averages based on existing grades.

What strategy would you follow to ensure that a course with enrolled students or ongoing subjects is not deleted?

Implement checks before deletion to verify if students are enrolled or subjects are ongoing.

How would you implement the missing functions in CourseController to support adding, editing, and paginating courses and subjects?

Add methods in CourseController for CRUD operations and implement pagination using query parameters.

What error-handling mechanisms would you include in your API to ensure stability and meaningful feedback for the frontend?

Use try-catch blocks for error handling and return meaningful status codes and messages.

Docker & Deployment:
What does the first line in the Dockerfile typically represent, and why is it important?

The first line in the Dockerfile represents the base image, crucial for defining the environment.

What is the role of ENTRYPOINT in the Dockerfile, and how does it affect container behavior?

ENTRYPOINT specifies the command executed when the container starts, determining its main behavior.

Why do we need to expose port 5262 in the Docker configuration? What happens if this is not done?

Expose port 5262 to allow external access; without it, the service cannot be accessed from outside the container.

What is the purpose of the .dockerignore file? What kind of files should be listed in it?

.dockerignore prevents unnecessary files from being copied; list files like node_modules and logs.

Explain the process of using docker-compose to run the system. What steps are involved, and what common issues might arise?

Using docker-compose, define services in a docker-compose.yml file; common issues include port conflicts.

Database & Migrations:
How would you perform and verify database migrations after launching the project using docker-compose?

Run migrations using a migration command and verify by checking the database state post-launch.

What strategy would you follow to prevent data loss or corruption during course/student updates?

Use transactions during updates to maintain integrity and implement rollback mechanisms.

Version Control & Collaboration:
How would you structure your Git repository to ensure a clean and organized project setup?

Structure the Git repository with clear directories for src, tests, and docs.

What kind of files should be included in your .gitignore file to avoid unnecessary uploads?

Include files like node_modules, logs, and environment variables in the .gitignore.

How would you collaborate effectively using GitHub, considering the requirement to add the project leader as a collaborator?

Use branches for features and PRs for collaboration; add the project leader as a collaborator in the repo settings.