using Microsoft.EntityFrameworkCore;
using server.Db;
using server.Models;
using server.Interfaces;

namespace server.Services
{
    public class SubTarefaService(AppDbContext dbContext) : ISubTarefaService
    {
        private readonly AppDbContext dbContext = dbContext;

        public async Task<SubTarefa> CriarSubTarefa(SubTarefa SubTarefa)
        {
            dbContext.SubTarefas.Add(SubTarefa);
            await dbContext.SaveChangesAsync();
            return SubTarefa;
        }
        public async Task<SubTarefa> AtualizarSubTarefa(SubTarefa SubTarefa, SubTarefa Body)
        {
            if (Body.Descricao != null)
                SubTarefa.Descricao = Body.Descricao;
            else
                SubTarefa.Descricao = SubTarefa.Descricao;

            if (Body.DataFim > 0)
                SubTarefa.DataFim = Body.DataFim;
            else
                SubTarefa.DataFim = SubTarefa.DataFim;

            await dbContext.SaveChangesAsync();
            return SubTarefa;
        }
        public async Task<SubTarefa> DeletarSubTarefa(SubTarefa SubTarefa)
        {
            dbContext.SubTarefas.Remove(SubTarefa);
            await dbContext.SaveChangesAsync();
            return SubTarefa;
        }

        public async Task<List<SubTarefa>> ObterTodasSubTarefas()
        {
            return await dbContext.SubTarefas.ToListAsync();

        }

        public async Task<SubTarefa> ObterSubTarefaPorId(int id)
        {
            return await dbContext.SubTarefas.FindAsync(id);
        }

        public async Task<List<SubTarefa>> ObterProjetosPorIdDeAnalista(int idAnalista)
        {
            List<SubTarefa> SubTarefas;

            SubTarefas = await dbContext
                .SubTarefas
                .Select(p => p)
                .Where(p => p.RecursoId == idAnalista)
                .ToListAsync() ?? throw new Exception("Esse Analista nao tem SubTarefas.");

            return SubTarefas;
        }


        public async Task<List<SubTarefa>> ObterSubTarefaPorDescricao(string Descricao)
        {
            List<SubTarefa> SubTarefa;

            SubTarefa = await dbContext
                .SubTarefas
                .Where(r => r.Descricao.Contains(Descricao)).ToListAsync();

            return SubTarefa;
        }

        public async Task<List<SubTarefa>> ObterSubTarefasPorData(int dataIni, int dataFim)
        {
            List<SubTarefa> SubTarefa;

            SubTarefa = await (
                dbContext
                    .SubTarefas
                        .Where(a => a.DataInicio >= dataIni && a.DataFim <= dataFim)
                        .ToListAsync()
            );

            return SubTarefa;
        }
    }
}