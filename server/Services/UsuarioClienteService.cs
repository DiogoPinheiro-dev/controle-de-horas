using Microsoft.EntityFrameworkCore;
using server.Db;
using server.Interfaces;
using server.Models;

namespace server.Services
{
    public class UsuariosClientesService(AppDbContext dbContext) : IUsuariosClientesService
    {
        private readonly AppDbContext dbContext = dbContext;

        public async Task<List<UsuariosClientes>> ObterRelacionamentoPorIdDeUsuario(int idUsuario)
        {
            List<UsuariosClientes> ue;

            ue = await dbContext.UsuariosClientes.Where(er => er.UsuarioId == idUsuario).ToListAsync();

            return ue;
        }

        public async Task<List<UsuariosClientes>> ObterRelacionamentoPorIdDeCliente(int idCliente)
        {
            List<UsuariosClientes> UsuariosClientess;

            UsuariosClientess = await dbContext.UsuariosClientes.Where(er => er.ClienteId == idCliente).ToListAsync();

            return UsuariosClientess;
        }

        public async Task<UsuariosClientes> ObterRelacionamentoPorId(int idCliente, int idUsuario)
        {
            UsuariosClientes UsuariosClientes;

            UsuariosClientes = await dbContext.UsuariosClientes.Where(er => er.UsuarioId == idUsuario && er.ClienteId == idCliente).FirstAsync();

            return UsuariosClientes;
        }
        public async Task<List<UsuariosClientes>> ObterTodosRelacionamentos()
        {
            return await dbContext.UsuariosClientes.ToListAsync();
        }
    }
}