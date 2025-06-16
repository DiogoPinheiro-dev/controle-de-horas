using Microsoft.EntityFrameworkCore;
using server.Db;
using server.Models;
using server.Interfaces;

namespace server.Services
{
    public class ClienteService(AppDbContext dbContext) : IClienteService
    {
        private readonly AppDbContext dbContext = dbContext;

        public async Task<Cliente> CriarCliente(Cliente Cliente)
        {
            await dbContext.Database.BeginTransactionAsync();

            Cliente c = await dbContext
                .Clientes
                .Select(c => c)
                .Where(c => c.Email == Cliente.Email)
                .FirstOrDefaultAsync();

            if (c != null)
            {

                await dbContext.Database.RollbackTransactionAsync();
                throw new Exception("Cliente já existe com o mesmo email.");
            }

            Empresa empresa = await dbContext
                .Empresas
                .Select(e => e)
                .Where(e => e.EmpresaId == Cliente.IdEmpresa)
                .FirstOrDefaultAsync();

            if (empresa == null)
            {
                await dbContext.Database.RollbackTransactionAsync();
                throw new Exception("Empresa não encontrada.");
            }

            await dbContext.Clientes.AddAsync(Cliente);
            await dbContext.SaveChangesAsync();

            EmpresaCliente es = new()
            {
                EmpresaId = empresa.EmpresaId,
                EmpresaEmail = empresa.Email,
                ClienteId = Cliente.ClienteId,
                ClienteEmail = Cliente.Email
            };

            await dbContext.EmpresaClientes.AddAsync(es);
            await dbContext.SaveChangesAsync();

            await dbContext.Database.CommitTransactionAsync();

            return Cliente;
        }
        public async Task<Cliente> AtualizarCliente(Cliente Cliente, Cliente Body)
        {
            if (Body.Nome != null)
                Cliente.Nome = Body.Nome;
            else
                Cliente.Nome = Cliente.Nome;

            if (Body.Telefone != null)
                Cliente.Telefone = Body.Telefone;
            else
                Cliente.Telefone = Cliente.Telefone;

             if (Body.IdUsuario > 0)
            {
                var usuario = await dbContext
                    .Usuarios
                    .Select(u => u)
                    .Where(u => u.UsuarioId == Body.IdUsuario)
                    .FirstOrDefaultAsync() ?? throw new Exception("Usuario não encontrado.");

                Cliente.IdUsuario = usuario.UsuarioId;
                await dbContext.SaveChangesAsync();
            }
            else
                Cliente.IdUsuario = Cliente.IdUsuario;

            if (Body.IdEmpresa > 0)
            {
                await dbContext.Database.BeginTransactionAsync();

                var empresaAtu = await dbContext
                    .Empresas
                    .Select(e => e)
                    .Where(e => e.EmpresaId == Cliente.IdEmpresa)
                    .FirstOrDefaultAsync() ?? throw new Exception("Empresa nao encontrada.");

                var empresaNova = await dbContext
                    .Empresas
                    .Select(e => e)
                    .Where(e => e.EmpresaId == Body.IdEmpresa)
                    .FirstOrDefaultAsync() ?? throw new Exception("Empresa nao encontrada.");

                var ecAtu = await dbContext
                    .EmpresaClientes
                    .Select(ec => ec)
                    .Where(ec => ec.EmpresaId == empresaAtu.EmpresaId && ec.ClienteId == Cliente.ClienteId)
                    .FirstOrDefaultAsync() ?? throw new Exception("EmpresaCliente não encontrada.");

                dbContext.EmpresaClientes.Remove(ecAtu);
                await dbContext.SaveChangesAsync();

                dbContext.EmpresaClientes.Add(new EmpresaCliente()
                {
                    EmpresaId = Body.IdEmpresa,
                    EmpresaEmail = empresaNova.Email,
                    ClienteId = Cliente.ClienteId,
                    ClienteEmail = Body.Email ?? Cliente.Email
                });
                await dbContext.SaveChangesAsync();

                Cliente.IdEmpresa = Body.IdEmpresa;
                await dbContext.SaveChangesAsync();

                await dbContext.Database.CommitTransactionAsync();
            }

            await dbContext.SaveChangesAsync();
            return Cliente;
        }
        public async Task<Cliente> DeletarCliente(Cliente Cliente)
        {
            EmpresaCliente empresaCliente = await dbContext
                .EmpresaClientes
                .Select(ec => ec)
                .Where(ec => ec.EmpresaId == Cliente.IdEmpresa && ec.ClienteId == Cliente.ClienteId)
                .FirstOrDefaultAsync() ?? throw new Exception("EmpresaCliente não encontrada.");

            dbContext.EmpresaClientes.Remove(empresaCliente);
            await dbContext.SaveChangesAsync();

            dbContext.Clientes.Remove(Cliente);
            await dbContext.SaveChangesAsync();

            return Cliente;
        }

        public async Task<List<Cliente>> ObterTodosClientes()
        {
            return await dbContext.Clientes.Select(c => c).ToListAsync();
        }

        public async Task<Cliente> ObterClientePorId(int id)
        {
            return await dbContext.Clientes
                .Select(c => c)
                .Where(c => c.ClienteId == id)
                .FirstOrDefaultAsync() ?? throw new Exception("Cliente não encontrado.");
        }

        public async Task<List<Cliente>> ObterClientePorEmail(string email)
        {
            List<Cliente> Cliente;

            Cliente = await dbContext
                .Clientes
                .Select(c => c)
                .Where(
                    r => r
                        .Email
                        .Contains(email)
                ).ToListAsync();

            return Cliente;
        }

        public async Task<List<Cliente>> ObterClientePorTelefone(string tel)
        {
            List<Cliente> Cliente;

            Cliente = await dbContext
                .Clientes
                .Select(c => c)
                .Where(
                    r => r
                        .Telefone
                        .Contains(tel)
                ).ToListAsync();

            return Cliente;
        }
        public async Task<List<Cliente>> ObterClientePorNome(string nome)
        {
            List<Cliente> Cliente;

            Cliente = await dbContext
                .Clientes
                .Select(c => c)
                .Where(
                    r => r
                        .Nome
                        .Contains(nome)
                ).ToListAsync();

            return Cliente;
        }
    }
}