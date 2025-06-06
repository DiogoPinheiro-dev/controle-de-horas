using Microsoft.EntityFrameworkCore;
using server.Db;
using server.Models;
using server.Interfaces;

namespace server.Services
{
    public class ApontamentoService(AppDbContext dbContext) : IApontamentoService
    {
        private readonly AppDbContext dbContext = dbContext;

        public async Task<Apontamento> CriarApontamento(Apontamento Apontamento)
        {
            dbContext.Apontamentos.Add(Apontamento);
            await dbContext.SaveChangesAsync();
            return Apontamento;
        }
        public async Task<Apontamento> AtualizarApontamento(Apontamento Apontamento, Apontamento Body)
        {
            if (Body.Descricao != null)
                Apontamento.Descricao = Body.Descricao;
            else
                Apontamento.Descricao = Apontamento.Descricao;

            if (Body.RecursoId > 0)
                Apontamento.RecursoId = Body.RecursoId;
            else
                Apontamento.RecursoId = Apontamento.RecursoId;

            if (Body.HorasFinalizadas > 0)
                Apontamento.HorasFinalizadas = Body.HorasFinalizadas;
            else
                Apontamento.HorasFinalizadas = Apontamento.HorasFinalizadas;

            if (Body.DataFim > 0)
                Apontamento.DataFim = Body.DataFim;
            else
                Apontamento.DataFim = Apontamento.DataFim;

            if (Body.ApontamentoId > 0)
                Apontamento.ApontamentoId = Body.ApontamentoId;
            else
                Apontamento.ApontamentoId = Apontamento.ApontamentoId;

            await dbContext.SaveChangesAsync();
            return Apontamento;
        }
        public async Task<Apontamento> DeletarApontamento(Apontamento Apontamento)
        {
            dbContext.Apontamentos.Remove(Apontamento);
            await dbContext.SaveChangesAsync();
            return Apontamento;
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