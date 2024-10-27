// src/components/StudentManagement.js
import React, { useEffect, useState } from 'react';
import axios from 'axios';

const StudentManagement = () => {
    const [students, setStudents] = useState([]);
    const [page, setPage] = useState(1);
    const [totalPages, setTotalPages] = useState(1);
    const [newStudentName, setNewStudentName] = useState('');
    const [editingStudent, setEditingStudent] = useState(null);

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

    const handleAddStudent = async () => {
        try {
            await axios.post('API_URL/students', { name: newStudentName }); // Ajuste a URL da API
            fetchStudents(page);
            setNewStudentName('');
        } catch (error) {
            console.error('Error adding student:', error);
        }
    };

    const handleEdit = (student) => {
        setEditingStudent(student);
        setNewStudentName(student.name); // Preencher o campo de entrada para edição
    };

    const handleUpdateStudent = async () => {
        if (editingStudent) {
            try {
                await axios.put(`API_URL/students/${editingStudent.id}`, { name: newStudentName }); // Ajuste a URL da API
                fetchStudents(page);
                setEditingStudent(null);
                setNewStudentName('');
            } catch (error) {
                console.error('Error updating student:', error);
            }
        }
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
            <input
                type="text"
                value={newStudentName}
                onChange={(e) => setNewStudentName(e.target.value)}
                placeholder="Nome do estudante"
            />
            <button onClick={editingStudent ? handleUpdateStudent : handleAddStudent}>
                {editingStudent ? 'Atualizar Estudante' : 'Adicionar Estudante'}
            </button>
            <ul>
                {students.map((student) => (
                    <li key={student.id}>
                        {student.name}
                        <button onClick={() => handleEdit(student)}>Edit</button>
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
