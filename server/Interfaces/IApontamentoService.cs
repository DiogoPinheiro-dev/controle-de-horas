using server.Models;

namespace server.Interfaces
{
    public interface IApontamentoService
    {
        Task<Apontamento> CriarApontamento(Apontamento apontamento);
        Task<Apontamento> AtualizarApontamento(Apontamento apontamento, Apontamento body);
        Task<Apontamento> DeletarApontamento(Apontamento apontamento);

        Task<Apontamento> ObterApontamentoPorId(int id);
        Task<List<Apontamento>> ObterProjetosPorIdDeSubTarefa(int idSubTarefa);
        Task<List<Apontamento>> ObterProjetosPorIdDeAnalista(int idAnalista);
        Task<List<Apontamento>> ObterTodosApontamentos();
        Task<List<Apontamento>> ObterApontamentoPorOS(string OS);        
        Task<List<Apontamento>> ObterApontamentosPorData(int dataIni, int dataFim);
    }
}