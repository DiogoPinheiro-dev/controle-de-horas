using server.Models;

namespace server.Interfaces
{
    public interface IEmpresaRecursoService
    {
        public Task RelacionarEmpresaRecurso(EmpresaRecurso empresaRecurso);
        public Task AlterarRelacaoEmpresaRecurso(EmpresaRecurso empresaRecurso, EmpresaRecurso Body);
        public Task DeletarRelacaoEmpresaRecurso(EmpresaRecurso empresaRecurso);

        public Task<EmpresaRecurso> ObterRelacoesPorIdDaEmpresa(int idEmpresa);
        public Task<EmpresaRecurso> ObterRelacoesPorIdDoRecurso(int idRecurso);

        public Task<List<EmpresaRecurso>> ObterTodasRelacoes();
    }
}