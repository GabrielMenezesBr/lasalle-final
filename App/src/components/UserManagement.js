// src/components/StudentManagement.js
import React, { useEffect, useState } from 'react';
import axios from 'axios';

const StudentManagement = () => {
    const [students, setStudents] = useState([]);
    const [page, setPage] = useState(1);
    const [totalPages, setTotalPages] = useState(1);

    const fetchStudents = async (pageNumber) => {
        try {
            const { data } = await axios.get(`API_URL/students?page=${pageNumber}`); // Ajuste a URL da API
            setStudents(data.students);
            setTotalPages(data.totalPages);
        } catch (error) {
            console.error('Error fetching students:', error);
        }
    };

    useEffect(() => {
        fetchStudents(page);
    }, [page]);

    const handleEdit = (studentId) => {
        // Lógica para editar estudante
        console.log('Edit student:', studentId);
    };

    const handleDelete = async (studentId) => {
        try {
            await axios.delete(`API_URL/students/${studentId}`); // Ajuste a URL da API
            fetchStudents(page); // Atualiza a lista após a exclusão
        } catch (error) {
            console.error('Error deleting student:', error);
        }
    };

    return (
        <div>
            <h2>Gerenciamento de Estudantes</h2>
            <ul>
                {students.map((student) => (
                    <li key={student.id}>
                        {student.name}
                        <button onClick={() => handleEdit(student.id)}>Edit</button>
                        <button onClick={() => handleDelete(student.id)}>Delete</button>
                    </li>
                ))}
            </ul>
            <button onClick={() => setPage((prev) => Math.max(prev - 1, 1))}>Previous</button>
            <button onClick={() => setPage((prev) => Math.min(prev + 1, totalPages))}>Next</button>
        </div>
    );
};

export default StudentManagement;
