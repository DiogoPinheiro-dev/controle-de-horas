using Microsoft.EntityFrameworkCore;
using server.Db;
using server.Models;
using server.Interfaces;

namespace server.Services
{
    public class ClienteService(AppDbContext dbContext) : IClienteService
    {
        private readonly AppDbContext dbContext = dbContext;

        public async Task CriarCliente(Cliente Cliente)
        {
            await dbContext.Database.BeginTransactionAsync();

            var empresa = await dbContext.Empresas.FindAsync(Cliente.IdEmpresa);

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
                ClienteId = Cliente.ClienteId
            };

            await dbContext.EmpresaClientes.AddAsync(es);
            await dbContext.SaveChangesAsync();

            await dbContext.Database.CommitTransactionAsync();
        }
        public async Task AtualizarCliente(Cliente Cliente, Cliente Body)
        {
            if (Body.Nome != null)
                Cliente.Nome = Body.Nome;
            else
                Cliente.Nome = Cliente.Nome;

            if (Body.Telefone != null)
                Cliente.Telefone = Body.Telefone;
            else
                Cliente.Telefone = Cliente.Telefone;

            if (Body.ProjetoId > 0)
                Cliente.ProjetoId = Body.ProjetoId;
            else
                Cliente.ProjetoId = Cliente.ProjetoId;

            if (Body.IdEmpresa > 0)
            {
                var empresaAtu = await dbContext.Empresas.FindAsync(Cliente.IdEmpresa);
                var empresaNova = await dbContext.Empresas.FindAsync(Body.IdEmpresa);

                if (empresaNova == null || empresaAtu == null)
                {
                    throw new Exception("Empresa nao encontrada.");
                }
                else
                {
                    var ecAtu = await dbContext.EmpresaClientes.FindAsync(empresaAtu.EmpresaId, Body.ClienteId);

                    dbContext.EmpresaClientes.Remove(ecAtu);
                    await dbContext.SaveChangesAsync();

                    dbContext.EmpresaClientes.Add(new EmpresaCliente()
                    {
                        EmpresaId = Body.IdEmpresa,
                        ClienteId = Body.ClienteId,
                    });
                    await dbContext.SaveChangesAsync();
                }
            }

            await dbContext.SaveChangesAsync();
        }
        public async Task DeletarCliente(Cliente Cliente)
        {
            var empresaCliente = dbContext.EmpresaClientes.Find(Cliente.IdEmpresa, Cliente.ClienteId);

            if (empresaCliente != null)
            {
                dbContext.EmpresaClientes.Remove(empresaCliente);
            }
            else
            {
                throw new Exception("Relação Empresa-Serviço não encontrada.");
            }
            await dbContext.SaveChangesAsync();

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