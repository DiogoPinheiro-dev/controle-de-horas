import axios from 'axios';

const API_URI = 'http://localhost:3000/api/Recurso';

const patchRecurso = async (id, Recurso) => {
    try {
        const response = await axios.patch(`${API_URI}/${id}`, Recurso);
        return response.data;

    } catch (error) {
        console.error(`Error updating Recurso with id ${id}:`, error);
        throw error;

    }
}

export default patchRecurso;