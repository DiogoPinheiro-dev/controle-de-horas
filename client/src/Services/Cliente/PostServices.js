import axios from 'axios';

const API_URI = 'http://localhost:5180/api/Cliente';

const postCliente = async (Cliente) => {
    try {
        const response = await axios.post(API_URI, Cliente);
        return response.data;

    } catch (error) {
        console.error('Error posting Cliente:', error);
        throw error;

    }
}

export default postCliente;