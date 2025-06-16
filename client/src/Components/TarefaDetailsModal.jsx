import '../styles/modal.css';

const TarefaDetailsModal = ({ tarefa, isOpen, onClose, formatDate, getTarefaStatus }) => {
  if (!isOpen || !tarefa) return null;
  return (
    <div className="modal-overlay" onClick={onClose}>
      <div className="modal-content" onClick={e => e.stopPropagation()}>
        <div className="modal-header">
          <h3 className="modal-title">Detalhes da Tarefa</h3>
          <button onClick={onClose} className="close-button">
            <i className="fas fa-times"></i>
          </button>
        </div>
        <div>
          <p><strong>Descrição:</strong> {tarefa.descricao}</p>
          <p><strong>Data Início:</strong> {formatDate(tarefa.dataInicio)}</p>
          <p><strong>Data Fim:</strong> {formatDate(tarefa.dataFim)}</p>
          <p><strong>Status:</strong> {getTarefaStatus(tarefa.dataInicio, tarefa.dataFim)}</p>
          <p><strong>Id do Coordenador:</strong> {tarefa.coordenadorId}</p>
          <p><strong>Id da Tarefa:</strong> {tarefa.tarefaId}</p>
        </div>
      </div>
    </div>
  );
};

export default TarefaDetailsModal;