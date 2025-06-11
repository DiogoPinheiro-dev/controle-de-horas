using server.Models;

namespace server.Interfaces
{
    public interface IUsuariosRecursosService
    {
        Task<UsuariosRecursos> ObterRelacionamentoPorId(int idUsuario, int idCliente);
        Task<List<UsuariosRecursos>> ObterRelacionamentoPorIdDeUsuario(int idUsuario);
        Task<List<UsuariosRecursos>> ObterRelacionamentoPorIdDeRecurso(int idCliente);
        Task<List<UsuariosRecursos>> ObterTodosRelacionamentos();
    }
}