import { useState } from 'react';
import { getRecursosByTipo } from '../../Services/Recurso/GetServices.Js';

const AddTarefasModal = ({ isOpen, onClose, onAdd, projetoId }) => {
  const [descricao, setDescricao] = useState('');
  const [dataIni, setDataIni] = useState('');
  const [recursoId, setRecursoId] = useState('');
  const [recursos, setRecursos] = useState([]);
  const [isLoadingRecursos, setIsLoadingRecursos] = useState(false);


  const handleSubmit = (e) => {
    e.preventDefault();
    const tarefa = {
      descricao,
      dataInicio: parseInt(dataIni.replace(/-/g, '')),
      projetoId: parseInt(projetoId),
      coordenadorId: parseInt(recursoId)
    };
    onAdd(tarefa);
    setDescricao('');
    setDataIni('');
    setRecursoId('');
    onClose();
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

  if (!isOpen) return null;

  return (
    <div className="modal-overlay" onClick={onClose}>
      <div className="modal-content" style={{ maxWidth: 340, width: '96vw', borderRadius: 14, boxShadow: '0 8px 32px rgba(44,62,80,0.18)', background: 'linear-gradient(135deg, #f8fafc 80%, #e3eafc 100%)', padding: '1.2rem 1rem', margin: '0 2vw' }} onClick={e => e.stopPropagation()}>
        <div className="modal-header" style={{ display: 'flex', alignItems: 'center', marginBottom: 18 }}>
          <h3 className="modal-title" style={{ flex: 1, fontWeight: 700, fontSize: 18, color: '#2d3a4a' }}>
            <i className="fas fa-tasks" style={{ marginRight: 8, color: '#3498db' }}></i>
            Nova Tarefa
          </h3>
          <button onClick={onClose} className="close-button" style={{ background: 'none', border: 'none', fontSize: 20, color: '#888', cursor: 'pointer' }}>
            <i className="fas fa-times"></i>
          </button>
        </div>
        <form onSubmit={handleSubmit} className="row g-3">
          <div className="col-12">
            <label htmlFor="idProjeto" className="form-label">Id Do Projeto</label>
            <input type="integer" className="form-control" id="idProjeto" value={projetoId} readOnly disabled required />
          </div>
          <div className="col-12">
            <label htmlFor="descricao" className="form-label">Descrição</label>
            <input type="text" className="form-control" id="descricao" value={descricao} onChange={e => setDescricao(e.target.value)} required />
          </div>
          <div className="col-md-6">
            <label htmlFor="dataIni" className="form-label">Data Início</label>
            <input type="date" className="form-control" id="dataIni" value={dataIni} onChange={e => setDataIni(e.target.value)} required />
          </div>
          <div className="col-12">
            <label htmlFor="recursoId" className="form-label">Responsável</label>
            <select id="recursoId" className="form-select" value={recursoId} onChange={e => setRecursoId(e.target.value)} onClick={handleRecursosDropdown} required>
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
              Adicionar
            </button>
          </div>
        </form>
      </div>
    </div>
  );
};

export default AddTarefasModal