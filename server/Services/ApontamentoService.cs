using Microsoft.EntityFrameworkCore;
using server.Db;
using server.Models;
using server.Interfaces;

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
        public async Task AtualizarApontamento(Apontamento Apontamento, Apontamento Body)
        {
            if (Body.Descricao != null)
                Apontamento.Descricao = Body.Descricao;
            else
                Apontamento.Descricao = Apontamento.Descricao;

            if (Body.HorasApontadas > 0)
                Apontamento.HorasApontadas = Body.HorasApontadas;
            else
                Apontamento.HorasApontadas = Apontamento.HorasApontadas;

            if (Body.HorasFinalizadas > 0)
                Apontamento.HorasFinalizadas = Body.HorasFinalizadas;
            else
                Apontamento.HorasFinalizadas = Apontamento.HorasFinalizadas;

            if (Body.DataInicio != null)
                Apontamento.DataInicio = Body.DataInicio;
            else
                Apontamento.DataInicio = Apontamento.DataInicio;

            if (Body.DataFim != null)
                Apontamento.DataFim = Body.DataFim;
            else
                Apontamento.DataFim = Apontamento.DataFim;

            await dbContext.SaveChangesAsync();
        }
        public async Task DeletarApontamento(Apontamento Apontamento)
        {
            dbContext.Apontamentos.Remove(Apontamento);
            await dbContext.SaveChangesAsync();
        }

        public async Task<List<Apontamento>> ObterTodosApontamentos()
        {
            return await dbContext.Apontamentos.ToListAsync();

        }

        public async Task<List<Apontamento>> ObterApontamentoPorOS(string OS)
        {
            List<Apontamento> apontamento;

            apontamento = await dbContext
                .Apontamentos
                .Where(
                    r => r
                        .OS
                        .Contains(OS)
                ).ToListAsync();

            return apontamento;
        }

        public async Task<List<Apontamento>> ObterApontamentosPorData(int dataIni, int dataFim)
        {
            List<Apontamento> apontamentos;

            apontamentos = await (
                dbContext
                    .Apontamentos
                        .Where(a => a.DataInicio >= dataIni && a.DataFim <= dataFim)
                        .ToListAsync()
            );

            return apontamentos;
        }

        public async Task<Apontamento> ObterApontamentoPorId(int id)
        {
            return await dbContext.Apontamentos.FindAsync(id);
        }
    }

}