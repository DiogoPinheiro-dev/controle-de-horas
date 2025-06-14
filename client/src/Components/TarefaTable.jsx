import '../styles/project-table.css';

const TarefaTable = ({
  tarefas,
  onAdd,
  onEdit,
  onDelete,
  formatDate
}) => {
  return (
    <>
      <div className="table-container">
        <table className="project-table">
          <thead>
            <tr>
              <th>Projeto ID</th>
              <th>Descrição</th>
              <th>Data Início</th>
              <th>Data Fim</th>
              <th>Ações</th>
            </tr>
          </thead>
          <tbody>
            {tarefas.length > 0 ? (
              tarefas.map(tarefa => (
                <tr key={tarefa.tarefaId}>
                  <td>{tarefa.projetoId}</td>
                  <td>{tarefa.descricao}</td>
                  <td>{formatDate ? formatDate(tarefa.dataIni) : tarefa.dataIni}</td>
                  <td>{formatDate ? formatDate(tarefa.dataFim) : tarefa.dataFim}</td>
                  <td>
                    <div className="actions">
                      <button
                        type="button"
                        className="btn btn-warning"
                        onClick={() => onEdit && onEdit(tarefa)}
                      >
                        <i className="fas fa-edit"></i>
                      </button>
                      <button
                        type="button"
                        className="btn btn-danger"
                        onClick={() => onDelete && onDelete(tarefa.tarefaId)}
                        style={{ marginLeft: 6 }}
                      >
                        <i className="fas fa-trash"></i>
                      </button>
                    </div>
                  </td>
                </tr>
              ))
            ) : (
              <tr>
                <td colSpan="5" className="no-Projects">
                  <i className="fas fa-inbox"></i>
                  <p>Nenhuma tarefa encontrada</p>
                </td>
              </tr>
            )}
          </tbody>
        </table>
      </div>
      {
        onAdd && (
          <div style={{ marginBottom: 16, textAlign: 'center', width: '100%' }}>
            <button className="btn btn-primary" onClick={onAdd}>
              <i className="fas fa-plus"></i> Nova Tarefa
            </button>
          </div>
        )
      }
    </>
  );
};

export default TarefaTable;