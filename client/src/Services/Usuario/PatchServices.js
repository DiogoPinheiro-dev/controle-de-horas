import axios from 'axios';

const API_URI = 'http://localhost:5180/api/Usuario';

const patchUsuario = async (id, Usuario) => {
    try {
        const response = await axios.patch(`${API_URI}/${id}`, Usuario);
        return response.data;

    } catch (error) {
        console.error(`Error updating Usuario with id ${id}:`, error);
        throw error;

    }
}

export default patchUsuario;