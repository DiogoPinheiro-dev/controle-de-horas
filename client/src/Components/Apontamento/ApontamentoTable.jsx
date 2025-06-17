import '../../styles/project-table.css';

const ApontamentoTable = ({
  apontamentos,
  onEdit,
  onDelete,
  onViewDetails,
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

  const sortedApontamentos = [...apontamentos].sort((a, b) => {
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
            <th>
              <div className="table-header">
                Ações
              </div>
            </th>
            <th onClick={() => onSort && onSort('apontamentoId')}>
              <div className="table-header">
                ID
                <i className={getSortIcon('apontamentoId')}></i>
              </div>
            </th>
            <th onClick={() => onSort && onSort('os')}>
              <div className="table-header">
                OS
                <i className={getSortIcon('os')}></i>
              </div>
            </th>
            <th onClick={() => onSort && onSort('descricao')}>
              <div className="table-header">
                Descrição
                <i className={getSortIcon('descricao')}></i>
              </div>
            </th>
            <th onClick={() => onSort && onSort('horasApontadas')}>
              <div className="table-header">
                Horas Apontadas
                <i className={getSortIcon('horasApontadas')}></i>
              </div>
            </th>
            <th onClick={() => onSort && onSort('horasFinalizadas')}>
              <div className="table-header">
                Horas Finalizadas
                <i className={getSortIcon('horasFinalizadas')}></i>
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
          </tr>
        </thead>
        <tbody>
          {sortedApontamentos.length > 0 ? (
            sortedApontamentos.map(apontamento => (
              <tr key={apontamento.apontamentoId}>
                <td className="actions btn-group btn-group-sm" role="group">
                  <button
                    type="button"
                    className="btn btn-info"
                    onClick={() => onViewDetails && onViewDetails(apontamento)}
                  >
                    <i className="fas fa-eye"></i>
                  </button>
                  <button
                    type="button"
                    className="btn btn-warning"
                    onClick={() => onEdit && onEdit(apontamento)}
                    style={{ marginLeft: 6 }}
                  >
                    <i className="fas fa-edit"></i>
                  </button>
                  <button
                    type="button"
                    className="btn btn-danger"
                    onClick={() => onDelete && onDelete(apontamento.apontamentoId)}
                    style={{ marginLeft: 6 }}
                  >
                    <i className="fas fa-trash"></i>
                  </button>
                </td>
                <td>{apontamento.apontamentoId}</td>
                <td>{apontamento.os}</td>
                <td>{apontamento.descricao}</td>
                <td>{apontamento.horasApontadas}</td>
                <td>{apontamento.horasFinalizadas}</td>
                <td>{formatDate(apontamento.dataInicio)}</td>
                <td>{formatDate(apontamento.dataFim)}</td>
              </tr>
            ))
          ) : (
            <tr>
              <td colSpan="8" className="no-Projects">
                <i className="fas fa-inbox"></i>
                <p>Nenhum apontamento encontrado</p>
              </td>
            </tr>
          )}
        </tbody>
      </table>
    </div>
  );
};

export default ApontamentoTable;