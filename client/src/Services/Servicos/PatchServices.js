import axios from 'axios';

const API_URI = 'http://localhost:3000/api/Servicos';

const patchServicos = async (id, Servicos) => {
    try {
        const response = await axios.patch(`${API_URI}/${id}`, Servicos);
        return response.data;

    } catch (error) {
        console.error(`Error updating Servicos with id ${id}:`, error);
        throw error;

    }
}

export default patchServicos;