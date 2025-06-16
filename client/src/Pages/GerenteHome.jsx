import { useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';

import { getRecursosByEmail } from '../Services/Recurso/GetServices.Js';
import { getProjetosByRecursoId } from '../Services/Projeto/GetServices.Js';

import { getTarefasByProjetoId } from '../Services/Tarefa/GetServices.js';
import postTarefa from '../Services/Tarefa/PostServices.js';
import patchTarefa from '../Services/Tarefa/PatchServices.js';
import deleteTarefa from '../Services/Tarefa/DeleteServices.js'

import Header from '../Components/Header';
import ProjectTable from '../Components/ProjectTable';
import TarefaTable from '../Components/TarefaTable';
import ProjectDetailsModal from '../Components/ProjectDetailsModal.jsx'
import Loading from '../Components/Loading.jsx';
import AddTarefasModal from '../Components/AddTarefasModal.jsx';
import EditTarefaModal from '../Components/EditTarefaModal.jsx';

const GerenteHome = () => {
    const navigate = useNavigate();
    const [email] = useState(JSON.parse(sessionStorage.getItem('login')) || JSON.parse(localStorage.getItem('login')));
    const [gerente, setGerente] = useState();
    const [tarefasSelecionadas, setTarefasSelecionadas] = useState([]);
    const [filter, setFilter] = useState('');
    const [isDetailsModalOpen, setIsDetailsModalOpen] = useState(false);
    const [sortConfig, setSortConfig] = useState({ key: null, direction: 'ascending' });
    const [isLoggedIn, setIsLoggedIn] = useState(localStorage.getItem('login') || sessionStorage.getItem('login') || false);
    const [projects, setProjects] = useState([]);
    const [selectedProject, setSelectedProject] = useState(null);
    const [tarefas, setTarefas] = useState([]);
    const [isLoading, setIsLoading] = useState(true);
    const [isAddTarefasModalOpen, setIsAddTarefasModalOpen] = useState(false);
    const [isEditTarefaModalOpen, setIsEditTarefaModalOpen] = useState(false);
    const [tarefaEditando, setTarefaEditando] = useState(null);
    const [sortConfigTarefas, setSortConfigTarefas] = useState({ key: null, direction: 'ascending' });

    useEffect(() => {
        const fetchProjetosEGerente = async () => {
            setIsLoading(true);
            try {
                const gerenteData = await getRecursosByEmail(email);
                setGerente(gerenteData && gerenteData[0] ? gerenteData[0] : null);

                if (gerenteData && gerenteData[0]?.recursoId) {
                    const projetos = await getProjetosByRecursoId(gerenteData[0].recursoId);
                    setProjects(projetos || []);

                } else {
                    setProjects([]);
                }

            } catch {
                setGerente(null);
                setProjects([]);
            }
            setIsLoading(false);
        };
        fetchProjetosEGerente();
    }, [email]);

    useEffect(() => {
        const fetchTarefas = async () => {
            if (selectedProject) {
                const tarefasProjeto = await getTarefasByProjetoId(selectedProject.projetoId);
                setTarefas(tarefasProjeto);
            } else {
                setTarefas([]);
            }
        };
        fetchTarefas();
    }, [selectedProject]);

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

    const handleToggleTarefas = (projetoId) => {
        setTarefasSelecionadas(prev => {
            if (prev.includes(projetoId)) {
                setSelectedProject(null);
                return [];
            }

            const projeto = projects.find(p => p.projetoId === projetoId);
            setSelectedProject(projeto);
            return [projetoId];
        });
    };

    const handleSortTarefas = (key) => {
        let direction = 'ascending';
        if (sortConfigTarefas.key === key && sortConfigTarefas.direction === 'ascending') {
            direction = 'descending';
        }
        setSortConfigTarefas({ key, direction });
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
        setGerente(null);
        setProjects([]);
        setSelectedProject(null);
        setFilter('');
        setSortConfig({ key: null, direction: 'ascending' });
        navigate('/');
    };

    const handleAddTarefa = async (novaTarefa) => {
        try {
            await postTarefa(novaTarefa);

            window.location.reload();
        } catch (e) {
            alert("Erro ao adicionar tarefa:", e);

        }
    };

    const handleEditTarefaClick = (tarefa) => {
        setTarefaEditando(tarefa);
        setIsEditTarefaModalOpen(true);
    };

    const handleSaveEditTarefa = async (tarefaEditada) => {
        try {
            await patchTarefa(tarefaEditada.tarefaId, tarefaEditada);

            setIsEditTarefaModalOpen(false);
            setTarefaEditando(null);

            window.location.reload();
        } catch (e) {
            alert("Erro ao editar tarefa:", e);
        }
    };

    const handleDeleteTarefa = async (tarefaId) => {
        await deleteTarefa(tarefaId);
        window.location.reload();
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
                            <h2 className="dashboard-title">Projetos</h2>
                            <p className="dashboard-subtitle">Bem-vindo, {gerente.nome}! Aqui estão seus Projetos ativos.</p>
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
                    <div style={{ display: 'flex', gap: 24, alignItems: 'flex-start', width: '100%' }}>
                        <div style={{ flex: 1, minWidth: 320 }}>
                            <ProjectTable
                                projects={sortedProjects}
                                onViewDetails={handleViewDetails}
                                onSort={handleSort}
                                sortConfig={sortConfig}
                                onAdd={false}
                                onDelete={false}
                                onEdit={false}
                                formatDate={formatDate}
                                getProjectStatus={getProjectStatus}
                                tarefasSelecionadas={tarefasSelecionadas}
                                onToggleTarefas={handleToggleTarefas}
                            />
                        </div>
                        <div style={{ flex: 1, minWidth: 320 }}>
                            {selectedProject && tarefasSelecionadas.includes(selectedProject.projetoId) ? (
                                <>
                                    <TarefaTable
                                        tarefas={tarefas}
                                        onAdd={handleAddTarefa}
                                        onEdit={handleEditTarefaClick}
                                        onDelete={handleDeleteTarefa}
                                        onSort={handleSortTarefas}
                                        sortConfig={sortConfigTarefas}
                                    />

                                    <AddTarefasModal
                                        isOpen={isAddTarefasModalOpen}
                                        onClose={() => setIsAddTarefasModalOpen(false)}
                                        onAdd={handleAddTarefa}
                                        projetoId={selectedProject.projetoId}
                                    />

                                    <EditTarefaModal
                                        isOpen={isEditTarefaModalOpen}
                                        onClose={() => setIsEditTarefaModalOpen(false)}
                                        onEdit={handleSaveEditTarefa}
                                        tarefa={tarefaEditando}
                                    />
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
                                        Selecione um projeto para visualizar as tarefas.
                                    </p>
                                </div>
                            )}

                            <div style={{ marginBottom: 16, textAlign: 'center', width: '100%' }}>
                                <button className="btn btn-primary" onClick={() => {
                                    if (selectedProject)
                                        setIsAddTarefasModalOpen(true)

                                    else {
                                        alert("Selecione um projeto primeiro, antes de adicionar uma tarefa");
                                        setIsAddTarefasModalOpen(false);

                                    }
                                }}>
                                    <i className="fas fa-plus"></i> Nova Tarefa
                                </button>
                            </div>
                        </div>
                    </div>
                </main>

            </div>
            {selectedProject && (
                <ProjectDetailsModal
                    project={selectedProject}
                    isOpen={isDetailsModalOpen}
                    user={gerente}
                    tipo="gerente"
                    onClose={() => setIsDetailsModalOpen(false)}
                    formatDate={formatDate}
                    getProjectStatus={getProjectStatus}
                />
            )}
        </div>
    );
};

export default GerenteHome;