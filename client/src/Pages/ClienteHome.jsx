import { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';

import Header from '../Components/Header';
import Loading from '../Components/Loading';
import ProjectDetailsModal from '../Components/ProjectDetailsModal';
import ProjectTable from '../Components/ProjectTable';
import AddProjectModal from '../Components/AddProjectModal';
import EditProjectModal from '../Components/EditProjectModal';

import '../styles/global.css';

import { getClientesByEmail } from '../Services/Cliente/GetServices';
import { getProjetosByClienteId } from '../Services/Projeto/GetServices';
import postProjeto from '../Services/Projeto/PostServices';
import deleteProjeto from '../Services/Projeto/DeleteServices';
import patchProjeto from '../Services/Projeto/PatchServices';

const ClienteHome = () => {
  const navigate = useNavigate();
  const [email] = useState(JSON.parse(sessionStorage.getItem('login')) || JSON.parse(localStorage.getItem('login')));
  const [isLoggedIn, setIsLoggedIn] = useState(localStorage.getItem('login') || sessionStorage.getItem('login') || false);
  const [selectedProject, setSelectedProject] = useState(null);
  const [isDetailsModalOpen, setIsDetailsModalOpen] = useState(false);
  const [filter, setFilter] = useState('');
  const [cliente, setCliente] = useState(null);
  const [sortConfig, setSortConfig] = useState({ key: null, direction: 'ascending' });
  const [projects, setProjects] = useState([]);
  const [isLoading, setIsLoading] = useState(true);
  const [isAddModalOpen, setIsAddModalOpen] = useState(false);
  const [isEditModalOpen, setIsEditModalOpen] = useState(false);
  const [editProject, setEditProject] = useState(null);

  useEffect(() => {
    const fetchClienteEProjetos = async () => {
      setIsLoading(true);
      try {
        const clienteData = await getClientesByEmail(email);
        setCliente(clienteData && clienteData[0] ? clienteData[0] : null);

        if (clienteData && clienteData[0]?.clienteId) {
          const ProjectsData = await getProjetosByClienteId(clienteData[0].clienteId);
          setProjects(ProjectsData || []);
        } else {
          setProjects([]);
        }
      } catch {
        setCliente(null);
        setProjects([]);
      }
      setIsLoading(false);
    };

    fetchClienteEProjetos();
  }, [email]);

  const handleSort = (key) => {
    let direction = 'ascending';

    if (sortConfig.key === key && sortConfig.direction === 'ascending') {
      direction = 'descending';
    }

    setSortConfig({ key, direction });
  };

  const filteredProjects = (projects ?? []).filter(project =>
    (project.nome?.toLowerCase() || '').includes(filter.toLowerCase()) ||
    (project.descricao?.toLowerCase() || '').includes(filter.toLowerCase())
  );

  const sortedProjects = [...filteredProjects].sort((a, b) => {
    if (!sortConfig.key) return 0;
    let aValue = a[sortConfig.key];
    let bValue = b[sortConfig.key];

    if (sortConfig.key === 'status') {
      aValue = getProjectStatus(a.dataInicio, a.dataFim);
      bValue = getProjectStatus(b.dataInicio, b.dataFim);
    }

    if (aValue < bValue) return sortConfig.direction === 'ascending' ? -1 : 1;
    if (aValue > bValue) return sortConfig.direction === 'ascending' ? 1 : -1;
    return 0;
  });

  const handleViewDetails = (project) => {
    setSelectedProject(project);
    setIsDetailsModalOpen(true);
  };

  function formatDate(dataInt) {
    if (!dataInt) return '';
    const str = dataInt.toString();
    if (str.length !== 8) return dataInt;
    const ano = str.substring(0, 4);
    const mes = str.substring(4, 6);
    const dia = str.substring(6, 8);
    return `${dia}/${mes}/${ano}`;
  }

  const getProjectStatus = (startDate, endDate) => {
    if (!endDate) return 'Sem previsao';

    const toDate = (data) => {
      if (!data) return null;
      const str = data.toString();
      if (str.length !== 8) return null;
      return new Date(`${str.substring(0, 4)}-${str.substring(4, 6)}-${str.substring(6, 8)}`);
    };

    const today = new Date();
    const start = toDate(startDate);
    const end = toDate(endDate);

    if (!start || !end) return 'Não iniciado';

    today.setHours(0, 0, 0, 0);
    start.setHours(0, 0, 0, 0);
    end.setHours(0, 0, 0, 0);

    if (today < start) return 'Não iniciado';

    if (today > end) return 'Concluído';

    return 'Em andamento';
  };

  const handleLogout = () => {
    localStorage.removeItem('login');
    sessionStorage.removeItem('login');
    setIsLoggedIn(false);
    setCliente(null);
    setProjects([]);
    setSelectedProject(null);
    setIsDetailsModalOpen(false);
    setFilter('');
    setSortConfig({ key: null, direction: 'ascending' });
    navigate('/');
  };

  if (isLoading) {
    return (
      <Loading>
        <Header
          isLoggedIn={isLoggedIn}
          onLogoutPress={handleLogout}
        />
      </ Loading >
    );
  }

  if (!cliente) {
    return (
      <div className="gradient-bg">
        <div className="container">
          <Header
            isLoggedIn={isLoggedIn}
            onLogoutPress={handleLogout}
          />
          <main className="dashboard-content">
            <h2>Cliente não encontrado.</h2>
          </main>
        </div>
      </div>
    );
  }

  const handleAddProject = async (newProject) => {
    const novoProjeto = await postProjeto(newProject);

    setProjects(prev => [...prev, { ...novoProjeto }]);

    window.location.reload();
  };

  const handleDeleteProject = async (projetoId) => {
    if (window.confirm('Tem certeza que deseja deletar este projeto?')) {
      try {
        await deleteProjeto(projetoId);
        setProjects(prev => prev.filter(p => p.projetoId !== projetoId));
      } catch {
        alert('Erro ao deletar projeto.');
      }
    }
  };

  const handleEditProject = (project) => {
    setEditProject(project);
    setIsEditModalOpen(true);
  };

  const handleSaveEditProject = async (editedFields) => {
    if (!editProject) return;
    try {
      await patchProjeto(editProject.projetoId, editedFields);
      setProjects(prev =>
        prev.map(p =>
          p.projetoId === editProject.projetoId
            ? { ...p, ...editedFields }
            : p
        )
      );
      setIsEditModalOpen(false);
      setEditProject(null);
      window.location.reload();
    } catch {
      alert('Erro ao editar projeto.');
    }
  };

  return (
    <div className="gradient-bg">
      <div className="container">
        <Header
          isLoggedIn={isLoggedIn}
          onLogoutPress={handleLogout}
        />

        <main className="dashboard-content">
          <div className="dashboard-header">
            <div>
              <h2 className="dashboard-title">Meus Projetos</h2>
              <p className="dashboard-subtitle">Bem-vindo, {cliente.nome}! Aqui estão seus Projetos ativos.</p>
            </div>
          </div>

          <div className="controls">
            <div className="search-container">
              <i className="fas fa-search search-icon"></i>
              <input
                type="text"
                placeholder="Pesquisar Projetos..."
                className="search-input"
                value={filter}
                onChange={(e) => setFilter(e.target.value)}
              />
            </div>

            <div className="stats-container">
              <div className="stat-card">
                <i className="fas fa-project-diagram"></i>
                <div>
                  <div className="stat-value">{projects.length}</div>
                  <div className="stat-label">Projects</div>
                </div>
              </div>

              <div className="stat-card">
                <i className="fas fa-calendar-check"></i>
                <div>
                  <div className="stat-value">
                    {projects.filter(p => getProjectStatus(p.dataInicio, p.dataFim) === 'Em andamento').length}
                  </div>
                  <div className="stat-label">Ativos</div>
                </div>
              </div>
            </div>
          </div>

          <ProjectTable
            projects={sortedProjects}
            onSort={handleSort}
            sortConfig={sortConfig}
            onViewDetails={handleViewDetails}
            onDelete={handleDeleteProject}
            onEdit={handleEditProject}
            formatDate={formatDate}
            getProjectStatus={getProjectStatus}
            tarefasSelecionadas={null}
            onToggleTarefas={false}
          />

          <button
            className="new-project-btn"
            onClick={() => setIsAddModalOpen(true)}
          >
            <i className="fas fa-plus"></i> Novo Projeto
          </button>
        </main>

        <AddProjectModal
          isOpen={isAddModalOpen}
          user={cliente}
          tipo="cliente"
          onClose={() => setIsAddModalOpen(false)}
          onAdd={handleAddProject}
        />

        <EditProjectModal
          isOpen={isEditModalOpen}
          user={cliente}
          tipo="cliente"
          onClose={() => setIsEditModalOpen(false)}
          onEdit={handleSaveEditProject}
          projeto={editProject}
        />

      </div>

      {selectedProject && (
        <ProjectDetailsModal
          project={selectedProject}
          isOpen={isDetailsModalOpen}
          user={cliente}
          tipo="cliente"
          onClose={() => setIsDetailsModalOpen(false)}
          formatDate={formatDate}
          getProjectStatus={getProjectStatus}
        />
      )}
    </div>
  );
};

export default ClienteHome;