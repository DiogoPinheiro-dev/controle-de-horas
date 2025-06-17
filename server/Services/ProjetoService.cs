using Microsoft.EntityFrameworkCore;
using server.Db;
using server.Models;
using server.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;

namespace server.Services
{
    public class ProjetoService(AppDbContext dbContext) : IProjetoService
    {
        private readonly AppDbContext dbContext = dbContext;

        public async Task<Projeto> CriarProjeto(Projeto Projeto)
        {
            await dbContext.Database.BeginTransactionAsync();

            var empresa = await dbContext.Empresas
                .Select(e => e)
                .Where(e => e.EmpresaId == Projeto.EmpresaId)
                .FirstOrDefaultAsync() ?? throw new Exception("Empresa não encontrada.");

            var cliente = await dbContext.Clientes
                .Select(c => c)
                .Where(c => c.ClienteId == Projeto.ClienteId)
                .FirstOrDefaultAsync() ?? throw new Exception("Cliente não encontrado.");

            dbContext.Projetos.Add(Projeto);
            await dbContext.SaveChangesAsync();

            // empresa.ProjetoId = projeto.Property(p => p.ProjetoId).CurrentValue;
            // await dbContext.SaveChangesAsync();

            // cliente.ProjetoId = projeto.Property(p => p.ProjetoId).CurrentValue;
            // await dbContext.SaveChangesAsync();

            await dbContext.Database.CommitTransactionAsync();
            return Projeto;
        }
        public async Task<Projeto> AtualizarProjeto(Projeto Projeto, Projeto Body)
        {
            if (Body.Descricao != null)
                Projeto.Descricao = Body.Descricao;
            else
                Projeto.Descricao = Projeto.Descricao;

            if (Body.Nome != null)
                Projeto.Nome = Body.Nome;
            else
                Projeto.Nome = Projeto.Nome;

            if (Body.DataFim > 0)
                Projeto.DataFim = Body.DataFim;
            else
                Projeto.DataFim = Projeto.DataFim;

            if (Body.RecursoId > 0)
                Projeto.RecursoId = Body.RecursoId;
            else
                Projeto.RecursoId = Projeto.RecursoId;

            if (Body.EmpresaId > 0)
            {
                var empresaAtu = await dbContext
                    .Empresas
                    .Select(e => e)
                    .Where(e => e.EmpresaId == Projeto.EmpresaId)
                    .FirstOrDefaultAsync() ?? throw new Exception("Empresa não encontrada.");

                var empresaNova = await dbContext
                    .Empresas
                    .Select(e => e)
                    .Where(e => e.EmpresaId == Body.EmpresaId)
                    .FirstOrDefaultAsync() ?? throw new Exception("Empresa não encontrada.");

                Projeto.EmpresaId = Body.EmpresaId;
                await dbContext.SaveChangesAsync();
            }
            else
                Projeto.EmpresaId = Projeto.EmpresaId;

            if (Body.ClienteId > 0)
            {
                var clienteAtu = await dbContext
                    .Clientes
                    .Select(e => e)
                    .Where(e => e.ClienteId == Projeto.ClienteId)
                    .FirstOrDefaultAsync() ?? throw new Exception("Cliente não encontrado.");

                var clienteNova = await dbContext
                    .Clientes
                    .Select(e => e)
                    .Where(e => e.ClienteId == Body.ClienteId)
                    .FirstOrDefaultAsync() ?? throw new Exception("Cliente não encontrado.");

                Projeto.ClienteId = Body.ClienteId;
                await dbContext.SaveChangesAsync();
            }
            else
                Projeto.ClienteId = Projeto.ClienteId;

            await dbContext.SaveChangesAsync();
            return Projeto;
        }
        public async Task<Projeto> DeletarProjeto(Projeto Projeto)
        {
            await dbContext.Database.BeginTransactionAsync();

            var empresa = await dbContext
                .Empresas
                .Select(e => e)
                .Where(e => e.EmpresaId == Projeto.EmpresaId)
                .FirstOrDefaultAsync() ?? throw new Exception("Empresa não encontrada.");

            var cliente = await dbContext
                .Clientes
                .Select(c => c)
                .Where(c => c.ClienteId == Projeto.ClienteId)
                .FirstOrDefaultAsync() ?? throw new Exception("Cliente não encontrado.");

            var tarefa = await dbContext
                .Tarefas
                .Select(t => t)
                .Where(t => t.ProjetoId == Projeto.ProjetoId)
                .FirstOrDefaultAsync();

            if (tarefa != null)
            {
                var subTarefa = await dbContext
                    .SubTarefas
                    .Select(st => st)
                    .Where(st => st.TarefaId == tarefa.TarefaId)
                    .FirstOrDefaultAsync();

                if (subTarefa != null)
                {
                    var apontamento = await dbContext
                        .Apontamentos
                        .Select(a => a)
                        .Where(a => a.SubTarefaId == subTarefa.SubTarefaId)
                        .FirstOrDefaultAsync();

                    if (apontamento != null)
                    {
                        apontamento.SubTarefaId = 0;

                        dbContext.Apontamentos.Remove(apontamento);
                        await dbContext.SaveChangesAsync();
                    }

                    subTarefa.TarefaId = 0;

                    dbContext.SubTarefas.Remove(subTarefa);
                    await dbContext.SaveChangesAsync();
                }

                tarefa.ProjetoId = 0;

                dbContext.Tarefas.Remove(tarefa);
                await dbContext.SaveChangesAsync();
            }

            dbContext.Projetos.Remove(Projeto);

            await dbContext.SaveChangesAsync();
            await dbContext.Database.CommitTransactionAsync();

            return Projeto;
        }

        public async Task<List<Projeto>> ObterTodosProjetos()
        {
            return await dbContext.Projetos.ToListAsync();
        }

        public async Task<Projeto> ObterProjetoPorId(int id)
        {
            return await dbContext.Projetos.FindAsync(id) ?? throw new Exception("Projeto não encontrado.");
        }

        public async Task<List<Projeto>> ObterProjetosPorIdDeCliente(int idCliente)
        {
            List<Projeto> Projeto;

            Projeto = await dbContext
                .Projetos
                .Select(p => p)
                .Where(p => p.ClienteId == idCliente)
                .ToListAsync() ?? throw new Exception("Esse Cliente nao tem projetos.");

            return Projeto;
        }
        public async Task<List<Projeto>> ObterProjetosPorIdDeGerente(int idGerente)
        {
            List<Projeto> Projeto;

            Projeto = await dbContext
                .Projetos
                .Select(p => p)
                .Where(p => p.RecursoId == idGerente)
                .ToListAsync() ?? throw new Exception("Esse Gerente nao tem projetos.");

            return Projeto;
        }

        public async Task<List<Projeto>> ObterProjetosPorIdDeEmpresa(int idEmpresa)
        {
            List<Projeto> Projeto;

            Projeto = await dbContext
                .Projetos
                .Select(p => p)
                .Where(p => p.EmpresaId == idEmpresa)
                .ToListAsync() ?? throw new Exception("Esse Empresa nao tem projetos.");

            return Projeto;
        }


        public async Task<List<Projeto>> ObterProjetoPorDescricao(string Descricao)
        {
            List<Projeto> Projeto;

            Projeto = await dbContext
                .Projetos
                .Where(r => r.Descricao.Contains(Descricao)).ToListAsync() ?? throw new Exception("Projeto não encontrado.");

            return Projeto;
        }

        public async Task<List<Projeto>> ObterProjetoPorNome(string nome)
        {
            List<Projeto> Projeto;

            Projeto = await dbContext
                .Projetos
                .Where(r => r.Nome.Contains(nome)).ToListAsync() ?? throw new Exception("Projeto não encontrado.");

            return Projeto;
        }

        public async Task<List<Projeto>> ObterProjetosPorData(int dataIni, int dataFim)
        {
            List<Projeto> projeto;

            projeto = await (
                dbContext
                    .Projetos
                        .Where(a => a.DataInicio >= dataIni && a.DataFim <= dataFim)
                        .ToListAsync()) ?? throw new Exception("Projeto não encontrado.");

            return projeto;
        }
    }
}