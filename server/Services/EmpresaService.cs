using Microsoft.EntityFrameworkCore;
using server.Db;
using server.Models;
using server.Interfaces;

namespace server.Services
{
    public class EmpresaService(AppDbContext dbContext) : IEmpresaService
    {
        private readonly AppDbContext dbContext = dbContext;

        public async Task CriarEmpresa(Empresa Empresa)
        {
            dbContext.Empresas.Add(Empresa);
            await dbContext.SaveChangesAsync();
        }
        public async Task AtualizarEmpresa(Empresa Empresa, Empresa Body)
        {
            if (Body.Nome != null)
                Empresa.Nome = Body.Nome;
            else
                Empresa.Nome = Empresa.Nome;

            if (Body.ProjetoId > 0)
                Empresa.ProjetoId = Body.ProjetoId;
            else
                Empresa.ProjetoId = Empresa.ProjetoId;

            await dbContext.SaveChangesAsync();
        }
        public async Task DeletarEmpresa(Empresa Empresa)
        {
            dbContext.Empresas.Remove(Empresa);
            await dbContext.SaveChangesAsync();
        }

        public async Task<List<Empresa>> ObterTodasEmpresas()
        {
            return await dbContext.Empresas.ToListAsync();

        }

        public async Task<Empresa> ObterEmpresaPorId(int id)
        {
            return await dbContext.Empresas.FindAsync(id);
        }


        public async Task<List<Empresa>> ObterEmpresaPorNome(string nome)
        {
            List<Empresa> Empresa;

            Empresa = await dbContext
                .Empresas
                .Where(
                    r => r
                        .Nome
                        .Contains(nome)
                ).ToListAsync();

            return Empresa;
        }
    }
}