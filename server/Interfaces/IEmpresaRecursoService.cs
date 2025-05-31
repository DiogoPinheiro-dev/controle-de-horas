using server.Models;

namespace server.Interfaces
{
    public interface IEmpresaRecursoService
    {
        public Task RelacionarEmpresaRecurso(EmpresaRecurso empresaRecurso);
        public Task AlterarRelacaoEmpresaRecurso(EmpresaRecurso empresaRecurso, EmpresaRecurso Body);
        public Task DeletarRelacaoEmpresaRecurso(EmpresaRecurso empresaRecurso);

        public Task<List<EmpresaRecurso>> ObterRelacoesPorIdDaEmpresa(int idEmpresa);
        public Task<List<EmpresaRecurso>> ObterRelacoesPorIdDoRecurso(int idRecurso);
        
        public Task<EmpresaRecurso> ObterRelacaoPorId(int idRecurso, int idEmpresa);

        public Task<List<EmpresaRecurso>> ObterTodasRelacoes();
    }
}