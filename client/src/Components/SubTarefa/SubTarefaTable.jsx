import '../../styles/project-table.css';

const SubTarefaTable = ({
  subTarefas,
  onEdit,
  onDelete,
  onViewSubTarefaDetails,
  canSelect,
  onToggleApontamentos,
  subTarefasSelecionadas = [],
  onSort,
  sortConfig
}) => {
  function formatDate(data) {
    if (!data) return '';

    const str = data.toString();

    if (str.length !== 8) return data;

    return `${str.substr(6, 2)}/${str.substr(4, 2)}/${str.substr(0, 4)}`;
  }

  const getSortIcon = (name) => {
    if (!sortConfig) return 'fas fa-sort';
    if (sortConfig.key !== name) return 'fas fa-sort';
    return sortConfig.direction === 'ascending'
      ? 'fas fa-sort-up'
      : 'fas fa-sort-down';
  };

  return (
    <div className="table-container">
      <table className="project-table">
        <thead>
          <tr>
            {canSelect && <th>Selecionar</th>}
            <th>
              <div className="table-header">
                Ações
              </div>
            </th>
            <th onClick={() => onSort && onSort('subTarefaId')}>
              <div className="table-header">
                SubTarefa ID <i className={getSortIcon('subTarefaId')}></i>
              </div>
            </th>
            <th onClick={() => onSort && onSort('descricao')}>
              <div className="table-header">
                Descrição <i className={getSortIcon('descricao')}></i>
              </div>
            </th>
            <th onClick={() => onSort && onSort('dataInicio')}>
              <div className="table-header">
                Data Início <i className={getSortIcon('dataInicio')}></i>
              </div>
            </th>
            <th onClick={() => onSort && onSort('dataFim')}>
              <div className="table-header">
                Data Fim <i className={getSortIcon('dataFim')}></i>
              </div>
            </th>
            <th onClick={() => onSort && onSort('analistaId')}>
              <div className="table-header">
                Analista <i className={getSortIcon('analistaId')}></i>
              </div>
            </th>
          </tr>
        </thead>
        <tbody>
          {subTarefas.length > 0 ? (
            subTarefas.map(subTarefa => (
              <tr key={subTarefa.subTarefaId}>
                {canSelect && (
                  <td className="actions btn-group btn-group-sm" role="group">
                    <input
                      type="checkbox"
                      name="subtarefa"
                      checked={subTarefasSelecionadas[0] === subTarefa.subTarefaId}
                      onChange={() => onToggleApontamentos(subTarefa.subTarefaId)}
                      className="form-check-input"
                    />
                  </td>

                )}
                <td>
                  <div className="actions btn-group btn-group-sm" role="group">
                    {onViewSubTarefaDetails !== false ? (
                      <button
                        type="button"
                        className="btn btn-info"
                        onClick={() => onViewSubTarefaDetails && onViewSubTarefaDetails(subTarefa)}
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