import { useState, useEffect } from 'react';

const EditSubTarefaModal = ({ isOpen, onClose, onEdit, subTarefa }) => {
  const [descricao, setDescricao] = useState(subTarefa?.descricao || '');
  const [dataInicio, setDataInicio] = useState(subTarefa?.dataInicio ? formatDateInput(subTarefa.dataInicio) : '');
  const [dataFim, setDataFim] = useState(subTarefa?.dataFim ? formatDateInput(subTarefa.dataFim) : '');
  const [analistaId, setAnalistaId] = useState(subTarefa?.analistaId || '');

  useEffect(() => {
    setDescricao(subTarefa?.descricao || '');
    setDataInicio(subTarefa?.dataInicio ? formatDateInput(subTarefa.dataInicio) : '');
    setDataFim(subTarefa?.dataFim ? formatDateInput(subTarefa.dataFim) : '');
    setAnalistaId(subTarefa?.analistaId || '');
  }, [subTarefa, isOpen]);

  function formatDateInput(dataInt) {
    if (!dataInt) return '';
    const str = dataInt.toString();
    if (str.length !== 8) return '';
    const ano = str.substring(0, 4);
    const mes = str.substring(4, 6);
    const dia = str.substring(6, 8);
    return `${ano}-${mes}-${dia}`;
  }

  const handleSubmit = (e) => {
    e.preventDefault();
    const subTarefaEditada = {
      ...subTarefa,
      descricao,
      dataInicio: parseInt(dataInicio.replace(/-/g, '')),
      dataFim: dataFim ? parseInt(dataFim.replace(/-/g, '')) : null,
      analistaId: parseInt(analistaId)
    };
    onEdit(subTarefaEditada);
    onClose();
  };

  if (!isOpen || !subTarefa) return null;

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
            Editar SubTarefa
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
            <label htmlFor="analistaId" className="form-label">Analista (ID)</label>
            <input
              type="number"
              className="form-control"
              id="analistaId"
              value={analistaId}
              onChange={e => setAnalistaId(e.target.value)}
              required
            />
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
};

export default EditSubTarefaModal