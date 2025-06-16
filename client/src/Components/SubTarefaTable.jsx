import '../styles/project-table.css';

const SubTarefaTable = ({ subTarefas, onEdit, onDelete, onViewDetails }) => {
  function formatDate(data) {
    if (!data) return '';

    const str = data.toString();

    if (str.length !== 8) return data;
    
    return `${str.substr(6, 2)}/${str.substr(4, 2)}/${str.substr(0, 4)}`;
  }

  return (
    <div className="table-container">
      <table className="project-table">
        <thead>
          <tr>
            <th>Ações</th>
            <th>SubTarefa ID</th>
            <th>Descrição</th>
            <th>Data Início</th>
            <th>Data Fim</th>
            <th>Analista</th>
          </tr>
        </thead>
        <tbody>
          {subTarefas.length > 0 ? (
            subTarefas.map(subTarefa => (
              <tr key={subTarefa.subTarefaId}>
                <td>
                  <div className="actions">
                    {onViewDetails !== false ? (
                      <button
                        type="button"
                        className="btn btn-info"
                        onClick={() => onViewDetails && onViewDetails(subTarefa)}
                      >
                        <i className="fas fa-eye"></i>
                      </button>
                    ) : (
                      <button type="button" disabled className="btn btn-info">
                        <i className="fas fa-eye"></i>
                      </button>
                    )}

                    {onEdit !== false ? (
                      <button
                        type="button"
                        className="btn btn-warning"
                        onClick={() => onEdit && onEdit(subTarefa)}
                        style={{ marginLeft: 6 }}
                      >
                        <i className="fas fa-edit"></i>
                      </button>
                    ) : (
                      <button
                        type="button"
                        className="btn btn-warning"
                        disabled
                        style={{ marginLeft: 6 }}
                      >
                        <i className="fas fa-edit"></i>
                      </button>
                    )}

                    {onDelete !== false ? (
                      <button
                        type="button"
                        className="btn btn-danger"
                        onClick={() => onDelete && onDelete(subTarefa.subTarefaId)}
                        style={{ marginLeft: 6 }}
                      >
                        <i className="fas fa-trash"></i>
                      </button>
                    ) : (
                      <button
                        type="button"
                        className="btn btn-danger"
                        disabled
                        style={{ marginLeft: 6 }}
                      >
                        <i className="fas fa-trash"></i>
                      </button>
                    )}
                  </div>
                </td>
                <td>{subTarefa.subTarefaId}</td>
                <td>{subTarefa.descricao}</td>
                <td>{formatDate(subTarefa.dataInicio)}</td>
                <td>{formatDate(subTarefa.dataFim)}</td>
                <td>{subTarefa.analistaId}</td>

              </tr>
            ))
          ) : (
            <tr>
              <td colSpan="6" className="no-Projects">
                <i className="fas fa-inbox"></i>
                <p>Nenhuma subtarefa encontrada</p>
              </td>
            </tr>
          )}
        </tbody>
      </table>
    </div>
  );
};

export default SubTarefaTable