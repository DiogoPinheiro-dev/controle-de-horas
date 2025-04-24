using Microsoft.EntityFrameworkCore;
using server.Db;
using server.Models;

namespace server.Services
{
    public class ApontamentoService : IApontamentoService
    {
        private readonly AppDbContext dbContext;

        public ApontamentoService(AppDbContext dbContext)
        {
            this.dbContext = dbContext;

        }

        public async Task CriarApontamento(Apontamento Apontamento)
        {
            dbContext.Apontamentos.Add(Apontamento);
            await dbContext.SaveChangesAsync();
        }
        public async Task AtualizarApontamento(Apontamento Apontamento)
        {
            dbContext.Entry(Apontamento).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
        }
        public async Task DeletarApontamento(Apontamento Apontamento)
        {
            dbContext.Apontamentos.Remove(Apontamento);
            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Apontamento>> ObterTodosApontamentos()
        {
            return await dbContext.Apontamentos.ToListAsync();

        }

        public async Task<IEnumerable<Apontamento>> ObterApontamentoPorNome(string nome)
        {
            IEnumerable<Apontamento> apontamento;

            if (!string.IsNullOrWhiteSpace(nome))
            {
                apontamento = await dbContext
                    .Apontamentos
                    .Where(
                        r => r
                            .Descricao
                            .Contains(nome)
                    ).ToListAsync();

            }
            else
            {
                apontamento = await ObterTodosApontamentos();
            }

            return apontamento;
        }

        public async Task<IEnumerable<Apontamento>> ObterApontamentoPorOS(string OS)
        {
            IEnumerable<Apontamento> apontamento;

            if (!string.IsNullOrWhiteSpace(OS))
            {
                apontamento = await dbContext
                    .Apontamentos
                    .Where(
                        r => r
                            .OS
                            .Contains(OS)
                    ).ToListAsync();

            }
            else
            {
                apontamento = await ObterTodosApontamentos();
            }

            return apontamento;
        }

        public async Task<IEnumerable<Apontamento>> ObterApontamentosPorDataInicio(DateTime dataIni, DateTime dataFim)
        {
            IEnumerable<Apontamento> apontamento;

            apontamento = await dbContext
                .Apontamentos
                .Where(
                    a => a
                        .DataInicio == dataIni && a.DataFim == dataFim
                ).ToListAsync();

            return apontamento;
        }
    }

}