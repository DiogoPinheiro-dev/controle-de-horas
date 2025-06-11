using Microsoft.EntityFrameworkCore;
using server.Db;
using server.Interfaces;
using server.Models;

namespace server.Services
{
    public class EmpresaRecursoService(AppDbContext dbContext) : IEmpresaRecursoService
    {
        private readonly AppDbContext dbContext = dbContext;
        
        public async Task<List<EmpresaRecurso>> ObterRelacoesPorIdDaEmpresa(int idEmpresa)
        {
            List<EmpresaRecurso> empresaRecursos;

            empresaRecursos = await dbContext.EmpresaRecursos.Where(er => er.EmpresaId == idEmpresa).ToListAsync();

            return empresaRecursos;
        }

        public async Task<List<EmpresaRecurso>> ObterRelacoesPorIdDoRecurso(int idRecurso)
        {
            List<EmpresaRecurso> empresaRecursos;

            empresaRecursos = await dbContext.EmpresaRecursos.Where(er => er.RecursoId == idRecurso).ToListAsync();

            return empresaRecursos;
        }

        public async Task<EmpresaRecurso> ObterRelacaoPorId(int idRecurso, int idEmpresa)
        {
            EmpresaRecurso empresaRecurso;

            empresaRecurso = await dbContext.EmpresaRecursos.Where(er => er.EmpresaId == idEmpresa && er.RecursoId == idRecurso).FirstAsync();

            return empresaRecurso;
        }
        public async Task<List<EmpresaRecurso>> ObterTodasRelacoes()
        {
            return await dbContext.EmpresaRecursos.ToListAsync();
        }
    }
}