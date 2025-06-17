import { useEffect, useState } from 'react';
import { getAllRecursos } from '../Services/Recurso/GetServices.js';
import { getAllEmpresas } from '../Services/Empresa/GetServices.js';
import postRecurso from '../Services/Recurso/PostServices.js';
import patchRecurso from '../Services/Recurso/PatchServices.js';
import deleteRecurso from '../Services/Recurso/DeleteServices.js';

import AddRecursoModal from '../components/Admin/CadastroDeRecurso/AddRecursoModal';
import EditRecursoModal from '../components/Admin/CadastroDeRecurso/EditRecursoModal';
import RecursoDetailsModal from '../components/Admin/CadastroDeRecurso/RecursoDetailsModal';
import RecursoTable from '../components/Admin/CadastroDeRecurso/RecursoTable';
import AdminHeader from '../Components/Admin/AdminHeader.jsx';

const CadastroDeRecurso = () => {
  const [recursos, setRecursos] = useState([]);
  const [empresas, setEmpresas] = useState([]);
  const [isLoading, setIsLoading] = useState(true);
  const [isAddModalOpen, setIsAddModalOpen] = useState(false);
  const [isEditModalOpen, setIsEditModalOpen] = useState(false);
  const [isDetailsModalOpen, setIsDetailsModalOpen] = useState(false);
  const [recursoEditando, setRecursoEditando] = useState(null);
  const [recursoDetalhes, setRecursoDetalhes] = useState(null);

  useEffect(() => {
    fetchRecursos();
    fetchEmpresas();
  }, []);

  const fetchRecursos = async () => {
    setIsLoading(true);
    try {
      const data = await getAllRecursos();
      setRecursos(data || []);
    } catch {
      setRecursos([]);
    }
    setIsLoading(false);
  };

  const fetchEmpresas = async () => {
    try {
      const data = await getAllEmpresas();
      setEmpresas(data || []);
    } catch {
      setEmpresas([]);
    }
  };

  const handleAddRecurso = async (novoRecurso) => {
    try {
      await postRecurso(novoRecurso);
      setIsAddModalOpen(false);
      fetchRecursos();
    } catch (e) {
      alert('Erro ao adicionar recurso: ' + e);
    }
  };

  const handleEditRecursoClick = (recurso) => {
    setRecursoEditando(recurso);
    setIsEditModalOpen(true);
  };

  const handleSaveEditRecurso = async (recursoEditado) => {
    try {
      await patchRecurso(recursoEditado.recursoId, recursoEditado);
      setIsEditModalOpen(false);
      setRecursoEditando(null);
      fetchRecursos();
    } catch (e) {
      alert('Erro ao editar recurso: ' + e);
    }
  };

  const handleDeleteRecurso = async (recursoId) => {
    if (!window.confirm('Tem certeza que deseja excluir este recurso?')) return;
    try {
      await deleteRecurso(recursoId);
      fetchRecursos();
    } catch (e) {
      alert('Erro ao excluir recurso: ' + e);
    }
  };

  const handleViewDetails = (recurso) => {
    setRecursoDetalhes(recurso);
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
          Cadastro de Recurso
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
          Adicionar Novo Recurso
        </button>
        <RecursoTable
          recursos={recursos}
          isLoading={isLoading}
          onEdit={handleEditRecursoClick}
          onDelete={handleDeleteRecurso}
          onViewDetails={handleViewDetails}
        />
      </div>
      <AddRecursoModal
        isOpen={isAddModalOpen}
        onClose={() => setIsAddModalOpen(false)}
        onAdd={handleAddRecurso}
        empresas={empresas}
      />
      <EditRecursoModal
        isOpen={isEditModalOpen}
        onClose={() => setIsEditModalOpen(false)}
        onEdit={handleSaveEditRecurso}
        recurso={recursoEditando}
        empresas={empresas}
      />
      <RecursoDetailsModal
        isOpen={isDetailsModalOpen}
        onClose={() => setIsDetailsModalOpen(false)}
        recurso={recursoDetalhes}
      />
    </div>
  );
};

export default CadastroDeRecurso;