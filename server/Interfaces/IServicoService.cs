using server.Models;

namespace server.Interfaces
{
    public interface IServicoService
    {
        Task CriarServico(Servico servico);
        Task AtualizarServico(Servico servico);
        Task DeletarServico(Servico servico);

        Task<IEnumerable<Servico>> ObterTodosServicos();
        Task<IEnumerable<Servico>> ObterServicoPorNome(string nome);
        Task<IEnumerable<Servico>> ObterServicoPorDescricao(string descricao);
    }
}