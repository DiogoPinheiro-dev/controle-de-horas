import axios from 'axios';

const API_URI = 'http://localhost:3000/api/Tarefa';

const deleteTarefa = async (id) => {
    try {
        const response = await axios.delete(`${API_URI}/${id}`);
        return response.data;

    } catch (error) {
        console.error(`Error deleting Tarefa with id ${id}:`, error);
        throw error;

    }
}

export default deleteTarefa;