import axios from 'axios';

const API_URL = 'http://localhost:5180/api/Usuario';

const getAllUsuarios = async () => {
    try {
        const response = await axios.get(API_URL);
        return response.data;

    } catch (error) {
        console.error('Error fetching Usuarios:', error);
        throw error;

    }
};

const getUsuarioById = async (id) => {
    try {
        const response = await axios.get(`${API_URL}/ById/${id}`);
        return response.data;

    } catch (error) {
        console.error(`Error fetching Usuario with id ${id}:`, error);
        throw error;

    }
};

const getUsuariosByEmail = async (email) => {
    try {
        const response = await axios.get(`${API_URL}/ByEmail/${email}`);
        return response.data;

    } catch (error) {
        console.error(`Error fetching Usuarios for email ${email}:`, error);
        throw error;

    }
};

const getUsuariosByNivelDeUsuario = async (nivel) => {
    try {
        const response = await axios.get(`${API_URL}/ByNivel/${nivel}`);
        return response.data;

    } catch (error) {
        console.error(`Error fetching Usuarios for nivel ${nivel}:`, error);
        throw error;

    }
}

export { getAllUsuarios, getUsuarioById, getUsuariosByEmail, getUsuariosByNivelDeUsuario };
