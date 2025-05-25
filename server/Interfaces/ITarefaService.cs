using server.Models;

namespace server.Interfaces
{
    public interface ITarefaService
    {
        Task CriarTarefa(Tarefa Tarefa);
        Task AtualizarTarefa(Tarefa Tarefa, Tarefa Body);
        Task DeletarTarefa(Tarefa Tarefa);

        Task<Tarefa> ObterTarefaPorId(int id);
        Task<List<Tarefa>> ObterTodasTarefas();
        Task<List<Tarefa>> ObterTarefaPorDescricao(string nome);
        
        Task<List<Tarefa>> ObterTarefasPorData(int dataIni, int dataFim);
    }
}