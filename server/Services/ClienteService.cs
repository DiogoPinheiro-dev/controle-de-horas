using Microsoft.EntityFrameworkCore;
using server.Db;
using server.Models;
using server.Interfaces;

namespace server.Services
{
    public class ClienteService : IClienteService
    {
        private readonly AppDbContext dbContext;

        public ClienteService(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task CriarCliente(Cliente Cliente)
        {
            dbContext.Clientes.Add(Cliente);
            await dbContext.SaveChangesAsync();
        }
        public async Task AtualizarCliente(Cliente Cliente, Cliente Body)
        {
            if (Body.Nome != string.Empty)
                Cliente.Nome = Body.Nome;
            else
                Cliente.Nome = Cliente.Nome;

            if (Body.Telefone != string.Empty)
                Cliente.Telefone = Body.Telefone;
            else
                Cliente.Telefone = Cliente.Telefone;

            if (Body.Email != string.Empty)
                Cliente.Email = Body.Email;
            else
                Cliente.Email = Cliente.Email;

            await dbContext.SaveChangesAsync();
        }
        public async Task DeletarCliente(Cliente Cliente)
        {
            dbContext.Clientes.Remove(Cliente);
            await dbContext.SaveChangesAsync();
        }

        public async Task<List<Cliente>> ObterTodosClientes()
        {
            return await dbContext.Clientes.ToListAsync();

        }

        public async Task<Cliente> ObterClientePorId(int id)
        {
            return await dbContext.Clientes.FindAsync(id);
        }

        public async Task<List<Cliente>> ObterClientePorEmail(string email)
        {
            List<Cliente> Cliente;

            Cliente = await dbContext
                .Clientes
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
                .Where(
                    r => r
                        .Nome
                        .Contains(nome)
                ).ToListAsync();

            return Cliente;
        }
    }
}