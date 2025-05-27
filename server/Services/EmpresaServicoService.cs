using Microsoft.EntityFrameworkCore;
using server.Db;
using server.Interfaces;
using server.Models;

namespace server.Services
{
    public class EmpresaServicoService : IEmpresaServicoService
    {
        private readonly AppDbContext dbContext;

        public EmpresaServicoService(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AlterarRelacaoEmpresaServico(EmpresaServico empresaServico, EmpresaServico Body)
        {
            if (Body.ServicoId <= 0)
                empresaServico.ServicoId = empresaServico.ServicoId;
            else
                empresaServico.ServicoId = Body.ServicoId;

            if (Body.EmpresaId <= 0)
                empresaServico.EmpresaId = empresaServico.EmpresaId;
            else
                empresaServico.EmpresaId = Body.EmpresaId;

            await dbContext.SaveChangesAsync();
        }

        public async Task DeletarRelacaoEmpresaServico(EmpresaServico empresaServico)
        {
            dbContext.Empresa_Servico.Remove(empresaServico);
            await dbContext.SaveChangesAsync();
        }

        public async Task<EmpresaServico> ObterRelacoesPorIdDaEmpresa(int idEmpresa)
        {
            return await dbContext.Empresa_Servico.FindAsync(idEmpresa);
        }

        public async Task<EmpresaServico> ObterRelacoesPorIdDoServico(int idServico)
        {
            return await dbContext.Empresa_Servico.FindAsync(idServico);
        }

        public async Task<List<EmpresaServico>> ObterTodasRelacoes()
        {
            return await dbContext.Empresa_Servico.ToListAsync();
        }

        public async Task RelacionarEmpresaServico(EmpresaServico empresaServico)
        {
            await dbContext.Empresa_Servico.AddAsync(empresaServico);
            await dbContext.SaveChangesAsync();
        }
    }
}