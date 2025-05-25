using Microsoft.EntityFrameworkCore;
using server.Db;
using server.Models;
using server.Interfaces;

namespace server.Services
{
    public class SubTarefaService : ISubTarefaService
    {
        private readonly AppDbContext dbContext;

        public SubTarefaService(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task CriarSubTarefa(SubTarefa SubTarefa)
        {
            dbContext.SubTarefas.Add(SubTarefa);
            await dbContext.SaveChangesAsync();
        }
        public async Task AtualizarSubTarefa(SubTarefa SubTarefa, SubTarefa Body)
        {
            if (Body.Descricao != null)
                SubTarefa.Descricao = Body.Descricao;
            else
                SubTarefa.Descricao = SubTarefa.Descricao;
                
            if (Body.IdAnalista > 0)
                SubTarefa.IdAnalista = Body.IdAnalista;
            else
                SubTarefa.IdAnalista = SubTarefa.IdAnalista;

            if (Body.DataInicio > 0)
                SubTarefa.DataInicio = Body.DataInicio;
            else
                SubTarefa.DataInicio = SubTarefa.DataInicio;

            if (Body.DataFim > 0)
                SubTarefa.DataFim = Body.DataFim;
            else
                SubTarefa.DataFim = SubTarefa.DataFim;

            await dbContext.SaveChangesAsync();
        }
        public async Task DeletarSubTarefa(SubTarefa SubTarefa)
        {
            dbContext.SubTarefas.Remove(SubTarefa);
            await dbContext.SaveChangesAsync();
        }

        public async Task<List<SubTarefa>> ObterTodasSubTarefas()
        {
            return await dbContext.SubTarefas.ToListAsync();

        }

        public async Task<SubTarefa> ObterSubTarefaPorId(int id)
        {
            return await dbContext.SubTarefas.FindAsync(id);
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