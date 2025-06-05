using server.Models;

namespace server.Interfaces
{
    public interface IRecursoService
    {
        Task CriarRecurso(Recurso recurso);
        Task AtualizarRecurso(Recurso recurso, Recurso body);
        Task DeletarRecurso(Recurso recurso);

        Task<List<Recurso>> ObterTodosRecursos();
        Task<Recurso> ObterRecursoPorId(int id);

        Task<List<Recurso>> ObterRecursoPorNome(string nome);
        Task<List<Recurso>> ObterRecursoPorEmail(string email);
        Task<List<Recurso>> ObterRecursoPorTelefone(string telefone);
        Task<List<Recurso>> ObterRecursoPorTipo(char tipo);
    }
}