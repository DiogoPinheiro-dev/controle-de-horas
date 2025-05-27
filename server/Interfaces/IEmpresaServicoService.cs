using server.Models;

namespace server.Interfaces
{
    public interface IEmpresaServicoService
    {
        public Task RelacionarEmpresaServico(EmpresaServico empresaServico);
        public Task AlterarRelacaoEmpresaServico(EmpresaServico empresaServico, EmpresaServico Body);
        public Task DeletarRelacaoEmpresaServico(EmpresaServico empresaServico);

        public Task<EmpresaServico> ObterRelacoesPorIdDaEmpresa(int idEmpresa);
        public Task<EmpresaServico> ObterRelacoesPorIdDoServico(int idServico);

        public Task<List<EmpresaServico>> ObterTodasRelacoes();
    }
}