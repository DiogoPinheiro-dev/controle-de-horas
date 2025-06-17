import { useEffect, useState } from 'react';
import { getAllEmpresas } from '../Services/Empresa/GetServices.Js';
import postEmpresa from '../Services/Empresa/PostServices.js';
import patchEmpresa from '../Services/Empresa/PatchServices.js';
import deleteEmpresa from '../Services/Empresa/DeleteServices.js';

import AdminHeader from '../Components/Admin/AdminHeader.jsx';

import AddEmpresaModal from '../components/Admin/CadastroDeEmpresa/AddEmpresaModal';
import EditEmpresaModal from '../components/Admin/CadastroDeEmpresa/EditEmpresaModal';
import EmpresaDetailsModal from '../components/Admin/CadastroDeEmpresa/EmpresaDetailsModal';
import EmpresaTable from '../components/Admin/CadastroDeEmpresa/EmpresaTable';

const CadastroDeEmpresa = () => {
  const [empresas, setEmpresas] = useState([]);
  const [isLoading, setIsLoading] = useState(true);
  const [isAddModalOpen, setIsAddModalOpen] = useState(false);
  const [isEditModalOpen, setIsEditModalOpen] = useState(false);
  const [isDetailsModalOpen, setIsDetailsModalOpen] = useState(false);
  const [empresaEditando, setEmpresaEditando] = useState(null);
  const [empresaDetalhes, setEmpresaDetalhes] = useState(null);

  useEffect(() => {
    fetchEmpresas();
  }, []);

  const fetchEmpresas = async () => {
    setIsLoading(true);
    try {
      const data = await getAllEmpresas();
      setEmpresas(data || []);
    } catch {
      setEmpresas([]);
    }
    setIsLoading(false);
  };

  // Adicionar empresa (CriarEmpresaDto: { nome, email })
  const handleAddEmpresa = async (novaEmpresa) => {
    try {
      await postEmpresa({
        nome: novaEmpresa.nome,
        email: novaEmpresa.email
      });
      setIsAddModalOpen(false);
      fetchEmpresas();
    } catch (e) {
      alert('Erro ao adicionar empresa: ' + e);
    }
  };

  // Editar empresa (AtualizarEmpresaDto: { nome, projetoId, usuarioId })
  const handleEditEmpresaClick = (empresa) => {
    setEmpresaEditando(empresa);
    setIsEditModalOpen(true);
  };

  const handleSaveEditEmpresa = async (empresaEditada) => {
    try {
      await patchEmpresa(empresaEditada.empresaId, {
        nome: empresaEditada.nome,
        projetoId: empresaEditada.projetoId,
        usuarioId: empresaEditada.usuarioId
      });
      setIsEditModalOpen(false);
      setEmpresaEditando(null);
      fetchEmpresas();
    } catch (e) {
      alert('Erro ao editar empresa: ' + e);
    }
  };

  // Deletar empresa (DeletarEmpresaDto: { empresaId })
  const handleDeleteEmpresa = async (empresaId) => {
    if (!window.confirm('Tem certeza que deseja excluir esta empresa?')) return;
    try {
      await deleteEmpresa({ empresaId });
      fetchEmpresas();
    } catch (e) {
      alert('Erro ao excluir empresa: ' + e);
    }
  };

  const handleViewDetails = (empresa) => {
    setEmpresaDetalhes(empresa);
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
          Cadastro de Empresa
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
          Adicionar Nova Empresa
        </button>
        <EmpresaTable
          empresas={empresas}
          isLoading={isLoading}
          onEdit={handleEditEmpresaClick}
          onDelete={handleDeleteEmpresa}
          onViewDetails={handleViewDetails}
        />
      </div>
      <AddEmpresaModal
        isOpen={isAddModalOpen}
        onClose={() => setIsAddModalOpen(false)}
        onAdd={handleAddEmpresa}
      />
      <EditEmpresaModal
        isOpen={isEditModalOpen}
        onClose={() => setIsEditModalOpen(false)}
        onEdit={handleSaveEditEmpresa}
        empresa={empresaEditando}
      />
      <EmpresaDetailsModal
        isOpen={isDetailsModalOpen}
        onClose={() => setIsDetailsModalOpen(false)}
        empresa={empresaDetalhes}
      />
    </div>
  );
};

export default CadastroDeEmpresa;