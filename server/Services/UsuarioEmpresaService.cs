using Microsoft.EntityFrameworkCore;
using server.Db;
using server.Interfaces;
using server.Models;

namespace server.Services
{
    public class UsuariosEmpresasService(AppDbContext dbContext) : IUsuariosEmpresasService
    {
        private readonly AppDbContext dbContext = dbContext;
        public async Task<List<UsuariosEmpresas>> ObterRelacionamentoPorIdDeUsuario(int idUsuario)
        {
            List<UsuariosEmpresas> ue;

            ue = await dbContext.UsuariosEmpresas.Where(er => er.UsuarioId == idUsuario).ToListAsync();

            return ue;
        }

        public async Task<List<UsuariosEmpresas>> ObterRelacionamentoPorIdDeEmpresa(int idEmpresa)
        {
            List<UsuariosEmpresas> UsuariosEmpresass;

            UsuariosEmpresass = await dbContext.UsuariosEmpresas.Where(er => er.EmpresaId == idEmpresa).ToListAsync();

            return UsuariosEmpresass;
        }

        public async Task<UsuariosEmpresas> ObterRelacionamentoPorId(int idEmpresa, int idUsuario)
        {
            UsuariosEmpresas UsuariosEmpresas;

            UsuariosEmpresas = await dbContext.UsuariosEmpresas.Where(er => er.UsuarioId == idUsuario && er.EmpresaId == idEmpresa).FirstAsync();

            return UsuariosEmpresas;
        }
        public async Task<List<UsuariosEmpresas>> ObterTodosRelacionamentos()
        {
            return await dbContext.UsuariosEmpresas.ToListAsync();
        }
    }
}