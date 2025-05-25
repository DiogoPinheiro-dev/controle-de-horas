using Microsoft.EntityFrameworkCore;
using server.Db;
using server.Models;
using server.Interfaces;

namespace server.Services
{
    public class TarefaService : ITarefaService
    {
        private readonly AppDbContext dbContext;

        public TarefaService(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task CriarTarefa(Tarefa Tarefa)
        {
            dbContext.Tarefas.Add(Tarefa);
            await dbContext.SaveChangesAsync();
        }
        public async Task AtualizarTarefa(Tarefa Tarefa, Tarefa Body)
        {
            if (Body.Descricao != null)
                Tarefa.Descricao = Body.Descricao;
            else
                Tarefa.Descricao = Tarefa.Descricao;

            if (Body.DataInicio > 0)
                Tarefa.DataInicio = Body.DataInicio;
            else
                Tarefa.DataInicio = Tarefa.DataInicio;

            if (Body.DataFim > 0)
                Tarefa.DataFim = Body.DataFim;
            else
                Tarefa.DataFim = Tarefa.DataFim;

            await dbContext.SaveChangesAsync();
        }
        public async Task DeletarTarefa(Tarefa Tarefa)
        {
            dbContext.Tarefas.Remove(Tarefa);
            await dbContext.SaveChangesAsync();
        }

        public async Task<List<Tarefa>> ObterTodasTarefas()
        {
            return await dbContext.Tarefas.ToListAsync();

        }

        public async Task<Tarefa> ObterTarefaPorId(int id)
        {
            return await dbContext.Tarefas.FindAsync(id);
        }


        public async Task<List<Tarefa>> ObterTarefaPorDescricao(string Descricao)
        {
            List<Tarefa> Tarefa;

            Tarefa = await dbContext
                .Tarefas
                .Where(r => r.Descricao.Contains(Descricao)).ToListAsync();

            return Tarefa;
        }

        public async Task<List<Tarefa>> ObterTarefasPorData(int dataIni, int dataFim)
        {
            List<Tarefa> Tarefa;

            Tarefa = await (
                dbContext
                    .Tarefas
                        .Where(a => a.DataInicio >= dataIni && a.DataFim <= dataFim)
                        .ToListAsync()
            );

            return Tarefa;
        }
    }
}