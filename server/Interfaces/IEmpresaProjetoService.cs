using server.Models;

namespace server.Interfaces
{
    public interface IEmpresaProjetoService
    {
        public Task RelacionarEmpresaProjeto(EmpresaProjeto empresaProjeto);
        public Task AlterarRelacaoEmpresaProjeto(EmpresaProjeto empresaProjeto, EmpresaProjeto Body);
        public Task DeletarRelacaoEmpresaProjeto(EmpresaProjeto empresaProjeto);

        public Task<EmpresaProjeto> ObterRelacoesPorIdDaEmpresa(int idEmpresa);
        public Task<EmpresaProjeto> ObterRelacoesPorIdDoProjeto(int idProjeto);

        public Task<List<EmpresaProjeto>> ObterTodasRelacoes();
    }
}