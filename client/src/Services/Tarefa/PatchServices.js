import axios from 'axios';

const API_URI = 'http://localhost:3000/api/Tarefa';

const patchTarefa = async (id, Tarefa) => {
    try {
        const response = await axios.patch(`${API_URI}/${id}`, Tarefa);
        return response.data;

    } catch (error) {
        console.error(`Error updating Tarefa with id ${id}:`, error);
        throw error;

    }
}

export default patchTarefa;