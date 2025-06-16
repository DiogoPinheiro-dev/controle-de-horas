import '../styles/project-table.css';

const TarefaTable = ({
  tarefas,
  onEdit,
  onDelete,
  onViewDetails,
  onToggleSubTarefas,
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

  const sortedTarefas = [...tarefas].sort((a, b) => {
    if (!sortConfig.key) return 0;

    let aValue = a[sortConfig.key];

    let bValue = b[sortConfig.key];

    if (aValue < bValue) return sortConfig.direction === 'ascending' ? -1 : 1;
    
    if (aValue > bValue) return sortConfig.direction === 'ascending' ? 1 : -1;
    
    return 0;
  });

  return (
    <div className="table-container">
      <table className="project-table">
        <thead>
          <tr>
            <th>Selecionar</th>
            <th onClick={() => onSort && onSort('projetoId')}>
              <div className="table-header">
                Projeto ID
                <i className={getSortIcon('projetoId')}></i>
              </div>
            </th>
            <th onClick={() => onSort && onSort('descricao')}>
              <div className="table-header">
                Descrição
                <i className={getSortIcon('descricao')}></i>
              </div>
            </th>
            <th onClick={() => onSort && onSort('dataInicio')}>
              <div className="table-header">
                Data Início
                <i className={getSortIcon('dataInicio')}></i>
              </div>
            </th>
            <th onClick={() => onSort && onSort('dataFim')}>
              <div className="table-header">
                Data Fim
                <i className={getSortIcon('dataFim')}></i>
              </div>
            </th>
            <th>Ações</th>
          </tr>
        </thead>
        <tbody>
          {sortedTarefas.length > 0 ? (
            sortedTarefas.map(tarefa => (
              <tr key={tarefa.tarefaId}>
                <td>
                  {onToggleSubTarefas !== false ? (
                    <input
                      type="checkbox"
                      checked={subTarefasSelecionadas.includes(tarefa.tarefaId)}
                      onChange={() => onToggleSubTarefas && onToggleSubTarefas(tarefa.tarefaId)}
                      className="form-check-input"
                    />
                  ) : null}
                </td>
                <td>{tarefa.projetoId}</td>
                <td>{tarefa.descricao}</td>
                <td>{formatDate(tarefa.dataInicio)}</td>
                <td>{formatDate(tarefa.dataFim)}</td>
                <td>
                  <div className="actions">
                    {onEdit !== false ? (
                      <button
                        type="button"
                        className="btn btn-warning"
                        onClick={() => onEdit && onEdit(tarefa)}
                      >
                        <i className="fas fa-edit"></i>
                      </button>
                    ) : (
                      <button
                        type="button"
                        className="btn btn-warning"
                        disabled
                      >
                        <i className="fas fa-edit"></i>
                      </button>
                    )}

                    {onDelete !== false ? (
                      <button
                        type="button"
                        className="btn btn-danger"
                        onClick={() => onDelete && onDelete(tarefa.tarefaId)}
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

                    {onViewDetails !== false ? (
                      <button type="button" className="btn btn-info" onClick={() => onViewDetails(tarefa)}>
                        <i className="fas fa-eye"></i>
                      </button>
                    ) : (
                      <button type="button" disabled className="btn btn-info" >
                        <i className="fas fa-eye"></i>
                      </button>
                    )}
                  </div>
                </td>
              </tr>
            ))
          ) : (
            <tr>
              <td colSpan="6" className="no-Projects">
                <i className="fas fa-inbox"></i>
                <p>Nenhuma tarefa encontrada</p>
              </td>
            </tr>
          )}
        </tbody>
      </table>
    </div>
  );
};

export default TarefaTable;