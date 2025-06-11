import axios from 'axios';

const API_URI = 'http://localhost:5180/api/Usuario';

const postUsuario = async (Usuario) => {
    try {
        const response = await axios.post(API_URI, Usuario);
        return response.data;

    } catch (error) {
        console.error('Error posting Usuario:', error);
        throw error;

    }
}

export default postUsuario;