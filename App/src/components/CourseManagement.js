// src/components/CourseManagement.js
import React, { useEffect, useState } from 'react';
import axios from 'axios';

const CourseManagement = () => {
    const [courses, setCourses] = useState([]);
    const [newCourseName, setNewCourseName] = useState('');
    const [editingCourse, setEditingCourse] = useState(null);

    const fetchCourses = async () => {
        try {
            const { data } = await axios.get('API_URL/courses'); // Ajuste a URL da API
            setCourses(data.courses);
        } catch (error) {
            console.error('Error fetching courses:', error);
        }
    };

    useEffect(() => {
        fetchCourses();
    }, []);

    const handleAddCourse = async () => {
        try {
            await axios.post('API_URL/courses', { name: newCourseName }); // Ajuste a URL da API
            fetchCourses();
            setNewCourseName('');
        } catch (error) {
            console.error('Error adding course:', error);
        }
    };

    const handleEdit = (course) => {
        setEditingCourse(course);
        setNewCourseName(course.name);
    };

    const handleUpdateCourse = async () => {
        if (editingCourse) {
            try {
                await axios.put(`API_URL/courses/${editingCourse.id}`, { name: newCourseName }); // Ajuste a URL da API
                fetchCourses();
                setEditingCourse(null);
                setNewCourseName('');
            } catch (error) {
                console.error('Error updating course:', error);
            }
        }
    };

    const handleDelete = async (courseId) => {
        try {
            await axios.delete(`API_URL/courses/${courseId}`); // Ajuste a URL da API
            fetchCourses();
        } catch (error) {
            console.error('Error deleting course:', error);
        }
    };

    return (
        <div>
            <h2>Gerenciamento de Cursos</h2>
            <input
                type="text"
                value={newCourseName}
                onChange={(e) => setNewCourseName(e.target.value)}
                placeholder="Nome do curso"
            />
            <button onClick={editingCourse ? handleUpdateCourse : handleAddCourse}>
                {editingCourse ? 'Atualizar Curso' : 'Adicionar Curso'}
            </button>
            <ul>
                {courses.map((course) => (
                    <li key={course.id}>
                        {course.name}
                        <button onClick={() => handleEdit(course)}>Edit</button>
                        <button onClick={() => handleDelete(course.id)}>Delete</button>
                    </li>
                ))}
            </ul>
        </div>
    );
};

export default CourseManagement;
