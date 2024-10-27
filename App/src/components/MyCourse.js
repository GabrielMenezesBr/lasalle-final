// src/components/MyCourses.js
import React, { useEffect, useState } from 'react';
import axios from 'axios';

const MyCourses = () => {
    const [courses, setCourses] = useState([]);

    useEffect(() => {
        const fetchCourses = async () => {
            try {
                const response = await axios.get('API_URL/studentcourses');
                setCourses(response.data);
            } catch (error) {
                console.error('Error fetching courses:', error);
            }
        };

        fetchCourses();
    }, []);

    return (
        <div className="container">
            <h2>My Courses</h2>
            <ul className="list-group">
                {courses.map(course => (
                    <li key={course.id} className="list-group-item">
                        {course.description}
                    </li>
                ))}
            </ul>
        </div>
    );
};

export default MyCourses;
