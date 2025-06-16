using server.Models;

namespace server.Interfaces
{
    public interface ISubTarefaService
    {
        Task<SubTarefa> CriarSubTarefa(SubTarefa SubTarefa);
        Task<SubTarefa> AtualizarSubTarefa(SubTarefa SubTarefa, SubTarefa Body);
        Task<SubTarefa> DeletarSubTarefa(SubTarefa SubTarefa);

        Task<SubTarefa> ObterSubTarefaPorId(int id);
        Task<List<SubTarefa>> ObterSubTarefaPorIdDeAnalista(int analistaId);
        Task<List<SubTarefa>> ObterSubTarefaPorIdDeTarefa(int tarefaId);
        Task<List<SubTarefa>> ObterTodasSubTarefas();
        Task<List<SubTarefa>> ObterSubTarefaPorDescricao(string Descricao);
        Task<List<SubTarefa>> ObterSubTarefasPorData(int dataIni, int dataFim);
    }
}