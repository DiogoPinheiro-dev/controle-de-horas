import axios from 'axios';

const API_URI = 'http://localhost:3000/api/Servicos';

const postServicos = async (Servicos) => {
    try {
        const response = await axios.post(API_URI, Servicos);
        return response.data;

    } catch (error) {
        console.error('Error posting Servicos:', error);
        throw error;

    }
}

export default postServicos;