using Microsoft.EntityFrameworkCore;
using server.Db;
using server.Interfaces;
using server.Models;

namespace server.Services
{
    public class EmpresaServicoService(AppDbContext dbContext) : IEmpresaServicoService
    {
        private readonly AppDbContext dbContext = dbContext;

        public async Task<EmpresaServico> AlterarRelacaoEmpresaServico(EmpresaServico EmpresaServico, EmpresaServico Body)
        {
            if (Body.ServicoId <= 0)
                EmpresaServico.ServicoId = EmpresaServico.ServicoId;
            else
                EmpresaServico.ServicoId = Body.ServicoId;

            if (Body.EmpresaId <= 0)
                EmpresaServico.EmpresaId = EmpresaServico.EmpresaId;
            else
                EmpresaServico.EmpresaId = Body.EmpresaId;

            await dbContext.SaveChangesAsync();
            return EmpresaServico;
        }

        public async Task<EmpresaServico> DeletarRelacaoEmpresaServico(EmpresaServico EmpresaServico)
        {
            dbContext.EmpresaServicos.Remove(EmpresaServico);
            await dbContext.SaveChangesAsync();
            return EmpresaServico;
        }

        public async Task<List<EmpresaServico>> ObterRelacoesPorIdDaEmpresa(int idEmpresa)
        {
            List<EmpresaServico> EmpresaServicos;

            EmpresaServicos = await dbContext.EmpresaServicos.Where(er => er.EmpresaId == idEmpresa).ToListAsync();

            return EmpresaServicos;
        }

        public async Task<List<EmpresaServico>> ObterRelacoesPorIdDoServico(int idServico)
        {
            List<EmpresaServico> EmpresaServicos;

            EmpresaServicos = await dbContext.EmpresaServicos.Where(er => er.ServicoId == idServico).ToListAsync();

            return EmpresaServicos;
        }

        public async Task<EmpresaServico> ObterRelacaoPorId(int idServico, int idEmpresa)
        {
            EmpresaServico EmpresaServico;

            EmpresaServico = await dbContext.EmpresaServicos.Where(er => er.EmpresaId == idEmpresa && er.ServicoId == idServico).FirstAsync();

            return EmpresaServico;
        }
        public async Task<List<EmpresaServico>> ObterTodasRelacoes()
        {
            return await dbContext.EmpresaServicos.ToListAsync();
        }
        
        public async Task<EmpresaServico> RelacionarEmpresaServico(EmpresaServico EmpresaServico)
        {
            await dbContext.EmpresaServicos.AddAsync(EmpresaServico);
            await dbContext.SaveChangesAsync();
            return EmpresaServico;
        }
    }
}