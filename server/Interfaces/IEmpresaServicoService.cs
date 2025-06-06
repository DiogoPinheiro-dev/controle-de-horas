using server.Models;

namespace server.Interfaces
{
    public interface IEmpresaServicoService
    {
        public Task<EmpresaServico> RelacionarEmpresaServico(EmpresaServico empresaServico);
        public Task<EmpresaServico> AlterarRelacaoEmpresaServico(EmpresaServico empresaServico, EmpresaServico Body);
        public Task<EmpresaServico> DeletarRelacaoEmpresaServico(EmpresaServico empresaServico);

        public Task<List<EmpresaServico>> ObterRelacoesPorIdDaEmpresa(int idEmpresa);
        public Task<List<EmpresaServico>> ObterRelacoesPorIdDoServico(int idServico);
        
        public Task<EmpresaServico> ObterRelacaoPorId(int idServico, int idEmpresa);

        public Task<List<EmpresaServico>> ObterTodasRelacoes();
    }
}