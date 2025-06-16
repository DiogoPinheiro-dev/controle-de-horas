import '../../styles/project-table.css';

const ProjectTable = ({
  projects,
  onSort,
  sortConfig,
  onToggleTarefas,
  tarefasSelecionadas = [],
  onDelete,
  onEdit,
  onViewDetails,
  formatDate,
  getProjectStatus
}) => {
  const getSortIcon = (name) => {
    if (!sortConfig) return 'fas fa-sort';
    if (sortConfig.key !== name) return 'fas fa-sort';
    return sortConfig.direction === 'ascending'
      ? 'fas fa-sort-up'
      : 'fas fa-sort-down';
  };

  const getStatusClass = (status) => {
    switch (status) {
      case 'Em andamento': return 'status-active';
      case 'Concluído': return 'status-completed';
      case 'Não iniciado': return 'status-pending';
      default: return '';
    }
  };

  return (
    <div className="table-container">
      <table className="project-table">
        <thead>
          <tr>
            <th>Ações</th>
            <th onClick={() => onSort('nome')}>
              <div className="table-header">
                Nome do Projeto
                <i className={getSortIcon('nome')}></i>
              </div>
            </th>
            <th onClick={() => onSort('descricao')}>
              <div className="table-header">
                Descrição
                <i className={getSortIcon('descricao')}></i>
              </div>
            </th>
            <th onClick={() => onSort('dataInicio')}>
              <div className="table-header">
                Data Início
                <i className={getSortIcon('dataInicio')}></i>
              </div>
            </th>
            <th onClick={() => onSort('dataFim')}>
              <div className="table-header">
                Data Fim
                <i className={getSortIcon('dataFim')}></i>
              </div>
            </th>
            <th>Status</th>
          </tr>
        </thead>
        <tbody>
          {projects.length > 0 ? (
            projects.map(project => {
              const status = getProjectStatus(project.dataInicio, project.dataFim);
              return (
                <tr key={project.projetoId}>
                  <td>
                    <div className="actions btn-group btn-group-sm" role="group">
                      {
                        onToggleTarefas !== false ? (
                          <div className="form-check">
                            <input
                              type="checkbox"
                              checked={tarefasSelecionadas.includes(project.projetoId)}
                              onChange={() => onToggleTarefas && onToggleTarefas(project.projetoId)}
                              className="form-check-input"
                            />
                          </div>
                        ) : (
                          null
                        )
                      }

                      {
                        onViewDetails !== false ? (
                          <button type="button" className="btn btn-info" onClick={() => onViewDetails(project)}>
                            <i className="fas fa-eye"></i>
                          </button>
                        ) : (
                          <button type="button" disabled className="btn btn-info" onClick={() => alert("Voce nao ter permissao para realizar essa ação")}>
                            <i className="fas fa-eye"></i>
                          </button>
                        )
                      }

                      {
                        onEdit !== false ? (
                          <button type="button" className="btn btn-warning" onClick={() => onEdit(project)} style={{ marginLeft: 6 }}>
                            <i className="fas fa-edit"></i>
                          </button>
                        ) : (
                          <button type="button" disabled className="btn btn-warning" onClick={() => alert("Voce nao ter permissao para realizar essa ação")}>
                            <i className="fas fa-edit"></i>
                          </button>
                        )
                      }

                      {
                        onDelete !== false ? (
                          <button type="button" className="btn btn-danger" onClick={() => onDelete(project.projetoId)}>
                            <i className="fas fa-trash"></i>
                          </button>
                        ) : (
                          <button type="button" disabled className="btn btn-danger" onClick={() => alert("Voce nao ter permissao para realizar essa ação")}>
                            <i className="fas fa-trash"></i>
                          </button>
                        )
                      }

                    </div>
                  </td>
                  <td>
                    <div className="project-name">
                      <i className="fas fa-folder"></i>
                      {project.nome}
                    </div>
                  </td>
                  <td>{project.descricao}</td>
                  <td>{formatDate(project.dataInicio)}</td>
                  <td>{formatDate(project.dataFim)}</td>
                  <td>
                    <span className={`status-badge ${getStatusClass(status)}`}>
                      {status}
                    </span>
                  </td>

                </tr>
              );
            })
          ) : (
            <tr>
              <td colSpan="6" className="no-Projects">
                <i className="fas fa-inbox"></i>
                <p>Nenhum projeto encontrado</p>
              </td>
            </tr>
          )}
        </tbody>
      </table>
    </div>
  );
};

export default ProjectTable;