using Microsoft.EntityFrameworkCore;
using server.Db;
using server.Interfaces;
using server.Models;

namespace server.Services
{
    public class EmpresaRecursoService : IEmpresaRecursoService
    {
        private readonly AppDbContext dbContext;

        public EmpresaRecursoService(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

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

        public async Task<EmpresaRecurso> ObterRelacoesPorIdDaEmpresa(int idEmpresa)
        {
            return await dbContext.EmpresaRecursos.FindAsync(idEmpresa);
        }

        public async Task<EmpresaRecurso> ObterRelacoesPorIdDoRecurso(int idRecurso)
        {
            return await dbContext.EmpresaRecursos.FindAsync(idRecurso);
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