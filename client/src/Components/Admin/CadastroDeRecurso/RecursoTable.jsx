const EmpresaTable = ({
  empresas,
  isLoading,
  onEdit,
  onDelete,
  onViewDetails
}) => {
  return (
    <div style={{
      width: '100%',
      display: 'flex',
      justifyContent: 'center',
      marginTop: 24,
      overflowX: 'auto'
    }}>
      <table className="project-table" style={{
        minWidth: 500,
        width: '100%',
        background: '#fff',
        borderRadius: 12,
        boxShadow: '0 2px 12px rgba(100,100,100,0.07)',
        overflow: 'hidden'
      }}>
        <thead>
          <tr>
            <th>Ações</th>
            <th>ID</th>
            <th>Nome</th>
            <th>Email</th>
            <th>Usuário ID</th>
          </tr>
        </thead>
        <tbody>
          {isLoading ? (
            <tr>
              <td colSpan={6} style={{ textAlign: 'center', padding: 32 }}>
                Carregando...
              </td>
            </tr>
          ) : empresas.length > 0 ? (
            empresas.map(empresa => (
              <tr key={empresa.empresaId}>
                <td>
                  <div className="actions btn-group btn-group-sm" role="group">
                    <button
                      type="button"
                      className="btn btn-info"
                      onClick={() => onViewDetails(empresa)}
                    >
                      <i className="fas fa-eye"></i>
                    </button>
                    <button
                      type="button"
                      className="btn btn-warning"
                      onClick={() => onEdit(empresa)}
                      style={{ marginLeft: 6 }}
                    >
                      <i className="fas fa-edit"></i>
                    </button>
                    <button
                      type="button"
                      className="btn btn-danger"
                      onClick={() => onDelete(empresa.empresaId)}
                      style={{ marginLeft: 6 }}
                    >
                      <i className="fas fa-trash"></i>
                    </button>
                  </div>
                </td>
                <td>{empresa.empresaId}</td>
                <td>{empresa.nome}</td>
                <td>{empresa.email}</td>
                <td>{empresa.usuarioId}</td>
              </tr>
            ))
          ) : (
            <tr>
              <td colSpan={6} style={{ textAlign: 'center', padding: 32 }}>
                Nenhuma empresa encontrada.
              </td>
            </tr>
          )}
        </tbody>
      </table>
    </div>
  );
};

export default EmpresaTable;