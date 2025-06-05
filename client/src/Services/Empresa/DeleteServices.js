import axios from 'axios';

const API_URI = 'http://localhost:3000/api/Empresa';

const deleteEmpresa = async (id) => {
    try {
        const response = await axios.delete(`${API_URI}/${id}`);
        return response.data;

    } catch (error) {
        console.error(`Error deleting Empresa with id ${id}:`, error);
        throw error;

    }
}

export default deleteEmpresa;