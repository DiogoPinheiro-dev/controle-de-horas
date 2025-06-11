import axios from 'axios';

const API_URL = 'http://localhost:5180/api/Usuario';

export const loginUsuario = async (email, senha) => {
  try {
    const response = await axios.get(`${API_URL}/ByEmail/${email}`);
    const usuario = response.data;

    // Verifica se encontrou o usuário e se a senha confere
    if (usuario && usuario.senha === senha) {
      return usuario;
    }
    return null;
  } catch (error) {
    console.error('Erro ao autenticar usuário:', error);
    throw error;
  }
};