// src/App.js
import React from 'react';
import { BrowserRouter as Router, Route, Routes, Navigate } from 'react-router-dom';
import Login from './components/Login';
import Dashboard from './components/Dashboard';
import UserManagement from './components/UserManagement';
import StudentManagement from './components/StudentManagement';
import CourseManagement from './components/CourseManagement';
import MyCourses from './components/MyCourses';

const App = () => {
    const isAuthenticated = !!localStorage.getItem('jwtToken');
    const isAdmin = true; // Logic to check if user is admin should be implemented

    return (
        <Router>
            <Routes>
                <Route path="/login" element={<Login />} />
                <Route path="/dashboard" element={isAuthenticated ? <Dashboard /> : <Navigate to="/login" />} />
                <Route path="/users" element={isAdmin ? <UserManagement /> : <Navigate to="/dashboard" />} />
                <Route path="/students" element={isAdmin ? <StudentManagement /> : <Navigate to="/dashboard" />} />
                <Route path="/courses" element={isAdmin ? <CourseManagement /> : <Navigate to="/dashboard" />} />
                <Route path="/my-courses" element={isAuthenticated ? <MyCourses /> : <Navigate to="/login" />} />
                <Route path="/" element={<Navigate to="/login" />} />
            </Routes>
        </Router>
    );
};

export default App;
