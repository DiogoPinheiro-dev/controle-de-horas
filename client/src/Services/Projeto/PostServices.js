import axios from 'axios';

const API_URI = 'http://localhost:5180/api/Projeto';

const postProjeto = async (Projeto) => {
    try {
        const response = await axios.post(API_URI, Projeto);
        return response.data;

    } catch (error) {
        console.error('Error posting Projeto:', error);
        throw error;

    }
}

export default postProjeto;