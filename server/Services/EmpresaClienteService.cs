using Microsoft.EntityFrameworkCore;
using server.Db;
using server.Interfaces;
using server.Models;

namespace server.Services
{
    public class EmpresaClienteService(AppDbContext dbContext) : IEmpresaClienteService
    {
        private readonly AppDbContext dbContext = dbContext;

        public async Task AlterarRelacaoEmpresaCliente(EmpresaCliente EmpresaCliente, EmpresaCliente Body)
        {
            if (Body.ClienteId <= 0)
                EmpresaCliente.ClienteId = EmpresaCliente.ClienteId;
            else
                EmpresaCliente.ClienteId = Body.ClienteId;

            if (Body.EmpresaId <= 0)
                EmpresaCliente.EmpresaId = EmpresaCliente.EmpresaId;
            else
                EmpresaCliente.EmpresaId = Body.EmpresaId;

            await dbContext.SaveChangesAsync();
        }

        public async Task DeletarRelacaoEmpresaCliente(EmpresaCliente EmpresaCliente)
        {
            dbContext.EmpresaClientes.Remove(EmpresaCliente);
            await dbContext.SaveChangesAsync();
        }

        public async Task<List<EmpresaCliente>> ObterRelacoesPorIdDaEmpresa(int idEmpresa)
        {
            List<EmpresaCliente> EmpresaClientes;

            EmpresaClientes = await dbContext.EmpresaClientes.Where(er => er.EmpresaId == idEmpresa).ToListAsync();

            return EmpresaClientes;
        }

        public async Task<List<EmpresaCliente>> ObterRelacoesPorIdDoCliente(int idCliente)
        {
            List<EmpresaCliente> EmpresaClientes;

            EmpresaClientes = await dbContext.EmpresaClientes.Where(er => er.ClienteId == idCliente).ToListAsync();

            return EmpresaClientes;
        }

        public async Task<EmpresaCliente> ObterRelacaoPorId(int idCliente, int idEmpresa)
        {
            EmpresaCliente EmpresaCliente;

            EmpresaCliente = await dbContext.EmpresaClientes.Where(er => er.EmpresaId == idEmpresa && er.ClienteId == idCliente).FirstAsync();

            return EmpresaCliente;
        }
        public async Task<List<EmpresaCliente>> ObterTodasRelacoes()
        {
            return await dbContext.EmpresaClientes.ToListAsync();
        }

        public async Task RelacionarEmpresaCliente(EmpresaCliente EmpresaCliente)
        {
            await dbContext.EmpresaClientes.AddAsync(EmpresaCliente);
            await dbContext.SaveChangesAsync();
        }
    }
}