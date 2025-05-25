using Microsoft.EntityFrameworkCore;
using server.Db;
using server.Models;
using server.Interfaces;

namespace server.Services
{
    public class ServicoService : IServicoService
    {
        private readonly AppDbContext dbContext;

        public ServicoService(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task CriarServico(Servico Servico)
        {
            dbContext.Servicos.Add(Servico);
            await dbContext.SaveChangesAsync();
        }
        public async Task AtualizarServico(Servico Servico, Servico Body)
        {
            if (Body.Descricao != string.Empty)
                Servico.Descricao = Body.Descricao;
            else
                Servico.Descricao = Servico.Descricao;

            if (Body.Custo < 0)
                Servico.Custo = Servico.Custo;
            else
                Servico.Custo = Body.Custo;

            await dbContext.SaveChangesAsync();
        }
        public async Task DeletarServico(Servico Servico)
        {
            dbContext.Servicos.Remove(Servico);
            await dbContext.SaveChangesAsync();
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