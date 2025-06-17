import { useState, useEffect } from 'react';

const EditApontamentoModal = ({ isOpen, onClose, onEdit, apontamento }) => {
  const [os, setOs] = useState(apontamento?.os || '');
  const [descricao, setDescricao] = useState(apontamento?.descricao || '');
  const [horasApontadas, setHorasApontadas] = useState(apontamento?.horasApontadas || '');
  const [horasFinalizadas, setHorasFinalizadas] = useState(apontamento?.horasFinalizadas || '');
  const [dataInicio, setDataInicio] = useState(apontamento?.dataInicio ? formatDateInput(apontamento.dataInicio) : '');
  const [dataFim, setDataFim] = useState(apontamento?.dataFim ? formatDateInput(apontamento.dataFim) : '');

  useEffect(() => {
    setOs(apontamento?.os || '');
    setDescricao(apontamento?.descricao || '');
    setHorasApontadas(apontamento?.horasApontadas || '');
    setHorasFinalizadas(apontamento?.horasFinalizadas || '');
    setDataInicio(apontamento?.dataInicio ? formatDateInput(apontamento.dataInicio) : '');
    setDataFim(apontamento?.dataFim ? formatDateInput(apontamento.dataFim) : '');
  }, [apontamento, isOpen]);

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
    const apontamentoEditado = {
      ...apontamento,
      os,
      descricao,
      horasApontadas: parseFloat(horasApontadas),
      horasFinalizadas: parseFloat(horasFinalizadas),
      dataInicio: parseInt(dataInicio.replace(/-/g, '')),
      dataFim: dataFim ? parseInt(dataFim.replace(/-/g, '')) : null
    };
    onEdit(apontamentoEditado);
    onClose();
  };

  if (!isOpen || !apontamento) return null;

  return (
    <div className="modal-overlay" onClick={onClose}>
      <div className="modal-content" style={{ maxWidth: 340, width: '96vw', borderRadius: 14, boxShadow: '0 8px 32px rgba(44,62,80,0.18)', background: 'linear-gradient(135deg, #f8fafc 80%, #e3eafc 100%)', padding: '1.2rem 1rem', margin: '0 2vw' }} onClick={e => e.stopPropagation()}>
        <div className="modal-header" style={{ display: 'flex', alignItems: 'center', marginBottom: 18 }}>
          <h3 className="modal-title" style={{ flex: 1, fontWeight: 700, fontSize: 18, color: '#2d3a4a' }}>
            <i className="fas fa-edit" style={{ marginRight: 8, color: '#3498db' }}></i>
            Editar Apontamento
          </h3>
          <button onClick={onClose} className="close-button" style={{ background: 'none', border: 'none', fontSize: 20, color: '#888', cursor: 'pointer' }}>
            <i className="fas fa-times"></i>
          </button>
        </div>
        <form onSubmit={handleSubmit} className="row g-3">
          <div className="col-12">
            <label className="form-label">OS</label>
            <input type="text" className="form-control" value={os} onChange={e => setOs(e.target.value)} required />
          </div>
          <div className="col-12">
            <label className="form-label">Descrição</label>
            <input type="text" className="form-control" value={descricao} onChange={e => setDescricao(e.target.value)} required />
          </div>
          <div className="col-md-6">
            <label className="form-label">Horas Apontadas</label>
            <input type="number" step="0.01" className="form-control" value={horasApontadas} onChange={e => setHorasApontadas(e.target.value)} required />
          </div>
          <div className="col-md-6">
            <label className="form-label">Horas Finalizadas</label>
            <input type="number" step="0.01" className="form-control" value={horasFinalizadas} onChange={e => setHorasFinalizadas(e.target.value)} required />
          </div>
          <div className="col-md-6">
            <label className="form-label">Data Início</label>
            <input type="date" className="form-control" value={dataInicio} onChange={e => setDataInicio(e.target.value)} required />
          </div>
          <div className="col-md-6">
            <label className="form-label">Data Fim</label>
            <input type="date" className="form-control" value={dataFim} onChange={e => setDataFim(e.target.value)} />
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

export default EditApontamentoModal;