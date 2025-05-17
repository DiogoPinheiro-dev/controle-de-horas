using Microsoft.EntityFrameworkCore;
using server.Models;

namespace server.Db
{
    public class AppDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<SubTarefa> SubTarefas { get; set; }
        public DbSet<Apontamento> Apontamentos { get; set; }
        public DbSet<Tarefa> Tarefas { get; set; }
        public DbSet<Projeto> Projetos { get; set; }
        public DbSet<Recurso> Recursos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Servico> Servicos { get; set; }
        public DbSet<Empresa> Empresas { get; set; }

        public DbSet<EmpresaCliente> Empresa_Cliente { get; set; }
        public DbSet<EmpresaProjeto> Empresa_Projeto { get; set; }
        public DbSet<EmpresaRecurso> Empresa_Recurso { get; set; }
        public DbSet<EmpresaServico> Empresa_Servico { get; set; }
        public DbSet<ProjetoCliente> Projeto_Cliente { get; set; }
        public DbSet<ProjetoTarefa> Projeto_Tarefa { get; set; }
        public DbSet<RecursoSubTarefa> Recurso_SubTarefa { get; set; }
        public DbSet<RecursoApontamento> Recurso_Apontamento { get; set; }
    }
}