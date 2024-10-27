// src/components/Dashboard.js
import React, { useEffect, useState } from 'react';
import axios from 'axios';

const Dashboard = () => {
    const [averageGrades, setAverageGrades] = useState([]);
    const [averageAge, setAverageAge] = useState(0);
    const [studentsPerCourse, setStudentsPerCourse] = useState([]);

    useEffect(() => {
        const fetchMetrics = async () => {
            try {
                const { data } = await axios.get('API_URL/dashboard/metrics'); // Ajuste a URL da API
                setAverageGrades(data.averageGrades);
                setAverageAge(data.averageAge);
                setStudentsPerCourse(data.studentsPerCourse);
            } catch (error) {
                console.error('Error fetching metrics:', error);
            }
        };

        fetchMetrics();
    }, []);

    return (
        <div>
            <h2>Dashboard</h2>
            <h3>Médias de Notas por Curso</h3>
            <ul>
                {averageGrades.map((course) => (
                    <li key={course.id}>
                        {course.description}: {course.averageGrade}
                    </li>
                ))}
            </ul>
            <h3>Média de Idade dos Estudantes: {averageAge}</h3>
            <h3>Número de Estudantes por Curso</h3>
            <ul>
                {studentsPerCourse.map((course) => (
                    <li key={course.id}>
                        {course.description}: {course.studentCount}
                    </li>
                ))}
            </ul>
        </div>
    );
};

export default Dashboard;
