using server.Models;

namespace server.Interfaces
{
    public interface IServicoService
    {
        Task CriarServico(Servico servico);
        Task AtualizarServico(Servico servico, Servico body);
        Task DeletarServico(Servico servico);

        Task<Servico> ObterServicoPorId(int id);
        Task<List<Servico>> ObterTodosServicos();
        Task<List<Servico>> ObterServicoPorCusto(decimal custoIni, decimal custofim);
        Task<List<Servico>> ObterServicoPorDescricao(string descricao);
    }
}