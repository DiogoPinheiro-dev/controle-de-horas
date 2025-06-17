const UsuarioTable = ({
  usuarios,
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
        minWidth: 400,
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
            <th>Email</th>
            <th>Nível de Usuário</th>
          </tr>
        </thead>
        <tbody>
          {isLoading ? (
            <tr>
              <td colSpan={4} style={{ textAlign: 'center', padding: 32 }}>
                Carregando...
              </td>
            </tr>
          ) : usuarios.length > 0 ? (
            usuarios.map(usuario => (
              <tr key={usuario.usuarioId}>
                <td>
                  <div className="actions btn-group btn-group-sm" role="group">
                    <button
                      type="button"
                      className="btn btn-info"
                      onClick={() => onViewDetails(usuario)}
                    >
                      <i className="fas fa-eye"></i>
                    </button>
                    <button
                      type="button"
                      className="btn btn-warning"
                      onClick={() => onEdit(usuario)}
                      style={{ marginLeft: 6 }}
                    >
                      <i className="fas fa-edit"></i>
                    </button>
                    <button
                      type="button"
                      className="btn btn-danger"
                      onClick={() => onDelete(usuario.usuarioId)}
                      style={{ marginLeft: 6 }}
                    >
                      <i className="fas fa-trash"></i>
                    </button>
                  </div>
                </td>
                <td>{usuario.usuarioId}</td>
                <td>{usuario.email}</td>
                <td>{usuario.nivelDeUsuario}</td>
              </tr>
            ))
          ) : (
            <tr>
              <td colSpan={4} style={{ textAlign: 'center', padding: 32 }}>
                Nenhum usuário encontrado.
              </td>
            </tr>
          )}
        </tbody>
      </table>
    </div>
  );
};

export default UsuarioTable;