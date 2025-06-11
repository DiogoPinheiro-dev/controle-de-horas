import axios from 'axios';

const API_URI = 'http://localhost:5180/api/SubTarefa';

const postSubTarefa = async (SubTarefa) => {
    try {
        const response = await axios.post(API_URI, SubTarefa);
        return response.data;

    } catch (error) {
        console.error('Error posting SubTarefa:', error);
        throw error;

    }
}

export default postSubTarefa;