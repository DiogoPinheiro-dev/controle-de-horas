using Microsoft.EntityFrameworkCore;
using server.Db;
using server.Interfaces;
using server.Models;

namespace server.Services
{
    public class ProjetoClienteService : IProjetoClienteService
    {
        private readonly AppDbContext dbContext;

        public ProjetoClienteService(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AlterarRelacaoProjetoCliente(ProjetoCliente ProjetoCliente, ProjetoCliente Body)
        {
            if (Body.ClienteId <= 0)
                ProjetoCliente.ClienteId = ProjetoCliente.ClienteId;
            else
                ProjetoCliente.ClienteId = Body.ClienteId;

            if (Body.ProjetoId <= 0)
                ProjetoCliente.ProjetoId = ProjetoCliente.ProjetoId;
            else
                ProjetoCliente.ProjetoId = Body.ProjetoId;

            await dbContext.SaveChangesAsync();
        }

        public async Task DeletarRelacaoProjetoCliente(ProjetoCliente ProjetoCliente)
        {
            dbContext.Projeto_Cliente.Remove(ProjetoCliente);
            await dbContext.SaveChangesAsync();
        }

        public async Task<ProjetoCliente> ObterRelacoesPorIdDaProjeto(int idProjeto)
        {
            return await dbContext.Projeto_Cliente.FindAsync(idProjeto);
        }

        public async Task<ProjetoCliente> ObterRelacoesPorIdDoCliente(int idCliente)
        {
            return await dbContext.Projeto_Cliente.FindAsync(idCliente);
        }

        public async Task<List<ProjetoCliente>> ObterTodasRelacoes()
        {
            return await dbContext.Projeto_Cliente.ToListAsync();
        }

        public async Task RelacionarProjetoCliente(ProjetoCliente ProjetoCliente)
        {
            await dbContext.Projeto_Cliente.AddAsync(ProjetoCliente);
            await dbContext.SaveChangesAsync();
        }
    }
}