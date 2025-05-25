using Microsoft.EntityFrameworkCore;
using server.Db;
using server.Models;
using server.Interfaces;

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

        public async Task AtualizarRecurso(Recurso recurso, Recurso body)
        {
            if (body.Nome != string.Empty)
                recurso.Nome = body.Nome;
            else
                recurso.Nome = recurso.Nome;

            if (body.Email != string.Empty)
                recurso.Email = body.Email;
            else
                recurso.Email = recurso.Email;

            if (body.Telefone != string.Empty)
                recurso.Telefone = body.Telefone;
            else
                recurso.Telefone = recurso.Telefone;

            if (body.Tipo != string.Empty)
                recurso.Tipo = body.Tipo;
            else
                recurso.Tipo = recurso.Tipo;

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

        public async Task<Recurso> ObterRecursoPorId(int Id)
        {
            return await dbContext.Recursos.FindAsync(Id);
        }
        public async Task<List<Recurso>> ObterRecursoPorEmail(string Email)
        {
            List<Recurso> recursos;

            recursos = await dbContext
                .Recursos
                .Where(r => r.Email.Contains(Email)).ToListAsync();

            return recursos;
        }


        public async Task<List<Recurso>> ObterRecursoPorNome(string Nome)
        {
            List<Recurso> recursos;

            recursos = await dbContext
                .Recursos
                .Where(r => r.Nome.Contains(Nome)).ToListAsync();

            return recursos;
        }

        public async Task<List<Recurso>> ObterRecursoPorTelefone(string Telefone)
        {
            List<Recurso> recursos;


            recursos = await dbContext
                .Recursos
                .Where(r => r.Telefone.Contains(Telefone)).ToListAsync();


            return recursos;
        }

        public async Task<List<Recurso>> ObterRecursoPorTipo(string Tipo)
        {
            List<Recurso> recursos;

            recursos = await dbContext
                    .Recursos
                    .Where(r => r.Tipo.Contains(Tipo)).ToListAsync();

            return recursos;
        }
    }
}