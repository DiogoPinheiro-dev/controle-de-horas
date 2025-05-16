using Microsoft.EntityFrameworkCore;
using server.Models;

namespace server.Db {
    public class AppDbContext : DbContext {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Recurso> Recursos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Servico> Servicos { get; set; }
        public DbSet<Tarefa> Tarefas { get; set; }
        public DbSet<SubTarefa> SubTarefas { get; set; }
        public DbSet<Apontamento> Apontamentos { get; set; }
    }
}