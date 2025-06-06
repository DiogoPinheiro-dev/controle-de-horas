using server.Models;

namespace server.Interfaces
{
    public interface IServicoService
    {
        Task<Servico> CriarServico(Servico servico);
        Task<Servico> AtualizarServico(Servico servico, Servico body);
        Task<Servico> DeletarServico(Servico servico);

        Task<Servico> ObterServicoPorId(int id);
        Task<List<Servico>> ObterTodosServicos();
        Task<List<Servico>> ObterServicoPorCusto(decimal custoIni, decimal custofim);
        Task<List<Servico>> ObterServicoPorDescricao(string descricao);
    }
}