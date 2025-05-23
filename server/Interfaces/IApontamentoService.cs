using server.Models;

namespace server.Interfaces
{
    public interface IApontamentoService
    {
        Task CriarApontamento(Apontamento Apontamento);
        Task AtualizarApontamento(Apontamento Apontamento, Apontamento Body);
        Task DeletarApontamento(Apontamento Apontamento);

        Task<Apontamento> ObterApontamentoPorId(int id);
        Task<List<Apontamento>> ObterTodosApontamentos();
        Task<List<Apontamento>> ObterApontamentoPorOS(string OS);        
        Task<List<Apontamento>> ObterApontamentosPorData(DateOnly dataIni, DateOnly dataFim);
    }
}