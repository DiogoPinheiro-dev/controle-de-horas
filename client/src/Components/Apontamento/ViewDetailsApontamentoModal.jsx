import '../../styles/modal.css';

const ViewDetailsApontamentoModal = ({ apontamento, isOpen, onClose, formatDate }) => {
  if (!isOpen || !apontamento) return null;

  return (
    <div className="modal-overlay" onClick={onClose}>
      <div className="modal-content" onClick={e => e.stopPropagation()}>
        <div className="modal-header">
          <h3 className="modal-title">Detalhes do Apontamento</h3>
          <button onClick={onClose} className="close-button">
            <i className="fas fa-times"></i>
          </button>
        </div>
        <div>
          <p><strong>OS:</strong> {apontamento.os}</p>
          <p><strong>Descrição:</strong> {apontamento.descricao}</p>
          <p><strong>Horas Apontadas:</strong> {apontamento.horasApontadas}</p>
          <p><strong>Horas Finalizadas:</strong> {apontamento.horasFinalizadas}</p>
          <p><strong>Data Início:</strong> {formatDate(apontamento.dataInicio)}</p>
          <p><strong>Data Fim:</strong> {formatDate(apontamento.dataFim)}</p>
          <p><strong>ID do Apontamento:</strong> {apontamento.apontamentoId}</p>
          <p><strong>ID da SubTarefa:</strong> {apontamento.subTarefaId}</p>
          <p><strong>ID do Analista:</strong> {apontamento.recursoId}</p>
        </div>
      </div>
    </div>
  );
};

export default ViewDetailsApontamentoModal;