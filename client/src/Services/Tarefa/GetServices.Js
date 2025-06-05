import axios from 'axios';

const API_URL = 'http://localhost:3000/api/Tarefa';

const getAllTarefas = async () => {
    try {
        const response = await axios.get(API_URL);
        return response.data;

    } catch (error) {
        console.error('Error fetching Tarefas:', error);
        throw error;

    }
};

const getTarefaById = async (id) => {
    try {
        const response = await axios.get(`${API_URL}/ById/${id}`);
        return response.data;

    } catch (error) {
        console.error(`Error fetching Tarefa with id ${id}:`, error);
        throw error;

    }
};

const getTarefasByDescricao = async (descricao) => {
    try {
        const response = await axios.get(`${API_URL}/ByDescricao/${descricao}`);
        return response.data;

    } catch (error) {
        console.error(`Error fetching Tarefas for descricao ${descricao}:`, error);
        throw error;

    }
};

const getTarefasByData = async (dataIni, dataFim) => {
    try {
        const response = await axios.get(`${API_URL}/ByData/${dataIni}/${dataFim}`);
        return response.data;

    } catch (error) {
        console.error(`Error fetching Tarefas for date ${dataIni} to ${dataFim}:`, error);
        throw error;

    }
}

export { getAllTarefas, getTarefaById, getTarefasByDescricao, getTarefasByData };
