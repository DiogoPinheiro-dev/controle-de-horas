import axios from 'axios';

const API_URL = 'http://localhost:5180/api/Projeto';

const getAllProjetos = async () => {
    try {
        const response = await axios.get(API_URL);
        return response.data;

    } catch (error) {
        console.error('Error fetching Projetos:', error);
        throw error;

    }
};

const getProjetoById = async (id) => {
    try {
        const response = await axios.get(`${API_URL}/ById/${id}`);
        return response.data;

    } catch (error) {
        console.error(`Error fetching Projeto with id ${id}:`, error);
        throw error;

    }
};

const getProjetosByNome = async (nome) => {
    try {
        const response = await axios.get(`${API_URL}/ByNome/${nome}`);
        return response.data;

    } catch (error) {
        console.error(`Error fetching Projetos with nome ${nome}:`, error);
        throw error;

    }
};

const getProjetosByDescricao = async (descricao) => {
    try {
        const response = await axios.get(`${API_URL}/ByDescricao/${descricao}`);
        return response.data;

    } catch (error) {
        console.error(`Error fetching Projetos with descricao ${descricao}:`, error);
        throw error;

    }
};

const getProjetosByData = async (dataIni, dataFim) => {
    try {
        const response = await axios.get(`${API_URL}/ByData/${dataIni}/${dataFim}`);
        return response.data;

    } catch (error) {
        console.error(`Error fetching Projetos for date ${dataIni} to ${dataFim}:`, error);
        throw error;

    }
}

const getProjetosByClienteId = async (clienteId) => {
    try {
        const response = await axios.get(`${API_URL}/ByClienteId/${clienteId}`);
        return response.data;

    } catch (error) {
        console.error(`Error fetching Projetos for clienteId ${clienteId}:`, error);
        throw error;

    }
}

const getProjetosByRecursoId = async (recursoId) => {
    try {
        const response = await axios.get(`${API_URL}/ByRecursoId/${recursoId}`);
        return response.data;

    } catch (error) {
        console.error(`Error fetching Projetos for recursoId ${recursoId}:`, error);
        throw error;

    }
}

const getProjetosByEmpresaId = async (empresaId) => {
    try {
        const response = await axios.get(`${API_URL}/ByEmpresaId/${empresaId}`);
        return response.data;

    } catch (error) {
        console.error(`Error fetching Projetos for empresaId ${empresaId}:`, error);
        throw error;

    }
}

export { getAllProjetos, getProjetoById, getProjetosByNome, getProjetosByDescricao, getProjetosByData, getProjetosByClienteId, getProjetosByRecursoId, getProjetosByEmpresaId };
