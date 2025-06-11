using server.Models;
using server.Db;
using server.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace server.Services
{
    public class UsuarioService(AppDbContext dbContext) : IUsuarioService
    {
        private readonly AppDbContext dbContext = dbContext;

        public async Task<Usuario> CriarUsuario(Usuario usuario)
        {
            await dbContext.Database.BeginTransactionAsync();

            var usuarioExistentes = await dbContext
                .Usuarios
                .Select(u => u)
                .Where(u => u.Email == usuario.Email)
                .FirstOrDefaultAsync();

            if (usuarioExistentes != null)
            {
                throw new ArgumentException("Esse email já está sendo utilizado!");
            }

            var recurso = await dbContext
                .Recursos
                .Select(r => r)
                .Where(r => r.Email == usuario.Email)
                .FirstOrDefaultAsync();

            var cliente = await dbContext
                .Clientes
                .Select(c => c)
                .Where(c => c.Email == usuario.Email)
                .FirstOrDefaultAsync();

            var empresa = await dbContext
                .Empresas
                .Select(e => e)
                .Where(e => e.Email == usuario.Email)
                .FirstOrDefaultAsync();

            if (recurso != null)
            {
                await dbContext.Usuarios.AddAsync(usuario);
                await dbContext.SaveChangesAsync();

                var ur = await dbContext
                    .UsuariosRecursos
                    .Select(ur => ur)
                    .Where(ur => ur.RecursoId == recurso.RecursoId && ur.UsuarioId == usuario.UsuarioId)
                    .FirstOrDefaultAsync();

                if (ur != null)
                {
                    throw new ArgumentException("Esse usuário já está vinculado a esse recurso!");
                }

                await dbContext.UsuariosRecursos.AddAsync(new UsuariosRecursos
                {
                    UsuarioId = usuario.UsuarioId,
                    UsuarioEmail = usuario.Email,
                    RecursoId = recurso.RecursoId,
                    RecursoEmail = recurso.Email
                });

                await dbContext.SaveChangesAsync();

                recurso.IdUsuario = usuario.UsuarioId;
                await dbContext.SaveChangesAsync();
            }

            if (cliente != null)
            {
                await dbContext.Usuarios.AddAsync(usuario);
                await dbContext.SaveChangesAsync();

                var uc = await dbContext
                    .UsuariosClientes
                    .Select(uc => uc)
                    .Where(uc => uc.ClienteId == cliente.ClienteId && uc.UsuarioId == usuario.UsuarioId)
                    .FirstOrDefaultAsync();

                if (uc != null)
                {
                    throw new ArgumentException("Esse usuário já está vinculado a esse cliente!");
                }

                await dbContext.UsuariosClientes.AddAsync(new UsuariosClientes
                {
                    UsuarioId = usuario.UsuarioId,
                    UsuarioEmail = usuario.Email,
                    ClienteId = cliente.ClienteId,
                    ClienteEmail = cliente.Email
                });

                await dbContext.SaveChangesAsync();

                cliente.IdUsuario = usuario.UsuarioId;
                await dbContext.SaveChangesAsync();
            }

            if (empresa != null)
            {
                await dbContext.Usuarios.AddAsync(usuario);
                await dbContext.SaveChangesAsync();

                var ue = await dbContext
                    .UsuariosEmpresas
                    .Select(ue => ue)
                    .Where(ue => ue.EmpresaId == empresa.EmpresaId && ue.UsuarioId == usuario.UsuarioId)
                    .FirstOrDefaultAsync();

                if (ue != null)
                {
                    throw new ArgumentException("Esse usuário já está vinculado a essa empresa!");
                }

                await dbContext.UsuariosEmpresas.AddAsync(new UsuariosEmpresas
                {
                    UsuarioId = usuario.UsuarioId,
                    UsuarioEmail = usuario.Email,
                    EmpresaId = empresa.EmpresaId,
                    EmpresaEmail = empresa.Email
                });

                await dbContext.SaveChangesAsync();

                empresa.IdUsuario = usuario.UsuarioId;
                await dbContext.SaveChangesAsync();
            }

            if (recurso == null && cliente == null && empresa == null)
            {
                throw new ArgumentException("Usuário não vinculado a nenhum recurso, cliente ou empresa.");
            }

            await dbContext.Database.CommitTransactionAsync();
            return usuario;
        }

        public async Task<Usuario> AlterarUsuario(Usuario usuario, Usuario Body)
        {
            await dbContext.Database.BeginTransactionAsync();

            if (Body.Senha != null)
                usuario.Senha = Body.Senha;

            if (Body.NivelDeUsuario > 0)
                usuario.NivelDeUsuario = Body.NivelDeUsuario;

            await dbContext.SaveChangesAsync();
            await dbContext.Database.CommitTransactionAsync();
            return usuario;
        }

        public async Task<Usuario> DeletarUsuario(Usuario usuario)
        {
            await dbContext.Database.BeginTransactionAsync();

            var ur = await dbContext
                .UsuariosRecursos
                .Select(r => r)
                .Where(r => r.UsuarioId == usuario.UsuarioId)
                .FirstOrDefaultAsync();

            if (ur != null)
            {
                var recurso = await dbContext
                .Recursos
                .Select(r => r)
                .Where(r => r.IdUsuario == ur.UsuarioId)
                .FirstOrDefaultAsync();

                if (recurso != null)
                {
                    recurso.IdUsuario = 0;
                    await dbContext.SaveChangesAsync();
                }

                dbContext.UsuariosRecursos.Remove(ur);
                await dbContext.SaveChangesAsync();
            }

            var uc = await dbContext
                .UsuariosClientes
                .Select(c => c)
                .Where(c => c.UsuarioId == usuario.UsuarioId)
                .FirstOrDefaultAsync();

            if (uc != null)
            {
                var cliente = await dbContext
                    .Clientes
                    .Select(c => c)
                    .Where(c => c.IdUsuario == uc.UsuarioId)
                    .FirstOrDefaultAsync();

                if (cliente != null)
                {
                    cliente.IdUsuario = 0;
                    await dbContext.SaveChangesAsync();
                }

                dbContext.UsuariosClientes.Remove(uc);
                await dbContext.SaveChangesAsync();
            }

            var ue = await dbContext
                .UsuariosEmpresas
                .Select(e => e)
                .Where(e => e.UsuarioId == usuario.UsuarioId)
                .FirstOrDefaultAsync();

            if (ue != null)
            {
                var empresa = await dbContext
                    .Empresas
                    .Select(e => e)
                    .Where(e => e.IdUsuario == ue.UsuarioId)
                    .FirstOrDefaultAsync();

                if (empresa != null)
                {
                    empresa.IdUsuario = 0;
                    await dbContext.SaveChangesAsync();
                }

                dbContext.UsuariosEmpresas.Remove(ue);
                await dbContext.SaveChangesAsync();
            }

            dbContext.Usuarios.Remove(usuario);
            await dbContext.SaveChangesAsync();

            await dbContext.Database.CommitTransactionAsync();
            return usuario;
        }

        public async Task<List<Usuario>> ObterTodosOsUsuarios()
        {
            return await dbContext.Usuarios.ToListAsync();
        }

        public async Task<Usuario> ObterUsuarioPorEmail(string email)
        {
            return await dbContext
                .Usuarios
                .Select(u => u)
                .Where(u => u.Email == email)
                .FirstOrDefaultAsync() ?? throw new ArgumentException("Usuário não encontrado com este email");
        }

        public async Task<Usuario> ObterUsuarioPorIdDeUsuario(int id)
        {
            return await dbContext
                .Usuarios
                .Select(u => u)
                .Where(u => u.UsuarioId == id)
                .FirstOrDefaultAsync() ?? throw new ArgumentException("Usuário não encontrado com este ID");
        }

        public async Task<List<Usuario>> ObterUsuariosPorNivelDeUsuario(int nivelDeUsuario)
        {
            return await dbContext
                .Usuarios
                .Select(u => u)
                .Where(u => u.NivelDeUsuario == nivelDeUsuario)
                .ToListAsync();
        }
    }
}