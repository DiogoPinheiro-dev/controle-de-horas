using server.Models;

namespace server.Interfaces
{
    public interface ITarefaService
    {
        Task<Tarefa> CriarTarefa(Tarefa Tarefa);
        Task<Tarefa> AtualizarTarefa(Tarefa Tarefa, Tarefa Body);
        Task<Tarefa> DeletarTarefa(Tarefa Tarefa);
        Task<Tarefa> ObterTarefaPorId(int id);
        Task<List<Tarefa>> ObterTodasTarefas();
        Task<List<Tarefa>> ObterTarefaPorDescricao(string nome);
        Task<List<Tarefa>> ObterTarefasPorData(int dataIni, int dataFim);
    }
}