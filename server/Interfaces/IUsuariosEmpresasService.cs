using server.Models;

namespace server.Interfaces
{
    public interface IUsuariosEmpresasService
    {
        Task<UsuariosEmpresas> ObterRelacionamentoPorId(int idUsuario, int idCliente);
        Task<List<UsuariosEmpresas>> ObterRelacionamentoPorIdDeUsuario(int idUsuario);
        Task<List<UsuariosEmpresas>> ObterRelacionamentoPorIdDeEmpresa(int idCliente);
        Task<List<UsuariosEmpresas>> ObterTodosRelacionamentos();
    }
}