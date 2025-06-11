import axios from 'axios';

const API_URI = 'http://localhost:5180/api/Cliente';

const patchCliente = async (id, Cliente) => {
    try {
        const response = await axios.patch(`${API_URI}/${id}`, Cliente);
        return response.data;

    } catch (error) {
        console.error(`Error updating Cliente with id ${id}:`, error);
        throw error;

    }
}

export default patchCliente;