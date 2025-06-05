import axios from 'axios';

const API_URI = 'http://localhost:3000/api/Empresa';

const postEmpresa = async (Empresa) => {
    try {
        const response = await axios.post(API_URI, Empresa);
        return response.data;

    } catch (error) {
        console.error('Error posting Empresa:', error);
        throw error;

    }
}

export default postEmpresa;