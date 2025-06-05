import axios from 'axios';

const API_URL = 'http://localhost:3000/api/Apontamento';

const getAllApontamentos = async () => {
    try {
        const response = await axios.get(API_URL);
        return response.data;

    } catch (error) {
        console.error('Error fetching apontamentos:', error);
        throw error;

    }
};

const getApontamentoById = async (id) => {
    try {
        const response = await axios.get(`${API_URL}/ById/${id}`);
        return response.data;

    } catch (error) {
        console.error(`Error fetching apontamento with id ${id}:`, error);
        throw error;

    }
};

const getApontamentosByOs = async (os) => {
    try {
        const response = await axios.get(`${API_URL}/ByOs/${os}`);
        return response.data;

    } catch (error) {
        console.error(`Error fetching apontamentos for OS ${os}:`, error);
        throw error;

    }
};

const getApontamentosByData = async (dataIni, dataFim) => {
    try {
        const response = await axios.get(`${API_URL}/ByData/${dataIni}/${dataFim}`);
        return response.data;

    } catch (error) {
        console.error(`Error fetching apontamentos for date ${dataIni} to ${dataFim}:`, error);
        throw error;

    }
}

export { getAllApontamentos, getApontamentoById, getApontamentosByOs, getApontamentosByData };
