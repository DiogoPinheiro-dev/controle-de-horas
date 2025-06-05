import axios from 'axios';

const API_URI = 'http://localhost:3000/api/Projeto';

const deleteProjeto = async (id) => {
    try {
        const response = await axios.delete(`${API_URI}/${id}`);
        return response.data;

    } catch (error) {
        console.error(`Error deleting Projeto with id ${id}:`, error);
        throw error;

    }
}

export default deleteProjeto;