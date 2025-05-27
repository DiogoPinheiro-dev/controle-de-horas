using server.Models;

namespace server.Interfaces
{
    public interface IEmpresaClienteService
    {
        public Task RelacionarEmpresaCliente(EmpresaCliente empresaCliente);
        public Task AlterarRelacaoEmpresaCliente(EmpresaCliente empresaCliente, EmpresaCliente Body);
        public Task DeletarRelacaoEmpresaCliente(EmpresaCliente empresaCliente);

        public Task<EmpresaCliente> ObterRelacoesPorIdDaEmpresa(int idEmpresa);
        public Task<EmpresaCliente> ObterRelacoesPorIdDoCliente(int idCliente);

        public Task<List<EmpresaCliente>> ObterTodasRelacoes();
    }
}