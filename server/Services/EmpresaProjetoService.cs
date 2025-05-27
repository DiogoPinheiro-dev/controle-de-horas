using Microsoft.EntityFrameworkCore;
using server.Db;
using server.Interfaces;
using server.Models;

namespace server.Services
{
    public class EmpresaProjetoService : IEmpresaProjetoService
    {
        private readonly AppDbContext dbContext;

        public EmpresaProjetoService(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AlterarRelacaoEmpresaProjeto(EmpresaProjeto empresaProjeto, EmpresaProjeto Body)
        {
            if (Body.ProjetoId <= 0)
                empresaProjeto.ProjetoId = empresaProjeto.ProjetoId;
            else
                empresaProjeto.ProjetoId = Body.ProjetoId;

            if (Body.EmpresaId <= 0)
                empresaProjeto.EmpresaId = empresaProjeto.EmpresaId;
            else
                empresaProjeto.EmpresaId = Body.EmpresaId;

            await dbContext.SaveChangesAsync();
        }

        public async Task DeletarRelacaoEmpresaProjeto(EmpresaProjeto empresaProjeto)
        {
            dbContext.Empresa_Projeto.Remove(empresaProjeto);
            await dbContext.SaveChangesAsync();
        }

        public async Task<EmpresaProjeto> ObterRelacoesPorIdDaEmpresa(int idEmpresa)
        {
            return await dbContext.Empresa_Projeto.FindAsync(idEmpresa);
        }

        public async Task<EmpresaProjeto> ObterRelacoesPorIdDoProjeto(int idProjeto)
        {
            return await dbContext.Empresa_Projeto.FindAsync(idProjeto);
        }

        public async Task<List<EmpresaProjeto>> ObterTodasRelacoes()
        {
            return await dbContext.Empresa_Projeto.ToListAsync();
        }

        public async Task RelacionarEmpresaProjeto(EmpresaProjeto empresaProjeto)
        {
            await dbContext.Empresa_Projeto.AddAsync(empresaProjeto);
            await dbContext.SaveChangesAsync();
        }
    }
}