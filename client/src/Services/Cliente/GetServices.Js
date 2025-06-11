import axios from 'axios';

const API_URL = 'http://localhost:5180/api/Cliente';

const getAllClientes = async () => {
    try {
        const response = await axios.get(API_URL);
        return response.data;

    } catch (error) {
        console.error('Error fetching Clientes:', error);
        throw error;

    }
};

const getClienteById = async (id) => {
    try {
        const response = await axios.get(`${API_URL}/ById/${id}`);
        return response.data;

    } catch (error) {
        console.error(`Error fetching Cliente with id ${id}:`, error);
        throw error;

    }
};

const getClientesByName = async (name) => {
    try {
        const response = await axios.get(`${API_URL}/ByName/${name}`);
        return response.data;

    } catch (error) {
        console.error(`Error fetching Clientes with name ${name}:`, error);
        throw error;

    }
};

const getClientesByEmail = async (email) => {
    try {
        const response = await axios.get(`${API_URL}/ByEmail/${email}`);
        return response.data;

    } catch (error) {
        console.error(`Error fetching Clientes with email ${email}:`, error);
        throw error;

    }
}

const getClientesByTelefone = async (telefone) => {
    try {
        const response = await axios.get(`${API_URL}/ByTelefone/${telefone}`);
        return response.data;

    } catch (error) {
        console.error(`Error fetching Clientes with telefone ${telefone}:`, error);
        throw error;

    }
}

export { getAllClientes, getClienteById, getClientesByName, getClientesByEmail, getClientesByTelefone };
