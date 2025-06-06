using server.Models;
using server.Db;
using server.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace server.Services
{
    public class UsuarioService(AppDbContext servicos) : IUsuarioService
    {
        private readonly AppDbContext servicos = servicos;

        public async Task<Usuario> CriarUsuario(Usuario usuario)
        {
            await servicos.Database.BeginTransactionAsync();

            var usuarioExistentes = await servicos.Usuarios.FindAsync(usuario.Email);

            if (usuarioExistentes != null)
            {
                throw new ArgumentException("Usuário já existe com este email");
            }

            await servicos.Usuarios.AddAsync(usuario);
            await servicos.SaveChangesAsync();

            Empresa empresa;
            Cliente cliente;
            Recurso recurso;

            if (usuario.ClienteId > 0)
            {
                cliente = await servicos.Clientes.FindAsync(usuario.ClienteId) ?? throw new ArgumentException("Cliente não encontrado");

                cliente.UsuarioId = usuario.UsuarioId;

                if (cliente == null)
                {
                    await servicos.Database.RollbackTransactionAsync();
                }

                await servicos.SaveChangesAsync();
            }

            if (usuario.EmpresaId > 0)
            {
                empresa = await servicos.Empresas.FindAsync(usuario.EmpresaId) ?? throw new ArgumentException("Empresa não encontrada");

                empresa.UsuarioId = usuario.UsuarioId;

                if (empresa == null)
                {
                    await servicos.Database.RollbackTransactionAsync();
                }

                await servicos.SaveChangesAsync();
            }

            if (usuario.RecursoId > 0)
            {
                recurso = await servicos.Recursos.FindAsync(usuario.RecursoId) ?? throw new ArgumentException("Recurso não encontrado");

                recurso.UsuarioId = usuario.UsuarioId;

                if (recurso == null)
                {
                    await servicos.Database.RollbackTransactionAsync();
                }

                await servicos.SaveChangesAsync();
            }

            await servicos.Database.CommitTransactionAsync();
            return usuario;
        }

        public async Task<Usuario> AlterarUsuario(Usuario usuario, Usuario Body)
        {
            await servicos.Database.BeginTransactionAsync();

            if (Body.Senha != null)
                usuario.Senha = Body.Senha;

            if (Body.Email != null)
                usuario.Email = Body.Email;

            if (Body.NivelDeUsuario > 0)
                usuario.NivelDeUsuario = Body.NivelDeUsuario;

            if (Body.ClienteId > 0)
                usuario.ClienteId = Body.ClienteId;

            if (Body.EmpresaId > 0)
                usuario.EmpresaId = Body.EmpresaId;

            if (Body.RecursoId > 0)
                usuario.RecursoId = Body.RecursoId;

            await servicos.SaveChangesAsync();
            await servicos.Database.CommitTransactionAsync();
            return usuario;
        }

        public async Task<Usuario> DeletarUsuario(Usuario usuario)
        {
            await servicos.Database.BeginTransactionAsync();

            if (usuario.ClienteId > 0)
            {
                var cliente = await servicos.Clientes.FindAsync(usuario.ClienteId);

                if (cliente == null)
                    throw new ArgumentException("Cliente não encontrado");

                else
                {
                    cliente.UsuarioId = 0;
                    await servicos.SaveChangesAsync();
                }
            }

            if (usuario.EmpresaId > 0)
            {
                var empresa = await servicos.Empresas.FindAsync(usuario.EmpresaId);

                if (empresa == null)
                    throw new ArgumentException("Empresa não encontrada");

                else
                {
                    empresa.UsuarioId = 0;
                    await servicos.SaveChangesAsync();
                }
            }

            if (usuario.RecursoId > 0)
            {
                var recurso = await servicos.Recursos.FindAsync(usuario.RecursoId);

                if (recurso == null)
                    throw new ArgumentException("Recurso não encontrado");

                else
                {
                    recurso.UsuarioId = 0;
                    await servicos.SaveChangesAsync();
                }
            }

            servicos.Usuarios.Remove(usuario);
            await servicos.SaveChangesAsync();
            
            await servicos.Database.CommitTransactionAsync();
            return usuario;
        }

        public async Task<List<Usuario>> ObterTodosOsUsuarios()
        {
            return await servicos.Usuarios.ToListAsync();
        }

        public async Task<Usuario> ObterUsuarioPorEmail(string email)
        {
            Usuario usuarios = await servicos.Usuarios.FirstOrDefaultAsync(u => u.Email == email) ?? throw new ArgumentException("Usuário não encontrado com este email");

            return usuarios;
        }

        public async Task<Usuario> ObterUsuarioPorIdDeUsuario(int id)
        {
            Usuario usuarios = await servicos.Usuarios.FindAsync(id) ?? throw new ArgumentException("Usuário não encontrado com este ID");

            return usuarios;
        }

        public async Task<List<Usuario>> ObterUsuariosPorClienteId(int clienteId)
        {
            return await servicos.Usuarios.Where(u => u.ClienteId == clienteId).ToListAsync();
        }

        public async Task<List<Usuario>> ObterUsuariosPorEmpresaId(int empresaId)
        {
            return await servicos.Usuarios.Where(u => u.EmpresaId == empresaId).ToListAsync();
        }

        public async Task<List<Usuario>> ObterUsuariosPorNivelDeUsuario(int nivelDeUsuario)
        {
            return await servicos.Usuarios.Where(u => u.NivelDeUsuario == nivelDeUsuario).ToListAsync();
        }

        public async Task<List<Usuario>> ObterUsuariosPorRecursoId(int recursoId)
        {
            return await servicos.Usuarios.Where(u => u.RecursoId == recursoId).ToListAsync();
        }
    }
}