import { useState, useEffect } from 'react';

import { getRecursosByTipo } from '../Services/Recurso/GetServices.Js';
import { getAllProjetos } from '../Services/Projeto/GetServices.Js';

const EditTarefaModal = ({ isOpen, onClose, onEdit, tarefa }) => {
    const [descricao, setDescricao] = useState(tarefa?.descricao || '');
    const [dataInicio, setDataInicio] = useState(tarefa?.dataInicio ? formatDateInput(tarefa.dataInicio) : '');
    const [dataFim, setDataFim] = useState(tarefa?.dataFim ? formatDateInput(tarefa.dataFim) : '');
    const [projetoId, setProjetoId] = useState(tarefa?.projetoId || '');
    const [idCoordenador, setIdCoordenador] = useState(tarefa?.coordenadorId || '');

    const [projetos, setProjetos] = useState([]);
    const [recursos, setRecursos] = useState([]);
    const [isLoadingProjetos, setIsLoadingProjetos] = useState(false);
    const [isLoadingRecursos, setIsLoadingRecursos] = useState(false);

    useEffect(() => {
        setDescricao(tarefa?.descricao || '');
        setDataInicio(tarefa?.dataInicio ? formatDateInput(tarefa.dataInicio) : '');
        setDataFim(tarefa?.dataFim ? formatDateInput(tarefa.dataFim) : '');
        setProjetoId(tarefa?.projetoId || '');
        setIdCoordenador(tarefa?.coordenadorId || '');
    }, [tarefa, isOpen]);

    function formatDateInput(dataInt) {
        if (!dataInt) return '';

        const str = dataInt.toString();

        if (str.length !== 8) return '';

        const ano = str.substring(0, 4);
        const mes = str.substring(4, 6);
        const dia = str.substring(6, 8);

        return `${ano}-${mes}-${dia}`;
    }

    const handleProjetosDropdown = async () => {
        if (projetos.length === 0 && !isLoadingProjetos) {
            setIsLoadingProjetos(true);

            try {
                const data = await getAllProjetos();
                setProjetos(data);

            } catch {
                setProjetos([]);

            }

            setIsLoadingProjetos(false);
        }
    };

    const handleRecursosDropdown = async () => {
        if (recursos.length === 0 && !isLoadingRecursos) {
            setIsLoadingRecursos(true);

            try {
                const data = await getRecursosByTipo('C');
                setRecursos(data);

            } catch {
                setRecursos([]);

            }

            setIsLoadingRecursos(false);
        }
    };

    const handleSubmit = (e) => {
        e.preventDefault();

        const tarefaEditada = {
            tarefaId: tarefa.tarefaId,
            descricao,
            dataInicio: parseInt(dataInicio.replace(/-/g, '')),
            dataFim: dataFim ? parseInt(dataFim.replace(/-/g, '')) : null,
            projetoId: parseInt(projetoId),
            coordenadorId: parseInt(idCoordenador)
        };
        onEdit(tarefaEditada);
        onClose();
    };

    if (!isOpen || !tarefa) return null;

    return (
        <div className="modal-overlay" onClick={onClose}>
            <div
                className="modal-content"
                style={{
                    maxWidth: 340,
                    width: '96vw',
                    borderRadius: 14,
                    boxShadow: '0 8px 32px rgba(44,62,80,0.18)',
                    background: 'linear-gradient(135deg, #f8fafc 80%, #e3eafc 100%)',
                    padding: '1.2rem 1rem',
                    margin: '0 2vw'
                }}
                onClick={e => e.stopPropagation()}
            >
                <div className="modal-header" style={{ display: 'flex', alignItems: 'center', marginBottom: 18 }}>
                    <h3 className="modal-title" style={{ flex: 1, fontWeight: 700, fontSize: 18, color: '#2d3a4a' }}>
                        <i className="fas fa-edit" style={{ marginRight: 8, color: '#3498db' }}></i>
                        Editar Tarefa
                    </h3>
                    <button
                        onClick={onClose}
                        className="close-button"
                        style={{
                            background: 'none',
                            border: 'none',
                            fontSize: 20,
                            color: '#888',
                            cursor: 'pointer'
                        }}
                    >
                        <i className="fas fa-times"></i>
                    </button>
                </div>
                <form onSubmit={handleSubmit} className="row g-3">
                    <div className="col-12">
                        <label htmlFor="descricao" className="form-label">Descrição</label>
                        <input
                            type="text"
                            className="form-control"
                            id="descricao"
                            value={descricao}
                            onChange={e => setDescricao(e.target.value)}
                            required
                        />
                    </div>
                    <div className="col-md-6">
                        <label htmlFor="dataInicio" className="form-label">Data Início</label>
                        <input
                            type="date"
                            className="form-control"
                            id="dataInicio"
                            value={dataInicio}
                            onChange={e => setDataInicio(e.target.value)}
                            required
                        />
                    </div>
                    <div className="col-md-6">
                        <label htmlFor="dataFim" className="form-label">Data Fim</label>
                        <input
                            type="date"
                            className="form-control"
                            id="dataFim"
                            value={dataFim}
                            onChange={e => setDataFim(e.target.value)}
                        />
                    </div>
                    <div className="col-12">
                        <label htmlFor="projetoId" className="form-label">Projeto</label>
                        <select
                            id="projetoId"
                            className="form-select"
                            value={projetoId}
                            onChange={e => setProjetoId(e.target.value)}
                            onClick={handleProjetosDropdown}
                            required
                        >
                            <option value="">Selecione...</option>
                            {isLoadingProjetos ? (
                                <option disabled>Carregando...</option>
                            ) : (
                                projetos.map(projeto => (
                                    <option key={projeto.projetoId} value={projeto.projetoId}>
                                        {projeto.nome}
                                    </option>
                                ))
                            )}
                        </select>
                    </div>
                    <div className="col-12">
                        <label htmlFor="idCoordenador" className="form-label">Responsável</label>
                        <select
                            id="idCoordenador"
                            className="form-select"
                            value={idCoordenador}
                            onChange={e => setIdCoordenador(e.target.value)}
                            onClick={handleRecursosDropdown}
                            required
                        >
                            <option value="">Selecione...</option>
                            {isLoadingRecursos ? (
                                <option disabled>Carregando...</option>
                            ) : (
                                recursos.map(recurso => (
                                    <option key={recurso.recursoId} value={recurso.recursoId}>
                                        {recurso.nome}
                                    </option>
                                ))
                            )}
                        </select>
                    </div>
                    <div className="col-12">
                        <button type="submit" className="btn btn-primary" style={{ width: '100%' }}>
                            Salvar Alterações
                        </button>
                    </div>
                </form>
            </div>
        </div>
    );
}

export default EditTarefaModal