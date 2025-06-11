using Microsoft.EntityFrameworkCore;
using server.Db;
using server.Interfaces;
using server.Models;

namespace server.Services
{
    public class UsuariosRecursosService(AppDbContext dbContext) : IUsuariosRecursosService
    {
        private readonly AppDbContext dbContext = dbContext;

        public async Task<List<UsuariosRecursos>> ObterRelacionamentoPorIdDeUsuario(int idUsuario)
        {
            return await dbContext
                .UsuariosRecursos
                .Select(ur => ur)
                .Where(ur => ur.UsuarioId == idUsuario)
                .ToListAsync();
        }

        public async Task<List<UsuariosRecursos>> ObterRelacionamentoPorIdDeRecurso(int idRecurso)
        {
            return await dbContext
                .UsuariosRecursos
                .Select(ur => ur)
                .Where(ur => ur.RecursoId == idRecurso)
                .ToListAsync();
        }

        public async Task<UsuariosRecursos> ObterRelacionamentoPorId(int idRecurso, int idUsuario)
        {
            return await dbContext
                .UsuariosRecursos
                .Select(ur => ur)
                .Where(ur => ur.UsuarioId == idUsuario && ur.RecursoId == idRecurso)
                .FirstAsync();
        }
        public async Task<List<UsuariosRecursos>> ObterTodosRelacionamentos()
        {
            return await dbContext
                .UsuariosRecursos
                .Select(ur => ur)
                .ToListAsync();
        }
    }
}