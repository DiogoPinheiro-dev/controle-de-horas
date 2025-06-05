import axios from 'axios';

const API_URI = 'http://localhost:3000/api/Recurso';

const deleteRecurso = async (id) => {
    try {
        const response = await axios.delete(`${API_URI}/${id}`);
        return response.data;

    } catch (error) {
        console.error(`Error deleting Recurso with id ${id}:`, error);
        throw error;

    }
}

export default deleteRecurso;