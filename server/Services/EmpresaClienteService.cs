using Microsoft.EntityFrameworkCore;
using server.Db;
using server.Interfaces;
using server.Models;

namespace server.Services
{
    public class EmpresaClienteService : IEmpresaClienteService
    {
        private readonly AppDbContext dbContext;

        public EmpresaClienteService(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AlterarRelacaoEmpresaCliente(EmpresaCliente empresaCliente, EmpresaCliente Body)
        {
            if (Body.ClienteId <= 0)
                empresaCliente.ClienteId = empresaCliente.ClienteId;
            else
                empresaCliente.ClienteId = Body.ClienteId;

            if (Body.EmpresaId <= 0)
                empresaCliente.EmpresaId = empresaCliente.EmpresaId;
            else
                empresaCliente.EmpresaId = Body.EmpresaId;

            await dbContext.SaveChangesAsync();
        }

        public async Task DeletarRelacaoEmpresaCliente(EmpresaCliente empresaCliente)
        {
            dbContext.Empresa_Cliente.Remove(empresaCliente);
            await dbContext.SaveChangesAsync();
        }

        public async Task<EmpresaCliente> ObterRelacoesPorIdDaEmpresa(int idEmpresa)
        {
            return await dbContext.Empresa_Cliente.FindAsync(idEmpresa);
        }

        public async Task<EmpresaCliente> ObterRelacoesPorIdDoCliente(int idCliente)
        {
            return await dbContext.Empresa_Cliente.FindAsync(idCliente);
        }

        public async Task<List<EmpresaCliente>> ObterTodasRelacoes()
        {
            return await dbContext.Empresa_Cliente.ToListAsync();
        }

        public async Task RelacionarEmpresaCliente(EmpresaCliente empresaCliente)
        {
            await dbContext.Empresa_Cliente.AddAsync(empresaCliente);
            await dbContext.SaveChangesAsync();
        }
    }
}