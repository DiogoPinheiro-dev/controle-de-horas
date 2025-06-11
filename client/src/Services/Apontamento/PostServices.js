import axios from 'axios';

const API_URI = 'http://localhost:5180/api/Apontamento';

const postApontamento = async (apontamento) => {
    try {
        const response = await axios.post(API_URI, apontamento);
        return response.data;

    } catch (error) {
        console.error('Error posting apontamento:', error);
        throw error;

    }
}

export default postApontamento;