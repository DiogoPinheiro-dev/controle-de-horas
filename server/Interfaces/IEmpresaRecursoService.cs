using server.Models;

namespace server.Interfaces
{
    public interface IEmpresaRecursoService
    {
        public Task<List<EmpresaRecurso>> ObterRelacoesPorIdDaEmpresa(int idEmpresa);
        public Task<List<EmpresaRecurso>> ObterRelacoesPorIdDoRecurso(int idRecurso);
        
        public Task<EmpresaRecurso> ObterRelacaoPorId(int idRecurso, int idEmpresa);

        public Task<List<EmpresaRecurso>> ObterTodasRelacoes();
    }
}