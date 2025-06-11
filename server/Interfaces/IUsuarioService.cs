using server.Models;

namespace server.Interfaces
{
    public interface IUsuarioService
    {
        Task<Usuario> CriarUsuario(Usuario usuario);
        Task<Usuario> AlterarUsuario(Usuario usuario, Usuario Body);
        Task<Usuario> DeletarUsuario(Usuario usuario);
        Task<Usuario> ObterUsuarioPorIdDeUsuario(int id);
        Task<Usuario> ObterUsuarioPorEmail(string email);
        Task<List<Usuario>> ObterUsuariosPorNivelDeUsuario(int nivelDeUsuario);
        Task<List<Usuario>> ObterTodosOsUsuarios();

    }
}