
## Folder STRUCTURE

[Return to README](README.md)

```
/Final
├── /Api
│   ├── /Controllers     # Contains API controllers (e.g., AuthController, UserController, CourseController)
│   ├── /Models          # Contains data models and entities (e.g., Student, Course, User)
│   ├── /Data            # Contains data context and database configuration (e.g., ApplicationDbContext)
│   ├── /Migrations      # Database migration files
│   ├── /Services        # Business logic services (e.g., UserService, CourseService)
│   ├── /Properties      # Assembly information and other properties
│   ├── appsettings.json # Configuration settings
│   ├── Program.cs       # Entry point for the API application
│   └── Dockerfile       # Docker configuration for the API
│
├── /App
│   ├── /src                  # Source code for the frontend application
│   │   ├── /components       # Reusable UI components
│   │   ├── /pages            # Page components (e.g., Login, Dashboard, User Management)
│   │   ├── /services         # Services for API calls
│   │   ├── /hooks            # Custom hooks (if using React)
│   │   ├── /context          # Context API files for state management (if using React)
│   │   ├── /styles           # CSS or styled components for styling
│   │   ├── /utils            # Utility functions
│   │   └── App.js            # Main application file (entry point for the frontend)
│   │
│   ├── /public               # Public assets (e.g., index.html, favicon)
│   ├── package.json          # Project metadata and dependencies
│   ├── .env                  # Environment variables for the frontend
│   └── Dockerfile            # Docker configuration for the frontend
│
├── docker-compose.yml         # Docker Compose configuration file for the entire project
└── README.md                  # Documentation for the project
```

## **Main Commands for ReactJS**

### 1. **Create a New Project**
Depending on the tool you choose, there are different ways to start a React project:

#### **Using Create React App (CRA):**
```bash
npx create-react-app project-name
```
- `npx`: Ensures you are using the latest package version.  
- `project-name`: The name of your React project.

**Options:**
- `--template typescript`: Initializes the project with TypeScript support.

#### **Using Vite (for a faster setup):**
```bash
npm create vite@latest project-name -- --template react
```

---

### 2. **Start the Development Server**
To start the React development server:

```bash
npm start
# Or for Vite:
npm run dev
```
- By default, the app will be available at `http://localhost:3000` (CRA) or `http://localhost:5173` (Vite).

---

### 3. **Build the Project for Production**
This command generates optimized files for deployment in the `build/` folder.

```bash
npm run build
```
- Minifies the code and optimizes it for production use.

---

### 4. **Run Tests**
If your project includes tests (e.g., with Jest), you can run them using:

```bash
npm test
```
- This command watches for changes and reruns tests automatically.  
- Use `npm test -- --watchAll=false` to run the tests once.

---

### 5. **Install Dependencies**
To add new libraries or packages to your React project:

```bash
npm install package-name
```
**Examples:**
- **React Router:** `npm install react-router-dom`  
- **Axios (HTTP client):** `npm install axios`

---

### 6. **Remove Dependencies**
To uninstall a package from your project:

```bash
npm uninstall package-name
```

---

### 7. **Run ESLint and Prettier (Code Linting and Formatting)**
If you have **ESLint** or **Prettier** configured, you can use these commands to check and format your code:

```bash
npx eslint . # Check for linting issues
npx prettier --write . # Format the code
```

---

### 8. **Check Project Info and Version**
To see the React version and other package information:

```bash
npm list react
```

---

### 9. **Install Developer Tools (like Typescript)**
To add development dependencies (e.g., TypeScript) to your project:

```bash
npm install typescript --save-dev
```

---

### 10. **Upgrade Packages**
To update all project dependencies to their latest versions:

```bash
npm update
```