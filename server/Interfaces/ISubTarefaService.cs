using server.Models;

namespace server.Interfaces
{
    public interface ISubTarefaService
    {
        Task CriarSubTarefa(SubTarefa SubTarefa);
        Task AtualizarSubTarefa(SubTarefa SubTarefa);
        Task DeletarSubTarefa(SubTarefa SubTarefa);

        Task<IEnumerable<SubTarefa>> ObterTodosSubTarefas();
        Task<IEnumerable<SubTarefa>> ObterSubTarefaPorNome(string nome);
        
        Task<IEnumerable<SubTarefa>> ObterSubTarefasPorDataInicio(DateTime dataIni, DateTime dataFim);
    }
}