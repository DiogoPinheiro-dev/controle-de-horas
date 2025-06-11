import axios from 'axios';

const API_URL = 'http://localhost:5180/api/Empresa';

const getAllEmpresas = async () => {
    try {
        const response = await axios.get(API_URL);
        return response.data;

    } catch (error) {
        console.error('Error fetching Empresas:', error);
        throw error;

    }
};

const getEmpresaById = async (id) => {
    try {
        const response = await axios.get(`${API_URL}/ById/${id}`);
        return response.data;

    } catch (error) {
        console.error(`Error fetching Empresa with id ${id}:`, error);
        throw error;

    }
};

const getEmpresasByNome = async (nome) => {
    try {
        const response = await axios.get(`${API_URL}/ByNome/${nome}`);
        return response.data;

    } catch (error) {
        console.error(`Error fetching Empresas with nome ${nome}:`, error);
        throw error;

    }
};

const getEmpresasByEmail = async (email) => {
    try {
        const response = await axios.get(`${API_URL}/ByEmail/${email}`);
        return response.data;

    } catch (error) {
        console.error(`Error fetching Empresas with email ${email}:`, error);
        throw error;

    }
};

export { getAllEmpresas, getEmpresaById, getEmpresasByNome, getEmpresasByEmail };
