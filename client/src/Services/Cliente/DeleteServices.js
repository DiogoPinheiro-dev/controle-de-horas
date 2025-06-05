import axios from 'axios';

const API_URI = 'http://localhost:3000/api/Cliente';

const deleteCliente = async (id) => {
    try {
        const response = await axios.delete(`${API_URI}/${id}`);
        return response.data;

    } catch (error) {
        console.error(`Error deleting Cliente with id ${id}:`, error);
        throw error;

    }
}

export default deleteCliente;