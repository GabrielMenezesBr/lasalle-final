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