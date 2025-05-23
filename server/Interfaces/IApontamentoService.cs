using server.Models;

namespace server.Interfaces
{
    public interface IApontamentoService
    {
        Task CriarApontamento(Apontamento apontamento);
        Task AtualizarApontamento(Apontamento apontamento, Apontamento body);
        Task DeletarApontamento(Apontamento apontamento);

        Task<Apontamento> ObterApontamentoPorId(int id);
        Task<List<Apontamento>> ObterTodosApontamentos();
        Task<List<Apontamento>> ObterApontamentoPorOS(string OS);        
        Task<List<Apontamento>> ObterApontamentosPorData(int dataIni, int dataFim);
    }
}