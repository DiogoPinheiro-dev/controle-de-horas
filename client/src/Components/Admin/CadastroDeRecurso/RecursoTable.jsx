import { useState } from 'react';

const RecursoTable = ({ recursos, onEdit, onDelete, onViewDetails, onSort }) => {
  const [sortConfig, setSortConfig] = useState({ key: null, direction: 'ascending' });

  const handleSort = (key) => {
    let direction = 'ascending';
    if (sortConfig.key === key && sortConfig.direction === 'ascending') {
      direction = 'descending';
    }
    setSortConfig({ key, direction });
    onSort(key, direction);
  };

  const sortedRecursos = [...recursos].sort((a, b) => {
    if (!sortConfig.key) return 0;
    let aValue = a[sortConfig.key];
    let bValue = b[sortConfig.key];
    if (aValue < bValue) return sortConfig.direction === 'ascending' ? -1 : 1;
    if (aValue > bValue) return sortConfig.direction === 'ascending' ? 1 : -1;
    return 0;
  });

  const getSortIcon = (name) => {
    if (!sortConfig) return 'fas fa-sort';
    if (sortConfig.key !== name) return 'fas fa-sort';
    return sortConfig.direction === 'ascending'
      ? 'fas fa-sort-up'
      : 'fas fa-sort-down';
  };

  return (
    <div style={{
      width: '100%',
      display: 'flex',
      justifyContent: 'center',
      marginTop: 24,
      overflowX: 'auto'
    }}>
      <table className="project-table" style={{
        minWidth: 800,
        width: '100%',
        background: '#fff',
        borderRadius: 12,
        boxShadow: '0 2px 12px rgba(100,100,100,0.07)',
        overflow: 'hidden'
      }}>
        <thead>
          <tr>
            <th>Ações</th>
            <th onClick={() => handleSort('recursoId')}>
              <div className="table-header">
                ID <i className={getSortIcon('recursoId')}></i>
              </div>
            </th>
            <th onClick={() => handleSort('nome')}>
              <div className="table-header">
                Nome <i className={getSortIcon('nome')}></i>
              </div>
            </th>
            <th onClick={() => handleSort('tipo')}>
              <div className="table-header">
                Tipo <i className={getSortIcon('tipo')}></i>
              </div>
            </th>
            <th onClick={() => handleSort('email')}>
              <div className="table-header">
                Email <i className={getSortIcon('email')}></i>
              </div>
            </th>
            <th onClick={() => handleSort('telefone')}>
              <div className="table-header">
                Telefone <i className={getSortIcon('telefone')}></i>
              </div>
            </th>
            <th onClick={() => handleSort('empresaId')}>
              <div className="table-header">
                Empresa <i className={getSortIcon('empresaId')}></i>
              </div>
            </th>
          </tr>
        </thead>
        <tbody>
          {recursos.length > 0 ? (
            sortedRecursos.map(recurso => (
              <tr key={recurso.recursoId}>
                <td>
                  <div className="actions btn-group btn-group-sm" role="group">
                    <button type="button" className="btn btn-info" onClick={() => onViewDetails(recurso)}>
                      <i className="fas fa-eye"></i>
                    </button>
                    <button type="button" className="btn btn-warning" onClick={() => onEdit(recurso)} style={{ marginLeft: 6 }}>
                      <i className="fas fa-edit"></i>
                    </button>
                    <button type="button" className="btn btn-danger" onClick={() => onDelete(recurso.recursoId)} style={{ marginLeft: 6 }}>
                      <i className="fas fa-trash"></i>
                    </button>
                  </div>
                </td>
                <td>{recurso.recursoId}</td>
                <td>{recurso.nome}</td>
                <td>{recurso.tipo}</td>
                <td>{recurso.email}</td>
                <td>{recurso.telefone}</td>
                <td>{recurso.empresaId}</td>
              </tr>
            ))
          ) : (
            <tr>
              <td colSpan={7} style={{ textAlign: 'center', padding: 32 }}>
                Nenhum recurso encontrado.
              </td>
            </tr>
          )}
        </tbody>
      </table>
    </div>
  );
};

export default RecursoTable;