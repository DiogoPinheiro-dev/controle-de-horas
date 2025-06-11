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

            var empresa = await dbContext
                .Empresas
                .Select(e => e)
                .Where(e => e.EmpresaId == recurso.IdEmpresa)
                .FirstOrDefaultAsync() ?? throw new Exception("Empresa não encontrada.");

            await dbContext.Recursos.AddAsync(recurso);
            await dbContext.SaveChangesAsync();

            var erExistente = await dbContext
                .EmpresaRecursos
                .Select(er => er)
                .Where(er => er.RecursoId == recurso.RecursoId)
                .FirstOrDefaultAsync();

            if (erExistente != null)
            {
                throw new Exception("Esse recurso já está vinculado a uma empresa.");
            }

            dbContext.EmpresaRecursos.Add(new EmpresaRecurso()
            {
                EmpresaId = recurso.IdEmpresa,
                EmpresaEmail = empresa.Email,
                RecursoId = recurso.RecursoId,
                RecursoEmail = recurso.Email
            });
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

            if (Body.Telefone != null)
                Recurso.Telefone = Body.Telefone;
            else
                Recurso.Telefone = Recurso.Telefone;

            if (Body.Tipo != '\0')
                Recurso.Tipo = Body.Tipo;
            else
                Recurso.Tipo = Recurso.Tipo;

            if (Body.IdUsuario > 0)
            {
                await dbContext.Database.BeginTransactionAsync();

                var usuarioAntigo = await dbContext
                    .Usuarios
                    .Select(u => u)
                    .Where(u => u.UsuarioId == Recurso.IdUsuario)
                    .FirstOrDefaultAsync() ?? throw new Exception("Usuario nao encontrado.");

                var usuarioNovo = await dbContext
                    .Usuarios
                    .Select(u => u)
                    .Where(u => u.UsuarioId == Body.IdUsuario)
                    .FirstOrDefaultAsync() ?? throw new Exception("Esse usuario nao existe");

                var urAntiga = await dbContext
                    .UsuariosRecursos
                    .Select(ur => ur)
                    .Where(ur => ur.UsuarioId == Recurso.IdUsuario && ur.RecursoId == Recurso.RecursoId)
                    .FirstOrDefaultAsync() ?? throw new Exception("relação usuario-recurso nao existe");

                dbContext.Usuarios.Remove(usuarioAntigo);
                // await dbContext.SaveChangesAsync();

                dbContext.UsuariosRecursos.Remove(urAntiga);
                // await dbContext.SaveChangesAsync();

                Recurso.IdUsuario = usuarioNovo.UsuarioId;
                // Recurso.Email = usuarioNovo.Email;
                await dbContext.SaveChangesAsync();

                dbContext.UsuariosRecursos.Add(new UsuariosRecursos
                {
                    UsuarioId = Recurso.IdUsuario,
                    UsuarioEmail = Recurso.Email,
                    RecursoId = Recurso.RecursoId,
                    RecursoEmail = Recurso.Email
                });
                await dbContext.SaveChangesAsync();

                await dbContext.Database.CommitTransactionAsync();
            }
            else
                Recurso.IdUsuario = Recurso.IdUsuario;

            if (Body.IdEmpresa > 0)
            {
                await dbContext.Database.BeginTransactionAsync();

                var empresaAtu = await dbContext
                    .Empresas
                    .Select(e => e)
                    .Where(e => e.EmpresaId == Recurso.IdEmpresa)
                    .FirstOrDefaultAsync() ?? throw new Exception("Empresa nao encontrada.");

                var empresaNova = await dbContext
                    .Empresas
                    .Select(e => e)
                    .Where(e => e.EmpresaId == Body.IdEmpresa)
                    .FirstOrDefaultAsync() ?? throw new Exception("Empresa nao encontrada.");

                var esNova = await dbContext
                    .EmpresaRecursos
                    .Select(er => er)
                    .Where(er => er.EmpresaId == empresaNova.EmpresaId && er.RecursoId == Recurso.RecursoId)
                    .FirstOrDefaultAsync();

                if (esNova != null)
                {
                    dbContext.EmpresaRecursos.Remove(esNova);
                    await dbContext.SaveChangesAsync();
                }

                dbContext.EmpresaRecursos.Add(new EmpresaRecurso()
                {
                    EmpresaId = Body.IdEmpresa,
                    EmpresaEmail = empresaNova.Email,
                    RecursoId = Recurso.RecursoId,
                    RecursoEmail = Recurso.Email ?? Body.Email
                });
                await dbContext.SaveChangesAsync();

                Recurso.IdEmpresa = Body.IdEmpresa;
                await dbContext.SaveChangesAsync();

                await dbContext.Database.CommitTransactionAsync();
            }

            await dbContext.SaveChangesAsync();
            return Recurso;
        }

        public async Task<Recurso> DeletarRecurso(Recurso Recurso)
        {
            await dbContext.Database.BeginTransactionAsync();

            var empresaRecurso = dbContext.EmpresaRecursos.Find(Recurso.IdEmpresa, Recurso.RecursoId);

            if (empresaRecurso != null)
            {
                dbContext.EmpresaRecursos.Remove(empresaRecurso);
                await dbContext.SaveChangesAsync();
            }

            var usuario = await dbContext
                .Usuarios
                .Select(u => u)
                .Where(u => u.UsuarioId == Recurso.IdUsuario)
                .FirstOrDefaultAsync();

            if (usuario != null)
            {
                dbContext.Usuarios.Remove(usuario);
                await dbContext.SaveChangesAsync();
            }

            var usuarioRecurso = await dbContext
                .UsuariosRecursos
                .Select(ur => ur)
                .Where(ur => ur.RecursoId == Recurso.RecursoId && ur.UsuarioId == Recurso.IdUsuario)
                .FirstOrDefaultAsync();

            if (usuarioRecurso != null)
            {
                dbContext.UsuariosRecursos.Remove(usuarioRecurso);
                await dbContext.SaveChangesAsync();
            }

            dbContext.Recursos.Remove(Recurso);
            await dbContext.SaveChangesAsync();

            await dbContext.Database.CommitTransactionAsync();
            return Recurso;
        }

        public async Task<List<Recurso>> ObterTodosRecursos()
        {
            return await dbContext.Recursos.ToListAsync();
        }

        public async Task<Recurso> ObterRecursoPorId(int Id)
        {
            return await dbContext
                .Recursos
                .Select(r => r)
                .Where(r => r.RecursoId == Id)
                .FirstOrDefaultAsync() ?? throw new Exception("Recurso não encontrado.");
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