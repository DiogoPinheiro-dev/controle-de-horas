using Microsoft.EntityFrameworkCore;
using server.Db;
using server.Models;
using server.Interfaces;

namespace server.Services
{
    public class ProjetoService : IProjetoService
    {
        private readonly AppDbContext dbContext;

        public ProjetoService(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task CriarProjeto(Projeto Projeto)
        {
            dbContext.Projetos.Add(Projeto);
            await dbContext.SaveChangesAsync();
        }
        public async Task AtualizarProjeto(Projeto Projeto, Projeto Body)
        {
            if (Body.Descricao != null)
                Projeto.Descricao = Body.Descricao;
            else
                Projeto.Descricao = Projeto.Descricao;

            if (Body.Nome != null)
                Projeto.Nome = Body.Nome;
            else
                Projeto.Nome = Projeto.Nome;

            // if (Body.TarefaId > 0)
            //     Projeto.TarefaId = Body.TarefaId;
            // else
            //     Projeto.TarefaId = Projeto.TarefaId;

            if (Body.DataFim > 0)
                Projeto.DataFim = Body.DataFim;
            else
                Projeto.DataFim = Projeto.DataFim;

            // if (Body.GerenteId > 0)
            //     Projeto.GerenteId = Body.GerenteId;
            // else
            //     Projeto.GerenteId = Projeto.GerenteId;
            
            if (Body.EmpresaId > 0)
                Projeto.EmpresaId = Body.EmpresaId;
            else
                Projeto.EmpresaId = Projeto.EmpresaId;
                
            if (Body.ClienteId > 0)
                Projeto.ClienteId = Body.ClienteId;
            else
                Projeto.ClienteId = Projeto.ClienteId;

            await dbContext.SaveChangesAsync();
        }
        public async Task DeletarProjeto(Projeto Projeto)
        {
            dbContext.Projetos.Remove(Projeto);
            await dbContext.SaveChangesAsync();
        }

        public async Task<List<Projeto>> ObterTodosProjetos()
        {
            return await dbContext.Projetos.ToListAsync();

        }

        public async Task<Projeto> ObterProjetoPorId(int id)
        {
            return await dbContext.Projetos.FindAsync(id);
        }


        public async Task<List<Projeto>> ObterProjetoPorDescricao(string Descricao)
        {
            List<Projeto> Projeto;

            Projeto = await dbContext
                .Projetos
                .Where(r => r.Descricao.Contains(Descricao)).ToListAsync();

            return Projeto;
        }

        public async Task<List<Projeto>> ObterProjetoPorNome(string nome)
        {
            List<Projeto> Projeto;

            Projeto = await dbContext
                .Projetos
                .Where(r => r.Nome.Contains(nome)).ToListAsync();

            return Projeto;
        }

        public async Task<List<Projeto>> ObterProjetosPorData(int dataIni, int dataFim)
        {
            List<Projeto> projeto;

            projeto = await (
                dbContext
                    .Projetos
                        .Where(a => a.DataInicio >= dataIni && a.DataFim <= dataFim)
                        .ToListAsync()
            );

            return projeto;
        }
    }
}