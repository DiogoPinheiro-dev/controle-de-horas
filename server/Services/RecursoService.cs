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

        public async Task AtualizarRecurso(Recurso Recurso, Recurso Body)
        {
            if (Body.Nome != null)
                Recurso.Nome = Body.Nome;
            else
                Recurso.Nome = Recurso.Nome;

            if (Body.Nome != null)
                Recurso.Email = Body.Email;
            else
                Recurso.Email = Recurso.Email;

            if (Body.Nome != null)
                Recurso.Telefone = Body.Telefone;
            else
                Recurso.Telefone = Recurso.Telefone;

            if (Body.Nome != null)
                Recurso.Tipo = Body.Tipo;
            else
                Recurso.Tipo = Recurso.Tipo;
                
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