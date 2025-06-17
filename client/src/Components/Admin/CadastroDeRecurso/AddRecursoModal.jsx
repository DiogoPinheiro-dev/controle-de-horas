import { useState } from 'react';

const AddRecursoModal = ({ isOpen, onClose, onAdd, empresas }) => {
  const [nome, setNome] = useState('');
  const [tipo, setTipo] = useState('');
  const [email, setEmail] = useState('');
  const [telefone, setTelefone] = useState('');
  const [empresaId, setEmpresaId] = useState('');

  const handleSubmit = async (e) => {
    e.preventDefault();
    await onAdd({
      nome,
      tipo,
      email,
      telefone,
      empresaId: empresaId ? parseInt(empresaId) : null
    });
    setNome('');
    setTipo('');
    setEmail('');
    setTelefone('');
    setEmpresaId('');
  };

  if (!isOpen) return null;
  return (
    <div className="modal-overlay" onClick={onClose}>
      <div className="modal-content" style={{ maxWidth: 340, width: '96vw', borderRadius: 14, boxShadow: '0 8px 32px rgba(44,62,80,0.18)', background: 'linear-gradient(135deg, #f8fafc 80%, #e3eafc 100%)', padding: '1.2rem 1rem', margin: '0 2vw' }} onClick={e => e.stopPropagation()}>
        <div className="modal-header" style={{ display: 'flex', alignItems: 'center', marginBottom: 18 }}>
          <h3 className="modal-title" style={{ flex: 1, fontWeight: 700, fontSize: 18, color: '#2d3a4a' }}>
            <i className="fas fa-plus" style={{ marginRight: 8, color: '#3498db' }}></i>
            Novo Recurso
          </h3>
          <button onClick={onClose} className="close-button" style={{ background: 'none', border: 'none', fontSize: 20, color: '#888', cursor: 'pointer' }}>
            <i className="fas fa-times"></i>
          </button>
        </div>
        <form onSubmit={handleSubmit} className="row g-3">
          <div className="col-12">
            <label className="form-label">Nome</label>
            <input type="text" className="form-control" value={nome} onChange={e => setNome(e.target.value)} required />
          </div>
          <div className="col-12">
            <label className="form-label">Tipo</label>
            <input type="text" className="form-control" value={tipo} onChange={e => setTipo(e.target.value)} required />
          </div>
          <div className="col-12">
            <label className="form-label">Email</label>
            <input type="email" className="form-control" value={email} onChange={e => setEmail(e.target.value)} required />
          </div>
          <div className="col-12">
            <label className="form-label">Telefone</label>
            <input type="text" className="form-control" value={telefone} onChange={e => setTelefone(e.target.value)} required />
          </div>
          <div className="col-12">
            <label className="form-label">Empresa</label>
            <select
              className="form-control"
              value={empresaId}
              onChange={e => setEmpresaId(e.target.value)}
              required
            >
              <option value="">Selecione a empresa</option>
              {empresas.map(emp => (
                <option key={emp.empresaId} value={emp.empresaId}>
                  {emp.empresaId} - {emp.nome}
                </option>
              ))}
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

export default AddRecursoModal;