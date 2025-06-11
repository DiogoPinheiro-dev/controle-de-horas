using server.Models;

namespace server.Interfaces
{
    public interface IEmpresaServicoService
    {
        public Task<List<EmpresaServico>> ObterRelacoesPorIdDaEmpresa(int idEmpresa);
        public Task<List<EmpresaServico>> ObterRelacoesPorIdDoServico(int idServico);
        
        public Task<EmpresaServico> ObterRelacaoPorId(int idServico, int idEmpresa);

        public Task<List<EmpresaServico>> ObterTodasRelacoes();
    }
}