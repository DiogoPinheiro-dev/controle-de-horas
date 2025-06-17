const ClienteTable = ({
  clientes,
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
        minWidth: 600,
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
            <th>Telefone</th>
            <th>Empresa ID</th>
            <th>Usuário ID</th>
          </tr>
        </thead>
        <tbody>
          {isLoading ? (
            <tr>
              <td colSpan={8} style={{ textAlign: 'center', padding: 32 }}>
                Carregando...
              </td>
            </tr>
          ) : clientes.length > 0 ? (
            clientes.map(cliente => (
              <tr key={cliente.clienteId}>
                <td>
                  <div className="actions btn-group btn-group-sm" role="group">
                    <button
                      type="button"
                      className="btn btn-info"
                      onClick={() => onViewDetails(cliente)}
                    >
                      <i className="fas fa-eye"></i>
                    </button>
                    <button
                      type="button"
                      className="btn btn-warning"
                      onClick={() => onEdit(cliente)}
                      style={{ marginLeft: 6 }}
                    >
                      <i className="fas fa-edit"></i>
                    </button>
                    <button
                      type="button"
                      className="btn btn-danger"
                      onClick={() => onDelete(cliente.clienteId, cliente.empresaId)}
                      style={{ marginLeft: 6 }}
                    >
                      <i className="fas fa-trash"></i>
                    </button>
                  </div>
                </td>
                <td>{cliente.clienteId}</td>
                <td>{cliente.nome}</td>
                <td>{cliente.email}</td>
                <td>{cliente.telefone}</td>
                <td>{cliente.empresaId}</td>
                <td>{cliente.usuarioId}</td>
              </tr>
            ))
          ) : (
            <tr>
              <td colSpan={8} style={{ textAlign: 'center', padding: 32 }}>
                Nenhum cliente encontrado.
              </td>
            </tr>
          )}
        </tbody>
      </table>
    </div>
  );
};

export default ClienteTable;