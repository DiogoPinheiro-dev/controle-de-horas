import '../../styles/modal.css';

const ProjectDetailsModal = ({ project, isOpen, onClose, formatDate, getProjectStatus }) => {
  if (!isOpen || !project) return null;

  return (
    <div className="modal-overlay" onClick={onClose}>
      <div className="modal-content" onClick={e => e.stopPropagation()}>
        <div className="modal-header">
          <h3 className="modal-title">Detalhes do Projeto</h3>
          <button onClick={onClose} className="close-button">
            <i className="fas fa-times"></i>
          </button>
        </div>
        <div>
          <p><strong>Nome:</strong> {project.nome}</p>
          <p><strong>Descrição:</strong> {project.descricao}</p>
          <p><strong>Data Início:</strong> {formatDate(project.dataInicio)}</p>
          <p><strong>Data Fim:</strong> {formatDate(project.dataFim)}</p>
          <p><strong>Status:</strong> {getProjectStatus(project.dataInicio, project.dataFim)}</p>
          <p><strong>Id do Gerente:</strong> {project.recursoId}</p>
          <p><strong>Id do Empresa:</strong> {project.empresaId}</p>
          <p><strong>Id do Cliente:</strong> {project.clienteId}</p>
          <p><strong>Id do Projeto:</strong> {project.projetoId}</p>
        </div>
      </div>
    </div>
  );
};

export default ProjectDetailsModal;