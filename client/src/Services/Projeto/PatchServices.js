import axios from 'axios';

const API_URI = 'http://localhost:5180/api/Projeto';

const patchProjeto = async (id, Projeto) => {
    try {
        const response = await axios.patch(`${API_URI}/${id}`, Projeto);
        return response.data;

    } catch (error) {
        console.error(`Error updating Projeto with id ${id}:`, error);
        throw error;

    }
}

export default patchProjeto;