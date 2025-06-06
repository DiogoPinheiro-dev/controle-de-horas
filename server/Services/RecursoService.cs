using Microsoft.EntityFrameworkCore;
using server.Db;
using server.Models;
using server.Interfaces;

namespace server.Services
{
    public class RecursoService(AppDbContext dbContext) : IRecursoService
    {
        private readonly AppDbContext dbContext = dbContext;

        public async Task<Recurso> CriarRecurso(Recurso recurso)
        {
            await dbContext.Database.BeginTransactionAsync();

            var empresa = await dbContext.Empresas.FindAsync(recurso.IdEmpresa);

            if (empresa == null)
            {
                await dbContext.Database.RollbackTransactionAsync();
                throw new Exception("Empresa não encontrada.");
            }

            await dbContext.Recursos.AddAsync(recurso);
            await dbContext.SaveChangesAsync();

            EmpresaRecurso es = new()
            {
                EmpresaId = empresa.EmpresaId,
                RecursoId = recurso.RecursoId
            };

            await dbContext.EmpresaRecursos.AddAsync(es);
            await dbContext.SaveChangesAsync();

            await dbContext.Database.CommitTransactionAsync();

            return recurso;
        }

        public async Task<Recurso> AtualizarRecurso(Recurso Recurso, Recurso Body)
        {
            if (Body.Nome != null)
                Recurso.Nome = Body.Nome;
            else
                Recurso.Nome = Recurso.Nome;

            if (Body.Email != null)
                Recurso.Email = Body.Email;
            else
                Recurso.Email = Recurso.Email;

            if (Body.Telefone != null)
                Recurso.Telefone = Body.Telefone;
            else
                Recurso.Telefone = Recurso.Telefone;

            if (Body.Tipo != '\0')
                Recurso.Tipo = Body.Tipo;
            else
                Recurso.Tipo = Recurso.Tipo;

            if (Body.IdEmpresa > 0)
            {
                var empresaAtu = await dbContext.Empresas.FindAsync(Recurso.IdEmpresa);
                var empresaNova = await dbContext.Empresas.FindAsync(Body.IdEmpresa);

                if (empresaNova == null || empresaAtu == null)
                {
                    throw new Exception("Empresa nao encontrada.");
                }
                else
                {
                    var esAtu = await dbContext.EmpresaRecursos.FindAsync(empresaAtu.EmpresaId, Body.RecursoId);

                    dbContext.EmpresaRecursos.Remove(esAtu);
                    await dbContext.SaveChangesAsync();

                    dbContext.EmpresaRecursos.Add(new EmpresaRecurso()
                    {
                        EmpresaId = Body.IdEmpresa,
                        RecursoId = Body.RecursoId,
                    });
                    await dbContext.SaveChangesAsync();
                }
            }

            await dbContext.SaveChangesAsync();
            return Recurso;
        }

        public async Task<Recurso> DeletarRecurso(Recurso Recurso)
        {
            var empresaRecurso = dbContext.EmpresaRecursos.Find(Recurso.IdEmpresa, Recurso.RecursoId);

            if (empresaRecurso != null)
            {
                dbContext.EmpresaRecursos.Remove(empresaRecurso);
            }
            else
            {
                throw new Exception("Relação Empresa-Serviço não encontrada.");
            }
            await dbContext.SaveChangesAsync();

            dbContext.Recursos.Remove(Recurso);
            await dbContext.SaveChangesAsync();

            return Recurso;
        }

        public async Task<List<Recurso>> ObterTodosRecursos()
        {
            return await dbContext.Recursos.ToListAsync();
        }

        public async Task<Recurso> ObterRecursoPorId(int Id)
        {
            return await dbContext.Recursos.FindAsync(Id);
        }
        public async Task<List<Recurso>> ObterRecursoPorEmail(string Email)
        {
            List<Recurso> recursos;

            recursos = await dbContext
                .Recursos
                .Where(r => r.Email.Contains(Email)).ToListAsync();

            return recursos;
        }


        public async Task<List<Recurso>> ObterRecursoPorNome(string Nome)
        {
            List<Recurso> recursos;

            recursos = await dbContext
                .Recursos
                .Where(r => r.Nome.Contains(Nome)).ToListAsync();

            return recursos;
        }

        public async Task<List<Recurso>> ObterRecursoPorTelefone(string Telefone)
        {
            List<Recurso> recursos;


            recursos = await dbContext
                .Recursos
                .Where(r => r.Telefone.Contains(Telefone)).ToListAsync();


            return recursos;
        }

        public async Task<List<Recurso>> ObterRecursoPorTipo(char Tipo)
        {
            List<Recurso> recursos;

            recursos = await dbContext
                    .Recursos
                    .Where(r => r.Tipo == Tipo).ToListAsync();

            return recursos;
        }
    }
}