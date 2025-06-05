import axios from 'axios';

const API_URL = 'http://localhost:3000/api/SubTarefa';

const getAllSubTarefas = async () => {
    try {
        const response = await axios.get(API_URL);
        return response.data;

    } catch (error) {
        console.error('Error fetching SubTarefas:', error);
        throw error;

    }
};

const getSubTarefaById = async (id) => {
    try {
        const response = await axios.get(`${API_URL}/ById/${id}`);
        return response.data;

    } catch (error) {
        console.error(`Error fetching SubTarefa with id ${id}:`, error);
        throw error;

    }
};

const getSubTarefasByDescricao = async (descricao) => {
    try {
        const response = await axios.get(`${API_URL}/ByDescricao/${descricao}`);
        return response.data;

    } catch (error) {
        console.error(`Error fetching SubTarefas for descricao ${descricao}:`, error);
        throw error;

    }
};

const getSubTarefasByData = async (dataIni, dataFim) => {
    try {
        const response = await axios.get(`${API_URL}/ByData/${dataIni}/${dataFim}`);
        return response.data;

    } catch (error) {
        console.error(`Error fetching SubTarefas for date ${dataIni} to ${dataFim}:`, error);
        throw error;

    }
}

export { getAllSubTarefas, getSubTarefaById, getSubTarefasByDescricao, getSubTarefasByData };
