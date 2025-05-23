using server.Models;

namespace server.Interfaces
{
    public interface ITarefaService
    {
        Task CriarTarefa(Tarefa Tarefa);
        Task AtualizarTarefa(Tarefa Tarefa);
        Task DeletarTarefa(Tarefa Tarefa);

        Task<IEnumerable<Tarefa>> ObterTodosTarefas();
        Task<IEnumerable<Tarefa>> ObterTarefaPorNome(string nome);
        
        Task<IEnumerable<Tarefa>> ObterTarefasPorDataInicio(DateTime dataIni, DateTime dataFim);
    }
}