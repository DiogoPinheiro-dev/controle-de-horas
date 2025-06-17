import { useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';

import { getRecursosByEmail } from '../Services/Recurso/GetServices.Js';

import { getTarefasByCoordenadorId } from '../Services/Tarefa/GetServices.Js';

import { getSubTarefasByTarefaId } from '../Services/SubTarefa/GetServices.js';
import postSubTarefa from '../Services/SubTarefa/PostServices.js';
import patchSubTarefa from '../Services/SubTarefa/PatchServices.js';
import deleteSubTarefa from '../Services/SubTarefa/DeleteServices.js'

import Header from '../Components/Header';
import Loading from '../Components/Loading.jsx';

import TarefaTable from '../Components/Tarefa/TarefaTable.jsx';
import TarefaDetailsModal from '../Components/Tarefa/TarefaDetailsModal.jsx';

import SubTarefaTable from '../Components/SubTarefa/SubTarefaTable';
import AddSubTarefasModal from '../Components/SubTarefa/AddSubTarefasModal.jsx';
import EditSubTarefaModal from '../Components/SubTarefa/EditSubTarefaModal.jsx';
import SubTarefaDetailsModal from '../Components/SubTarefa/SubTarefaDetailsModal.jsx'

const CoordenadorHome = () => {
    const navigate = useNavigate();
    const [email] = useState(JSON.parse(sessionStorage.getItem('login')) || JSON.parse(localStorage.getItem('login')));
    const [Coordenador, setCoordenador] = useState();

    const [filter, setFilter] = useState('');
    const [isDetailsModalOpen, setIsDetailsModalOpen] = useState(false);
    const [sortConfig, setSortConfig] = useState({ key: null, direction: 'ascending' });
    const [isLoggedIn, setIsLoggedIn] = useState(localStorage.getItem('login') || sessionStorage.getItem('login') || false);
    const [isLoading, setIsLoading] = useState(true);

    const [tarefas, setTarefas] = useState([]);
    const [tarefasSelecionadas, setTarefasSelecionadas] = useState([]);
    const [selectedTarefa, setSelectedTarefa] = useState(null);

    const [subTarefas, setSubTarefas] = useState([]);
    const [isAddSubTarefasModalOpen, setIsAddSubTarefasModalOpen] = useState(false);
    const [isEditSubTarefaModalOpen, setIsEditSubTarefaModalOpen] = useState(false);
    const [subTarefaEditando, setSubTarefaEditando] = useState(null);
    const [isSubTarefaDetailsModalOpen, setIsSubTarefaDetailsModalOpen] = useState(false);
    const [subTarefaDetalhes, setSubTarefaDetalhes] = useState(null);

    useEffect(() => {
        const fetchTarefasECoordenador = async () => {
            setIsLoading(true);
            try {
                const coordenadorData = await getRecursosByEmail(email);
                setCoordenador(coordenadorData && coordenadorData[0] ? coordenadorData[0] : null);

                if (coordenadorData && coordenadorData[0]?.recursoId) {
                    const tarefas = await getTarefasByCoordenadorId(coordenadorData[0].recursoId);
                    setTarefas(tarefas || []);
                } else {
                    setTarefas([]);
                }
            } catch {
                setCoordenador(null);
                setTarefas([]);
            }
            setIsLoading(false);
        };
        fetchTarefasECoordenador();
    }, [email]);

    useEffect(() => {
        const fetchSubTarefas = async () => {
            if (selectedTarefa) {
                const subTarefasDaTarefa = await getSubTarefasByTarefaId(selectedTarefa.tarefaId);
                setSubTarefas(subTarefasDaTarefa || []);
            } else {
                setSubTarefas([]);
            }
        };
        fetchSubTarefas();
    }, [selectedTarefa]);

    const handleSort = (key) => {
        let direction = 'ascending';

        if (sortConfig.key === key && sortConfig.direction === 'ascending') {
            direction = 'descending';
        }

        setSortConfig({ key, direction });
    };

    const filteredtarefas = (tarefas ?? []).filter(project =>
        (project.nome?.toLowerCase() || '').includes(filter.toLowerCase()) ||
        (project.descricao?.toLowerCase() || '').includes(filter.toLowerCase())
    );

    const sortedtarefas = [...filteredtarefas].sort((a, b) => {
        if (!sortConfig.key) return 0;
        let aValue = a[sortConfig.key];
        let bValue = b[sortConfig.key];

        if (sortConfig.key === 'status') {
            aValue = getTarefaStatus(a.dataInicio, a.dataFim);
            bValue = getTarefaStatus(b.dataInicio, b.dataFim);
        }

        if (aValue < bValue) return sortConfig.direction === 'ascending' ? -1 : 1;
        if (aValue > bValue) return sortConfig.direction === 'ascending' ? 1 : -1;
        return 0;
    });

    const handleViewDetails = (project) => {
        setSelectedTarefa(project);
        setIsDetailsModalOpen(true);
    };

    const handleViewSubTarefaDetails = (subTarefa) => {
        setIsSubTarefaDetailsModalOpen(true);
        setSubTarefaDetalhes(subTarefa);
    };

    const handleToggleSubTarefas = (tarefaId) => {
        setTarefasSelecionadas(prev =>
            prev.includes(tarefaId) ? [] : [tarefaId]
        );
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

    const getTarefaStatus = (startDate, endDate) => {
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
        setCoordenador(null);
        setTarefas([]);
        setSelectedTarefa(null);
        setFilter('');
        setSortConfig({ key: null, direction: 'ascending' });
        navigate('/');
    };

    const handleAddSubTarefa = async (novaSubTarefa) => {
        try {
            // console.log(novaSubTarefa)
            await postSubTarefa(novaSubTarefa);
            setIsAddSubTarefasModalOpen(false);

            window.location.reload();
        } catch (e) {
            console.error("Erro ao adicionar SubTarefa: ", e);

        }
    };

    const handleEditSubTarefaClick = (subTarefa) => {
        setSubTarefaEditando(subTarefa);
        setIsEditSubTarefaModalOpen(true);
    };

    const handleSaveEditSubTarefa = async (subTarefaEditada) => {
        try {
            await patchSubTarefa(subTarefaEditada);
            setIsEditSubTarefaModalOpen(false);
            setSubTarefaEditando(null);

            window.location.reload();
        } catch (e) {
            console.error("Erro ao Editar SubTarefa: ", e);

        }
    };

    const handleDeleteSubTarefa = async (SubTarefaId) => {
        try {
            await deleteSubTarefa(SubTarefaId);

            window.location.reload();
        } catch (e) {
            console.error("Erro ao deletar SubTarefa: ", e);
        }
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
    const selectedTarefas = tarefas.find(t => t.tarefaId === tarefasSelecionadas[0]);

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
                            <h2 className="dashboard-title">SubTarefas</h2>
                            <p className="dashboard-subtitle">Bem-vindo, {Coordenador.nome}! Aqui estão suas Tarefas e SubTarefas ativos.</p>
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
                                <i className="fas fa-project-diagram"></i>
                                <div>
                                    <div className="stat-value">{tarefas.length}</div>
                                    <div className="stat-label">tarefas</div>
                                </div>
                            </div>

                            <div className="stat-card">
                                <i className="fas fa-calendar-check"></i>
                                <div>
                                    <div className="stat-value">
                                        {tarefas.filter(p => getTarefaStatus(p.dataInicio, p.dataFim) === 'Em andamento').length}
                                    </div>
                                    <div className="stat-label">Ativos</div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div style={{ display: 'flex', gap: 24, alignItems: 'flex-start', width: '100%' }}>
                        <div style={{ flex: 1, minWidth: 320 }}>
                            <TarefaTable
                                tarefas={sortedtarefas}
                                onViewTarefaDetails={handleViewDetails}
                                onSort={handleSort}
                                sortConfig={sortConfig}
                                onAdd={false}
                                onDelete={false}
                                onEdit={false}
                                canSelect={true}
                                formatDate={formatDate}
                                getTarefaStatus={getTarefaStatus}
                                tarefasSelecionadas={tarefasSelecionadas}
                                onToggleSubTarefas={handleToggleSubTarefas}
                            />
                        </div>
                        <div style={{ flex: 1, minWidth: 320 }}>
                            {selectedTarefas ? (
                                <>
                                    <SubTarefaTable
                                        subTarefas={subTarefas}
                                        onEdit={handleEditSubTarefaClick}
                                        onDelete={handleDeleteSubTarefa}
                                        onViewSubTarefaDetails={handleViewSubTarefaDetails}
                                    />

                                    <AddSubTarefasModal
                                        isOpen={isAddSubTarefasModalOpen}
                                        onClose={() => setIsAddSubTarefasModalOpen(false)}
                                        onAdd={handleAddSubTarefa}
                                        tarefaId={selectedTarefas?.tarefaId}
                                    />

                                    <EditSubTarefaModal
                                        isOpen={isEditSubTarefaModalOpen}
                                        onClose={() => setIsEditSubTarefaModalOpen(false)}
                                        onEdit={handleSaveEditSubTarefa}
                                        subTarefa={subTarefaEditando}
                                    />

                                    <SubTarefaDetailsModal
                                        isOpen={isSubTarefaDetailsModalOpen}
                                        onClose={() => setIsSubTarefaDetailsModalOpen(false)}
                                        subTarefa={subTarefaDetalhes}
                                        formatDate={formatDate}
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
                                </div>
                            )}

                            <div style={{ marginBottom: 16, textAlign: 'center', width: '100%' }}>
                                <button className="btn btn-primary" onClick={() => {
                                    if (selectedTarefas)
                                        setIsAddSubTarefasModalOpen(true)

                                    else {
                                        alert("Selecione um projeto primeiro, antes de adicionar uma SubTarefa");
                                        setIsAddSubTarefasModalOpen(false);

                                    }
                                }}>
                                    <i className="fas fa-plus"></i> Nova SubTarefa
                                </button>
                            </div>
                        </div>
                    </div>
                </main>

            </div>
            {selectedTarefa && (
                <TarefaDetailsModal
                    tarefa={selectedTarefa}
                    isOpen={isDetailsModalOpen}
                    user={Coordenador}
                    tipo="Coordenador"
                    onClose={() => setIsDetailsModalOpen(false)}
                    formatDate={formatDate}
                    getTarefaStatus={getTarefaStatus}
                />
            )}
        </div>
    );
};

export default CoordenadorHome;