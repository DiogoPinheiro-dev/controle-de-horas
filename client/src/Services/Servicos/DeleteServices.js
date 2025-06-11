import axios from 'axios';

const API_URI = 'http://localhost:5180/api/Servicos';

const deleteServicos = async (id) => {
    try {
        const response = await axios.delete(`${API_URI}/${id}`);
        return response.data;

    } catch (error) {
        console.error(`Error deleting Servicos with id ${id}:`, error);
        throw error;

    }
}

export default deleteServicos;