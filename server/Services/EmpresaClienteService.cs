using Microsoft.EntityFrameworkCore;
using server.Db;
using server.Interfaces;
using server.Models;

namespace server.Services
{
    public class EmpresaClienteService(AppDbContext dbContext) : IEmpresaClienteService
    {
        private readonly AppDbContext dbContext = dbContext;
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
    }
}