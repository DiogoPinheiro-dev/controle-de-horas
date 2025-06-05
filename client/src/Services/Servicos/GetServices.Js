import axios from 'axios';

const API_URL = 'http://localhost:3000/api/Servicos';

const getAllServicos = async () => {
    try {
        const response = await axios.get(API_URL);
        return response.data;

    } catch (error) {
        console.error('Error fetching Servicos:', error);
        throw error;

    }
};

const getServicosById = async (id) => {
    try {
        const response = await axios.get(`${API_URL}/ById/${id}`);
        return response.data;

    } catch (error) {
        console.error(`Error fetching Servicos with id ${id}:`, error);
        throw error;

    }
};

const getServicosByDescricao = async (descricao) => {
    try {
        const response = await axios.get(`${API_URL}/ByDescricao/${descricao}`);
        return response.data;

    } catch (error) {
        console.error(`Error fetching Servicos for descricao ${descricao}:`, error);
        throw error;

    }
};

const getServicosByCusto = async (custo) => {
    try {
        const response = await axios.get(`${API_URL}/ByCusto/${custo}`);
        return response.data;

    } catch (error) {
        console.error(`Error fetching Servicos for custo ${custo}:`, error);
        throw error;

    }
}

export { getAllServicos, getServicosById, getServicosByDescricao, getServicosByCusto };
