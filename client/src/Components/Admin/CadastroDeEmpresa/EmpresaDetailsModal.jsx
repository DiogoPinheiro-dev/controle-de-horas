const EmpresaDetailsModal = ({ isOpen, onClose, empresa }) => {
  if (!isOpen || !empresa) return null;
  return (
    <div className="modal-overlay" onClick={onClose}>
      <div className="modal-content" style={{ maxWidth: 340, width: '96vw', borderRadius: 14, boxShadow: '0 8px 32px rgba(44,62,80,0.18)', background: 'linear-gradient(135deg, #f8fafc 80%, #e3eafc 100%)', padding: '1.2rem 1rem', margin: '0 2vw' }} onClick={e => e.stopPropagation()}>
        <div className="modal-header" style={{ display: 'flex', alignItems: 'center', marginBottom: 18 }}>
          <h3 className="modal-title" style={{ flex: 1, fontWeight: 700, fontSize: 18, color: '#2d3a4a' }}>
            <i className="fas fa-eye" style={{ marginRight: 8, color: '#3498db' }}></i>
            Detalhes da Empresa
          </h3>
          <button onClick={onClose} className="close-button" style={{ background: 'none', border: 'none', fontSize: 20, color: '#888', cursor: 'pointer' }}>
            <i className="fas fa-times"></i>
          </button>
        </div>
        <div>
          <p><strong>ID:</strong> {empresa.empresaId}</p>
          <p><strong>Nome:</strong> {empresa.nome}</p>
          <p><strong>Email:</strong> {empresa.email}</p>
          <p><strong>Usuário ID:</strong> {empresa.usuarioId}</p>
        </div>
      </div>
    </div>
  );
};

export default EmpresaDetailsModal;