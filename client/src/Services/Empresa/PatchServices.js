import axios from 'axios';

const API_URI = 'http://localhost:3000/api/Empresa';

const patchEmpresa = async (id, Empresa) => {   
    try {
        const response = await axios.patch(`${API_URI}/${id}`, Empresa);
        return response.data;

    } catch (error) {
        console.error(`Error updating Empresa with id ${id}:`, error);
        throw error;

    }
}

export default patchEmpresa;