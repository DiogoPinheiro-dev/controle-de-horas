using Microsoft.EntityFrameworkCore;
using server.Db;
using server.Interfaces;
using server.Models;

namespace server.Services
{
    public class EmpresaRecursoService(AppDbContext dbContext) : IEmpresaRecursoService
    {
        private readonly AppDbContext dbContext = dbContext;

        public async Task AlterarRelacaoEmpresaRecurso(EmpresaRecurso empresaRecurso, EmpresaRecurso Body)
        {
            if (Body.RecursoId <= 0)
                empresaRecurso.RecursoId = empresaRecurso.RecursoId;
            else
                empresaRecurso.RecursoId = Body.RecursoId;

            if (Body.EmpresaId <= 0)
                empresaRecurso.EmpresaId = empresaRecurso.EmpresaId;
            else
                empresaRecurso.EmpresaId = Body.EmpresaId;

            await dbContext.SaveChangesAsync();
        }

        public async Task DeletarRelacaoEmpresaRecurso(EmpresaRecurso empresaRecurso)
        {
            dbContext.EmpresaRecursos.Remove(empresaRecurso);
            await dbContext.SaveChangesAsync();
        }

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

        public async Task RelacionarEmpresaRecurso(EmpresaRecurso empresaRecurso)
        {
            await dbContext.EmpresaRecursos.AddAsync(empresaRecurso);
            await dbContext.SaveChangesAsync();
        }
    }
}