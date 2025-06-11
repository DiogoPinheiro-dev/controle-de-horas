import axios from 'axios';

const API_URI = 'http://localhost:5180/api/Tarefa';

const postTarefa = async (Tarefa) => {
    try {
        const response = await axios.post(API_URI, Tarefa);
        return response.data;

    } catch (error) {
        console.error('Error posting Tarefa:', error);
        throw error;

    }
}

export default postTarefa;