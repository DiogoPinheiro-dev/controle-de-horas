import axios from 'axios';

const API_URI = 'http://localhost:3000/api/Recurso';

const postRecurso = async (Recurso) => {
    try {
        const response = await axios.post(API_URI, Recurso);
        return response.data;

    } catch (error) {
        console.error('Error posting Recurso:', error);
        throw error;

    }
}

export default postRecurso;