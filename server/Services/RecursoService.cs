using Microsoft.EntityFrameworkCore;
using server.Db;
using server.Models;

namespace server.Services
{
    public class RecursoService : IRecursoService
    {
        private readonly AppDbContext dbContext;

        public RecursoService(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task CriarRecurso(Recurso recurso)
        {
            dbContext.Recursos.Add(recurso);
            await dbContext.SaveChangesAsync();
        }

        public async Task AtualizarRecurso(Recurso recurso, Recurso modeloDeRecurso)
        {
            if (modeloDeRecurso.Nome != null)
                recurso.Nome = modeloDeRecurso.Nome;
            else
                recurso.Nome = recurso.Nome;

            if (modeloDeRecurso.Email != null)
                recurso.Email = modeloDeRecurso.Email;
            else
                recurso.Email = recurso.Email;

            if (modeloDeRecurso.Telefone != null)
                recurso.Telefone = modeloDeRecurso.Telefone;
            else
                recurso.Telefone = recurso.Telefone;

            if (modeloDeRecurso.Tipo != null)
                recurso.Tipo = modeloDeRecurso.Tipo;
            else
                recurso.Tipo = recurso.Tipo;

            if (modeloDeRecurso.Tarefas != null)
                recurso.Tarefas = modeloDeRecurso.Tarefas;
            else
                recurso.Tarefas = recurso.Tarefas;

            if (modeloDeRecurso.SubTarefas != null)
                recurso.SubTarefas = modeloDeRecurso.SubTarefas;
            else
                recurso.SubTarefas = recurso.SubTarefas;

            if (modeloDeRecurso.Apontamentos != null)
                recurso.Apontamentos = modeloDeRecurso.Apontamentos;
            else
                recurso.Apontamentos = recurso.Apontamentos;

            await dbContext.SaveChangesAsync();
        }

        public async Task DeletarRecurso(Recurso recurso)
        {
            dbContext.Recursos.Remove(recurso);
            await dbContext.SaveChangesAsync();
        }

        public async Task<List<Recurso>> ObterTodosRecursos()
        {
            return await dbContext.Recursos.ToListAsync();
        }

        public async Task<Recurso> ObterRecursoPorId(Guid Id)
        {
            return await dbContext.Recursos.FindAsync(Id);
        }

        public async Task<List<Recurso>> ObterRecursoPorEmail(string Email)
        {
            List<Recurso> recursos;

            if (!string.IsNullOrWhiteSpace(Email))
            {
                recursos = await dbContext
                    .Recursos
                    .Where(
                        r => r
                            .Email
                            .Contains(Email)
                    ).ToListAsync();
            }
            else
            {
                recursos = await ObterTodosRecursos();
            }

            return recursos;
        }


        public async Task<List<Recurso>> ObterRecursoPorNome(string Nome)
        {
            List<Recurso> recursos;

            if (!string.IsNullOrWhiteSpace(Nome))
            {
                recursos = await dbContext
                    .Recursos
                    .Where(
                        r => r
                            .Nome
                            .Contains(Nome)
                    ).ToListAsync();
            }
            else
            {
                recursos = await ObterTodosRecursos();
            }

            return recursos;
        }

        public async Task<List<Recurso>> ObterRecursoPorTelefone(string Telefone)
        {
            List<Recurso> recursos;

            if (!string.IsNullOrWhiteSpace(Telefone))
            {
                recursos = await dbContext
                    .Recursos
                    .Where(
                        r => r
                            .Telefone
                            .Contains(Telefone)
                    ).ToListAsync();
            }
            else
            {
                recursos = await ObterTodosRecursos();
            }

            return recursos;
        }

        public async Task<List<Recurso>> ObterRecursoPorTipo(string Tipo)
        {
            List<Recurso> recursos;

            if (!string.IsNullOrWhiteSpace(Tipo))
            {
                recursos = await dbContext
                    .Recursos
                    .Where(
                        r => r
                            .Tipo
                            .Contains(Tipo)
                    ).ToListAsync();
            }
            else
            {
                recursos = await ObterTodosRecursos();
            }

            return recursos;
        }
    }
}