using Microsoft.EntityFrameworkCore;
using server.Db;
using server.Models;
using server.Interfaces;

namespace server.Services
{
    public class EmpresaService(AppDbContext dbContext) : IEmpresaService
    {
        private readonly AppDbContext dbContext = dbContext;

        public async Task<Empresa> CriarEmpresa(Empresa Empresa)
        {
            Empresa e = await dbContext.Empresas
                .Select(e => e)
                .Where(e => e.Email == Empresa.Email)
                .FirstOrDefaultAsync();

            if (e != null)
                throw new Exception("Já existe uma empresa com este email.");

            dbContext.Empresas.Add(Empresa);
            await dbContext.SaveChangesAsync();
            return Empresa;
        }
        public async Task<Empresa> AtualizarEmpresa(Empresa Empresa, Empresa Body)
        {
            if (Body.Nome != null)
                Empresa.Nome = Body.Nome;
            else
                Empresa.Nome = Empresa.Nome;

            // if (Body.ProjetoId > 0)
            //     Empresa.ProjetoId = Body.ProjetoId;
            // else
            //     Empresa.ProjetoId = Empresa.ProjetoId;

            if (Body.IdUsuario > 0)
            {
                await dbContext.Database.BeginTransactionAsync();

                var usuario = await dbContext.Usuarios
                    .Select(u => u)
                    .Where(u => u.UsuarioId == Body.IdUsuario)
                    .FirstOrDefaultAsync() ?? throw new Exception("Usuário não encontrado.");

                Empresa.IdUsuario = usuario.UsuarioId;
                await dbContext.SaveChangesAsync();

                var usuarioEmpresaAtual = await dbContext.UsuariosEmpresas
                    .Select(ue => ue)
                    .Where(ue => ue.EmpresaId == Empresa.EmpresaId && ue.UsuarioId == usuario.UsuarioId)
                    .FirstOrDefaultAsync();

                if (usuarioEmpresaAtual == null)
                {
                    dbContext.UsuariosEmpresas.Add(new UsuariosEmpresas
                    {
                        EmpresaId = Empresa.EmpresaId,
                        EmpresaEmail = Empresa.Email,
                        UsuarioId = usuario.UsuarioId,
                        UsuarioEmail = usuario.Email
                    });

                    await dbContext.SaveChangesAsync();
                }
                else
                {
                    await dbContext.Database.RollbackTransactionAsync();
                    throw new Exception("Usuário já está vinculado a esta empresa.");
                }

                await dbContext.Database.CommitTransactionAsync();
            }
            else
            {
                Empresa.IdUsuario = Empresa.IdUsuario;
            }

            await dbContext.SaveChangesAsync();
            return Empresa;
        }
        public async Task<Empresa> DeletarEmpresa(Empresa Empresa)
        {
            await dbContext.Database.BeginTransactionAsync();

            var relacaoUE = await dbContext.UsuariosEmpresas
                .Select(ue => ue)
                .Where(ue => ue.EmpresaId == Empresa.EmpresaId)
                .FirstOrDefaultAsync();

            if (relacaoUE != null)
            {
                dbContext.UsuariosEmpresas.Remove(relacaoUE);
                await dbContext.SaveChangesAsync();
            }

            List<EmpresaServico> relacaoES = await dbContext.EmpresaServicos
                .Select(es => es)
                .Where(es => es.EmpresaId == Empresa.EmpresaId)
                .ToListAsync();
            
            if (relacaoES.Count > 0)
            {
                dbContext.EmpresaServicos.RemoveRange(relacaoES);
                await dbContext.SaveChangesAsync();
            }

            List<EmpresaRecurso> relacaoER = await dbContext.EmpresaRecursos
                .Select(er => er)
                .Where(er => er.EmpresaId == Empresa.EmpresaId)
                .ToListAsync();

            if (relacaoER.Count > 0)
            {
                dbContext.EmpresaRecursos.RemoveRange(relacaoER);
                await dbContext.SaveChangesAsync();
            }

            List<EmpresaCliente> relacaoEC = await dbContext.EmpresaClientes
                .Select(ec => ec)
                .Where(ec => ec.EmpresaId == Empresa.EmpresaId)
                .ToListAsync();

            if (relacaoEC.Count > 0)
            {
                dbContext.EmpresaClientes.RemoveRange(relacaoEC);
                await dbContext.SaveChangesAsync();
            }

            List<Projeto> projetos = await dbContext.Projetos
                .Select(p => p)
                .Where(p => p.EmpresaId == Empresa.EmpresaId)
                .ToListAsync();
            
            if (projetos.Count > 0)
            {
                dbContext.Projetos.RemoveRange(projetos);
                await dbContext.SaveChangesAsync();
            }

            List<Tarefa> tarefas = await dbContext.Tarefas
                .Select(t => t)
                .Where(t => projetos.Select(p => p.ProjetoId).Contains(t.ProjetoId))
                .ToListAsync();
            
            if (tarefas.Count > 0)
            {
                dbContext.Tarefas.RemoveRange(tarefas);
                await dbContext.SaveChangesAsync();
            }

            List<SubTarefa> subTarefas = await dbContext.SubTarefas
                .Select(st => st)
                .Where(st => tarefas.Select(t => t.TarefaId).Contains(st.TarefaId))
                .ToListAsync();

            if (subTarefas.Count > 0)
            {
                dbContext.SubTarefas.RemoveRange(subTarefas);
                await dbContext.SaveChangesAsync();
            }

            dbContext.Empresas.Remove(Empresa);
            await dbContext.SaveChangesAsync();
            await dbContext.Database.CommitTransactionAsync();

            return Empresa;
        }

        public async Task<List<Empresa>> ObterTodasEmpresas()
        {
            return await dbContext.Empresas.ToListAsync();

        }

        public async Task<Empresa> ObterEmpresaPorId(int id)
        {
            return await dbContext.Empresas.Select(e => e)
                .Where(e => e.EmpresaId == id)
                .FirstOrDefaultAsync() ?? throw new Exception("Empresa não encontrada.");
        }

        public async Task<List<Empresa>> ObterEmpresaPorEmail(string Email)
        {
            List<Empresa> empresas;

            empresas = await dbContext
                .Empresas
                .Where(r => r.Email.Contains(Email)).ToListAsync();

            return empresas;
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
                ).ToListAsync() ?? throw new Exception("Nenhuma empresa encontrada com este nome.");

            return Empresa;
        }
    }
}