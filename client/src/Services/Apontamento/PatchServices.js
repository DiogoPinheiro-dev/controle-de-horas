import axios from 'axios';

const API_URI = 'http://localhost:3000/api/Apontamento';

const patchApontamento = async (id, apontamento) => {
    try {
        const response = await axios.patch(`${API_URI}/${id}`, apontamento);
        return response.data;

    } catch (error) {
        console.error(`Error updating apontamento with id ${id}:`, error);
        throw error;

    }
}

export default patchApontamento;