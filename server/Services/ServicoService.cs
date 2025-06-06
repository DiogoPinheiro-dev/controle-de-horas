using Microsoft.EntityFrameworkCore;
using server.Db;
using server.Models;
using server.Interfaces;

namespace server.Services
{
    public class ServicoService(AppDbContext dbContext) : IServicoService
    {
        private readonly AppDbContext dbContext = dbContext;

        public async Task<Servico> CriarServico(Servico servico)
        {
            await dbContext.Database.BeginTransactionAsync();

            var empresa = await dbContext.Empresas.FindAsync(servico.IdEmpresa);

            if (empresa == null)
            {
                await dbContext.Database.RollbackTransactionAsync();
                throw new Exception("Empresa não encontrada.");
            }

            await dbContext.Servicos.AddAsync(servico);
            await dbContext.SaveChangesAsync();

            EmpresaServico es = new()
            {
                EmpresaId = empresa.EmpresaId,
                ServicoId = servico.ServicoId
            };

            await dbContext.EmpresaServicos.AddAsync(es);
            await dbContext.SaveChangesAsync();

            await dbContext.Database.CommitTransactionAsync();

            return servico;
        }
        public async Task<Servico> AtualizarServico(Servico Servico, Servico Body)
        {
            if (Body.Descricao != null)
                Servico.Descricao = Body.Descricao;
            else
                Servico.Descricao = Servico.Descricao;

            if (Body.Custo < 0)
                Servico.Custo = Servico.Custo;
            else
                Servico.Custo = Body.Custo;

            if (Body.IdEmpresa > 0)
            {
                var empresaAtu = await dbContext.Empresas.FindAsync(Servico.IdEmpresa);
                var empresaNova = await dbContext.Empresas.FindAsync(Body.IdEmpresa);

                if (empresaNova == null || empresaAtu == null)
                {
                    throw new Exception("Empresa nao encontrada.");
                }
                else
                {
                    var esAtu = await dbContext.EmpresaServicos.FindAsync(empresaAtu.EmpresaId, Body.ServicoId);

                    dbContext.EmpresaServicos.Remove(esAtu);
                    await dbContext.SaveChangesAsync();

                    dbContext.EmpresaServicos.Add(new EmpresaServico()
                    {
                        EmpresaId = Body.IdEmpresa,
                        ServicoId = Body.ServicoId,
                    });
                    await dbContext.SaveChangesAsync();
                }
            }

            await dbContext.SaveChangesAsync();
            return Servico;
        }
        public async Task<Servico> DeletarServico(Servico Servico)
        {
            var empresaServico = dbContext.EmpresaServicos.Find(Servico.IdEmpresa, Servico.ServicoId);

            if (empresaServico != null)
            {
                dbContext.EmpresaServicos.Remove(empresaServico);
            }
            else
            {
                throw new Exception("Relação Empresa-Serviço não encontrada.");
            }
            await dbContext.SaveChangesAsync();

            dbContext.Servicos.Remove(Servico);
            await dbContext.SaveChangesAsync();

            return Servico;
        }

        public async Task<List<Servico>> ObterTodosServicos()
        {
            return await dbContext.Servicos.ToListAsync();

        }

        public async Task<Servico> ObterServicoPorId(int id)
        {
            return await dbContext.Servicos.FindAsync(id);
        }


        public async Task<List<Servico>> ObterServicoPorDescricao(string Descricao)
        {
            List<Servico> Servico;

            Servico = await dbContext
                .Servicos
                .Where(
                    r => r
                        .Descricao
                        .Contains(Descricao)
                ).ToListAsync();

            return Servico;
        }

        public async Task<List<Servico>> ObterServicoPorCusto(decimal custoIni, decimal custoFim)
        {
            List<Servico> Servico;

            Servico = await dbContext
                .Servicos
                .Where(s => s.Custo >= custoIni)
                .Where(s => s.Custo <= custoFim)
                .ToListAsync();

            return Servico;
        }
    }
}