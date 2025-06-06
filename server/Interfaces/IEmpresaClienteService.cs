using server.Models;

namespace server.Interfaces
{
    public interface IEmpresaClienteService
    {
        public Task<EmpresaCliente> RelacionarEmpresaCliente(EmpresaCliente empresaCliente);
        public Task<EmpresaCliente> AlterarRelacaoEmpresaCliente(EmpresaCliente empresaCliente, EmpresaCliente Body);
        public Task<EmpresaCliente> DeletarRelacaoEmpresaCliente(EmpresaCliente empresaCliente);

        public Task<List<EmpresaCliente>> ObterRelacoesPorIdDaEmpresa(int idEmpresa);
        public Task<List<EmpresaCliente>> ObterRelacoesPorIdDoCliente(int idCliente);
        
        public Task<EmpresaCliente> ObterRelacaoPorId(int idCliente, int idEmpresa);

        public Task<List<EmpresaCliente>> ObterTodasRelacoes();
    }
}