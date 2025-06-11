import axios from 'axios';

const API_URI = 'http://localhost:5180/api/SubTarefa';

const patchSubTarefa = async (id, SubTarefa) => {
    try {
        const response = await axios.patch(`${API_URI}/${id}`, SubTarefa);
        return response.data;

    } catch (error) {
        console.error(`Error updating SubTarefa with id ${id}:`, error);
        throw error;

    }
}

export default patchSubTarefa;