import { useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';

import { getRecursosByEmail } from '../Services/Recurso/GetServices.Js';
import { getAllSubTarefas } from '../Services/SubTarefa/GetServices.Js';
import { getAllApontamentos } from '../Services/Apontamento/GetServices.Js';
import postApontamento from '../Services/Apontamento/PostServices.js';
import patchApontamento from '../Services/Apontamento/PatchServices.js';
import deleteApontamento from '../Services/Apontamento/DeleteServices.js';

import Header from '../Components/Header';
import Loading from '../Components/Loading.jsx';

import SubTarefaTable from '../Components/SubTarefa/SubTarefaTable.jsx';
import ApontamentoTable from '../Components/Apontamento/ApontamentoTable.jsx';
import AddApontamentoModal from '../Components/Apontamento/AddApontamentoModal.jsx';
import EditApontamentoModal from '../Components/Apontamento/EditApontamentoModal.jsx';
import ViewDetailsApontamentoModal from '../Components/Apontamento/ViewDetailsApontamentoModal.jsx';
import SubTarefaDetailsModal from '../Components/SubTarefa/SubTarefaDetailsModal.jsx';

const AnalistaHome = () => {
  const navigate = useNavigate();
  const [email] = useState(JSON.parse(sessionStorage.getItem('login')) || JSON.parse(localStorage.getItem('login')));
  const [analista, setAnalista] = useState();
  const [subTarefas, setSubTarefas] = useState([]);
  const [apontamentos, setApontamentos] = useState([]);
  const [subTarefasSelecionadas, setSubTarefasSelecionadas] = useState([]);
  const [isAddApontamentoModalOpen, setIsAddApontamentoModalOpen] = useState(false);
  const [isEditApontamentoModalOpen, setIsEditApontamentoModalOpen] = useState(false);
  const [apontamentoEditando, setApontamentoEditando] = useState(null);
  const [isDetailsApontamentoModalOpen, setIsDetailsApontamentoModalOpen] = useState(false);
  const [apontamentoDetalhes, setApontamentoDetalhes] = useState(null);
  const [sortConfig, setSortConfig] = useState({ key: null, direction: 'ascending' });
  const [isLoading, setIsLoading] = useState(true);
  const [filter, setFilter] = useState('');
  const [isDetailsSubTarefaModalOpen, setIsDetailsSubTarefaModalOpen] = useState(false);
  const [subTarefaDetalhes, setSubTarefaDetalhes] = useState(null);


  useEffect(() => {
    const fetchAnalistaESubTarefas = async () => {
      setIsLoading(true);
      try {
        const analistaData = await getRecursosByEmail(email);
        setAnalista(analistaData && analistaData[0] ? analistaData[0] : null);

        if (analistaData && analistaData[0]?.recursoId) {
          const allSubTarefas = await getAllSubTarefas();
          setSubTarefas((allSubTarefas || []).filter(st => st.analistaId === analistaData[0].recursoId));
        } else {
          setSubTarefas([]);
        }
      } catch {
        setAnalista(null);
        setSubTarefas([]);
      }
      setIsLoading(false);
    };
    fetchAnalistaESubTarefas();
  }, [email]);

  useEffect(() => {
    const fetchApontamentos = async () => {
      if (!subTarefasSelecionadas[0]) {
        setApontamentos([]);
        return;
      }
      try {
        const allApontamentos = await getAllApontamentos();
        setApontamentos((allApontamentos || []).filter(a => a.subTarefaId === subTarefasSelecionadas[0]));
      } catch {
        setApontamentos([]);
      }
    };
    fetchApontamentos();
  }, [subTarefasSelecionadas]);

  const handleSort = (key) => {
    let direction = 'ascending';
    if (sortConfig.key === key && sortConfig.direction === 'ascending') {
      direction = 'descending';
    }
    setSortConfig({ key, direction });
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

  const handleAddApontamento = async (novoApontamento) => {
    try {
      await postApontamento(novoApontamento);
      setIsAddApontamentoModalOpen(false);
      window.location.reload();
    } catch (e) {
      console.error("Erro ao adicionar Apontamento: ", e);
    }
  };

  const handleEditApontamentoClick = (apontamento) => {
    setApontamentoEditando(apontamento);
    setIsEditApontamentoModalOpen(true);
  };

  const handleSaveEditApontamento = async (apontamentoEditado) => {
    try {
      await patchApontamento(apontamentoEditado.apontamentoId, apontamentoEditado);
      setIsEditApontamentoModalOpen(false);
      setApontamentoEditando(null);
      window.location.reload();
    } catch (e) {
      console.error("Erro ao Editar Apontamento: ", e);
    }
  };

  const handleDeleteApontamento = async (apontamentoId) => {
    try {
      await deleteApontamento(apontamentoId);
      window.location.reload();
    } catch (e) {
      console.error("Erro ao deletar Apontamento: ", e);
    }
  };

  const handleViewDetails = (apontamento) => {
    setIsDetailsApontamentoModalOpen(true);
    setApontamentoDetalhes(apontamento);
  };

  const handleViewSubTarefaDetails = (subTarefa) => {
    setIsDetailsSubTarefaModalOpen(true);
    setSubTarefaDetalhes(subTarefa);
  }

  const handleLogout = () => {
    localStorage.removeItem('login');
    sessionStorage.removeItem('login');
    navigate('/');
  };

  const handleToggleApontamentos = (subTarefaId) => {
    setSubTarefasSelecionadas(prev =>
      prev.includes(subTarefaId) ? [] : [subTarefaId]
    );
  };

  const selectedSubTarefa = subTarefas.find(st => st.subTarefaId === subTarefasSelecionadas[0]);

  const filteredSubTarefas = (subTarefas ?? []).filter(st =>
    (st.descricao?.toLowerCase() || '').includes(filter.toLowerCase())
  );

  const sortedSubTarefas = [...filteredSubTarefas].sort((a, b) => {
    if (!sortConfig.key) return 0;
    let aValue = a[sortConfig.key];
    let bValue = b[sortConfig.key];
    if (aValue < bValue) return sortConfig.direction === 'ascending' ? -1 : 1;
    if (aValue > bValue) return sortConfig.direction === 'ascending' ? 1 : -1;
    return 0;
  });

  if (isLoading) {
    return (
      <Loading>
        <Header
          isLoggedIn={true}
          onLogoutPress={handleLogout}
        />
      </Loading>
    );
  }

  return (
    <div className="gradient-bg">
      <div className="container">
        <Header
          isLoggedIn={true}
          onLogoutPress={handleLogout}
        />
        <main className="dashboard-content">
          <div className="dashboard-header">
            <div>
              <h2 className="dashboard-title">SubTarefas e Apontamentos</h2>
              <p className="dashboard-subtitle">Bem-vindo, {analista?.nome}! Selecione uma SubTarefa para visualizar e cadastrar Apontamentos.</p>
            </div>
          </div>
          <div className="controls">
            <div className="search-container">
              <i className="fas fa-search search-icon"></i>
              <input
                type="text"
                placeholder="Pesquisar SubTarefas..."
                className="search-input"
                value={filter}
                onChange={(e) => setFilter(e.target.value)}
              />
            </div>
            <div className="stats-container">
              <div className="stat-card">
                <i className="fas fa-tasks"></i>
                <div>
                  <div className="stat-value">{subTarefas.length}</div>
                  <div className="stat-label">SubTarefas</div>
                </div>
              </div>
            </div>
          </div>

          <div style={{ display: 'flex', gap: 24, alignItems: 'flex-start', width: '100%' }}>
            <div style={{ flex: 1, minWidth: 350, maxWidth: 600 }}>
              <SubTarefaTable
                subTarefas={sortedSubTarefas}
                onEdit={false}
                onDelete={false}
                onViewSubTarefaDetails={handleViewSubTarefaDetails}
                canSelect={true}
                subTarefasSelecionadas={subTarefasSelecionadas}
                onToggleApontamentos={handleToggleApontamentos}
                onSort={handleSort}
                sortConfig={sortConfig}
              />
            </div>
            <div style={{ flex: 1, minWidth: 350, maxWidth: 600, display: 'flex', flexDirection: 'column' }}>
              {selectedSubTarefa ? (
                <>
                  <ApontamentoTable
                    apontamentos={apontamentos}
                    onEdit={handleEditApontamentoClick}
                    onDelete={handleDeleteApontamento}
                    onViewDetails={handleViewDetails}
                    onSort={handleSort}
                    sortConfig={sortConfig}
                  />
                  <div style={{ marginTop: 16, textAlign: 'center', width: '100%' }}>
                    <button
                      className="btn btn-primary"
                      onClick={() => setIsAddApontamentoModalOpen(true)}
                      disabled={!selectedSubTarefa}
                      title={!selectedSubTarefa ? "Selecione uma SubTarefa para cadastrar um Apontamento" : ""}
                    >
                      <i className="fas fa-plus"></i> Novo Apontamento
                    </button>
                  </div>
                </>
              ) : (
                <div
                  className="table-container"
                  style={{
                    minHeight: '340px',
                    display: 'flex',
                    flexDirection: 'column',
                    alignItems: 'center',
                    justifyContent: 'center',
                    background: 'white',
                    borderRadius: '0.75rem',
                    boxShadow: '0 4px 6px rgba(0, 0, 0, 0.05)'
                  }}
                >
                  <i className="fas fa-tasks" style={{ fontSize: 48, color: '#bdbdbd', marginBottom: 16 }}></i>
                  <p style={{ color: '#888', fontSize: 18, textAlign: 'center' }}>
                    Selecione uma SubTarefa para visualizar/adicionar um Apontamento.
                  </p>
                </div>
              )}
            </div>
          </div>

          <AddApontamentoModal
            isOpen={isAddApontamentoModalOpen}
            onClose={() => setIsAddApontamentoModalOpen(false)}
            onAdd={handleAddApontamento}
            recursoId={analista?.recursoId}
            subTarefaId={selectedSubTarefa?.subTarefaId}
          />

          <EditApontamentoModal
            isOpen={isEditApontamentoModalOpen}
            onClose={() => setIsEditApontamentoModalOpen(false)}
            onEdit={handleSaveEditApontamento}
            apontamento={apontamentoEditando}
          />

          <ViewDetailsApontamentoModal
            isOpen={isDetailsApontamentoModalOpen}
            onClose={() => setIsDetailsApontamentoModalOpen(false)}
            apontamento={apontamentoDetalhes}
            formatDate={formatDate}
          />
        </main>
      </div>
      {
        isDetailsSubTarefaModalOpen &&
        <SubTarefaDetailsModal
          subTarefa={subTarefaDetalhes}
          isOpen={isDetailsSubTarefaModalOpen}
          user={analista}
          tipo="Analista"
          onClose={() => setIsDetailsSubTarefaModalOpen(false)}
          formatDate={formatDate}
        />
      }

    </div>
  );
};

export default AnalistaHome