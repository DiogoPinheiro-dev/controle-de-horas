using server.Models;

namespace server.Interfaces
{
    public interface IUsuariosClientesService
    {
        Task<UsuariosClientes> ObterRelacionamentoPorId(int idUsuario, int idCliente);
        Task<List<UsuariosClientes>> ObterRelacionamentoPorIdDeUsuario(int idUsuario);
        Task<List<UsuariosClientes>> ObterRelacionamentoPorIdDeCliente(int idCliente);
        Task<List<UsuariosClientes>> ObterTodosRelacionamentos();
    }
}