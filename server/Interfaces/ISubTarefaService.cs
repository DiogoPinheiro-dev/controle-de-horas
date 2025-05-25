using server.Models;

namespace server.Interfaces
{
    public interface ISubTarefaService
    {
        Task CriarSubTarefa(SubTarefa SubTarefa);
        Task AtualizarSubTarefa(SubTarefa SubTarefa, SubTarefa Body);
        Task DeletarSubTarefa(SubTarefa SubTarefa);

        Task<SubTarefa> ObterSubTarefaPorId(int id);
        Task<List<SubTarefa>> ObterTodasSubTarefas();
        Task<List<SubTarefa>> ObterSubTarefaPorDescricao(string Descricao);
        
        Task<List<SubTarefa>> ObterSubTarefasPorData(int dataIni, int dataFim);
    }
}