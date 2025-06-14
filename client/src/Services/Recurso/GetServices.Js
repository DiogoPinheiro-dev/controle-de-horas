import axios from 'axios';

const API_URL = 'http://localhost:5180/api/Recurso';

const getAllRecursos = async () => {
    try {
        const response = await axios.get(API_URL);
        return response.data;

    } catch (error) {
        console.error('Error fetching Recursos:', error);
        throw error;

    }
};

const getRecursoById = async (id) => {
    try {
        const response = await axios.get(`${API_URL}/ById/${id}`);
        return response.data;

    } catch (error) {
        console.error(`Error fetching Recurso with id ${id}:`, error);
        throw error;

    }
};

const getRecursosByEmail = async (email) => {
    try {
        const response = await axios.get(`${API_URL}/ByEmail/${email}`);
        return response.data;

    } catch (error) {
        console.error(`Error fetching Recursos for email ${email}:`, error);
        throw error;

    }
};

const getRecursosByNome = async (nome) => {
    try {
        const response = await axios.get(`${API_URL}/ByNome/${nome}`);
        return response.data;

    } catch (error) {
        console.error(`Error fetching Recursos with nome ${nome}:`, error);
        throw error;

    }
};


const getRecursosByTelefone = async (telefone) => {
    try {
        const response = await axios.get(`${API_URL}/ByTel/${telefone}`);
        return response.data;

    } catch (error) {
        console.error(`Error fetching Recursos with telefone ${telefone}:`, error);
        throw error;

    }
};


const getRecursosByTipo = async (tipo) => {
    try {
        const response = await axios.get(`${API_URL}/ByTipo/${tipo}`);
        return response.data;

    } catch (error) {
        console.error(`Error fetching Recursos with tipo ${tipo}:`, error);
        throw error;

    }
};

export { getAllRecursos, getRecursoById, getRecursosByEmail, getRecursosByNome, getRecursosByTipo, getRecursosByTelefone };
