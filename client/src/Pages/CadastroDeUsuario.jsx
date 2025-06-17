import { useEffect, useState } from 'react';
import { getAllUsuarios } from '../Services/Usuario/GetServices.Js';
import postUsuario from '../Services/Usuario/PostServices.js';
import patchUsuario from '../Services/Usuario/PatchServices.js';
import deleteUsuario from '../Services/Usuario/DeleteServices.js';

import AdminHeader from '../Components/Admin/AdminHeader.jsx';

import AddUsuarioModal from '../components/Admin/CadastroDeUsuario/AddUsuarioModal';
import EditUsuarioModal from '../components/Admin/CadastroDeUsuario/EditUsuarioModal';
import UsuarioDetailsModal from '../components/Admin/CadastroDeUsuario/UsuarioDetailsModal';
import UsuarioTable from '../components/Admin/CadastroDeUsuario/UsuarioTable';

const CadastroDeUsuario = () => {
  const [usuarios, setUsuarios] = useState([]);
  const [isLoading, setIsLoading] = useState(true);
  const [isAddModalOpen, setIsAddModalOpen] = useState(false);
  const [isEditModalOpen, setIsEditModalOpen] = useState(false);
  const [isDetailsModalOpen, setIsDetailsModalOpen] = useState(false);
  const [usuarioEditando, setUsuarioEditando] = useState(null);
  const [usuarioDetalhes, setUsuarioDetalhes] = useState(null);

  useEffect(() => {
    fetchUsuarios();
  }, []);

  const fetchUsuarios = async () => {
    setIsLoading(true);
    try {
      const data = await getAllUsuarios();
      setUsuarios(data || []);
    } catch {
      setUsuarios([]);
    }
    setIsLoading(false);
  };

  // Adicionar usuário (CriarUsuarioDto: { Email, Senha, NivelDeUsuario })
  const handleAddUsuario = async (novoUsuario) => {
    try {
      await postUsuario({
        Email: novoUsuario.email,
        Senha: novoUsuario.senha,
        NivelDeUsuario: parseInt(novoUsuario.nivelDeUsuario)
      });
      setIsAddModalOpen(false);
      fetchUsuarios();
    } catch (e) {
      alert('Erro ao adicionar usuário: ' + e);
    }
  };

  // Editar usuário (AlterarUsuarioDto: { Senha, NivelDeUsuario })
  const handleEditUsuarioClick = (usuario) => {
    setUsuarioEditando(usuario);
    setIsEditModalOpen(true);
  };

  const handleSaveEditUsuario = async (usuarioEditado) => {
    try {
      await patchUsuario(usuarioEditado.usuarioId, {
        Senha: usuarioEditado.senha,
        NivelDeUsuario: parseInt(usuarioEditado.nivelDeUsuario)
      });
      setIsEditModalOpen(false);
      setUsuarioEditando(null);
      fetchUsuarios();
    } catch (e) {
      alert('Erro ao editar usuário: ' + e);
    }
  };

  // Deletar usuário (DeletarUsuarioDto: { UsuarioId })
  const handleDeleteUsuario = async (usuarioId) => {
    if (!window.confirm('Tem certeza que deseja excluir este usuário?')) return;
    try {
      await deleteUsuario(usuarioId);
      fetchUsuarios();
    } catch (e) {
      alert('Erro ao excluir usuário: ' + e);
    }
  };

  const handleViewDetails = (usuario) => {
    setUsuarioDetalhes(usuario);
    setIsDetailsModalOpen(true);
  };

  return (
    <div style={{
      minHeight: '100vh',
      background: 'linear-gradient(135deg, #f3f4f6 60%, #e5e7eb 100%)',
      display: 'flex',
      flexDirection: 'column',
      alignItems: 'center'
    }}>
      <AdminHeader />
      <div style={{
        width: '100%',
        maxWidth: 900,
        margin: '0 auto',
        marginTop: 48,
        display: 'flex',
        flexDirection: 'column',
        alignItems: 'center'
      }}>
        <h2 style={{
          color: '#444',
          fontWeight: 700,
          marginBottom: 32,
          letterSpacing: 1,
          textAlign: 'center'
        }}>
          Cadastro de Usuário
        </h2>
        <button
          style={{
            width: 220,
            padding: '0.8rem 0',
            marginBottom: 18,
            background: '#9ca3af',
            color: '#fff',
            border: 'none',
            borderRadius: 8,
            fontSize: 17,
            fontWeight: 600,
            cursor: 'pointer',
            transition: 'background 0.2s'
          }}
          onClick={() => setIsAddModalOpen(true)}
        >
          <i className="fas fa-plus" style={{ marginRight: 8 }}></i>
          Adicionar Novo Usuário
        </button>
        <UsuarioTable
          usuarios={usuarios}
          isLoading={isLoading}
          onEdit={handleEditUsuarioClick}
          onDelete={handleDeleteUsuario}
          onViewDetails={handleViewDetails}
        />
      </div>
      <AddUsuarioModal
        isOpen={isAddModalOpen}
        onClose={() => setIsAddModalOpen(false)}
        onAdd={handleAddUsuario}
      />
      <EditUsuarioModal
        isOpen={isEditModalOpen}
        onClose={() => setIsEditModalOpen(false)}
        onEdit={handleSaveEditUsuario}
        usuario={usuarioEditando}
      />
      <UsuarioDetailsModal
        isOpen={isDetailsModalOpen}
        onClose={() => setIsDetailsModalOpen(false)}
        usuario={usuarioDetalhes}
      />
    </div>
  );
};

export default CadastroDeUsuario;