import React from 'react';
import '../styles/modal.css';

const SubTarefaDetailsModal = ({ subTarefa, isOpen, onClose, formatDate }) => {
  if (!isOpen || !subTarefa) return null;

  return (
    <div className="modal-overlay" onClick={onClose}>
      <div className="modal-content" onClick={e => e.stopPropagation()}>
        <div className="modal-header">
          <h3 className="modal-title">Detalhes da SubTarefa</h3>
          <button onClick={onClose} className="close-button">
            <i className="fas fa-times"></i>
          </button>
        </div>
        <div>
          <p><strong>Descrição:</strong> {subTarefa.descricao}</p>
          <p><strong>Data Início:</strong> {formatDate(subTarefa.dataInicio)}</p>
          <p><strong>Data Fim:</strong> {formatDate(subTarefa.dataFim)}</p>
          <p><strong>ID do Analista:</strong> {subTarefa.analistaId}</p>
          <p><strong>ID da SubTarefa:</strong> {subTarefa.subTarefaId}</p>
        </div>
      </div>
    </div>
  );
};

export default SubTarefaDetailsModal;