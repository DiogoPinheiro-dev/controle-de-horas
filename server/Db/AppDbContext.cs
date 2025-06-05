using Microsoft.EntityFrameworkCore;
using server.Models;

namespace server.Db
{
    public class AppDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Servico> Servicos { get; set; }
        public DbSet<Projeto> Projetos { get; set; }
        public DbSet<Tarefa> Tarefas { get; set; }
        public DbSet<SubTarefa> SubTarefas { get; set; }
        public DbSet<Apontamento> Apontamentos { get; set; }
        public DbSet<Recurso> Recursos { get; set; }
        public DbSet<EmpresaCliente> EmpresaClientes { get; set; }
        public DbSet<EmpresaServico> EmpresaServicos { get; set; }
        public DbSet<EmpresaRecurso> EmpresaRecursos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Empresas <-> Clientes (N:N)
            modelBuilder.Entity<EmpresaCliente>()
                .HasKey(ec => new { ec.EmpresaId, ec.ClienteId });
            modelBuilder.Entity<EmpresaCliente>()
                .HasOne(ec => ec.Empresa)
                .WithMany(e => e.EmpresaClientes)
                .HasForeignKey(ec => ec.EmpresaId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<EmpresaCliente>()
                .HasOne(ec => ec.Cliente)
                .WithMany(c => c.EmpresaClientes)
                .HasForeignKey(ec => ec.ClienteId)
                .OnDelete(DeleteBehavior.Restrict);

            // Empresas <-> Servicos (N:N)
            modelBuilder.Entity<EmpresaServico>()
                .HasKey(es => new { es.EmpresaId, es.ServicoId });
            modelBuilder.Entity<EmpresaServico>()
                .HasOne(es => es.Empresa)
                .WithMany(e => e.EmpresaServicos)
                .HasForeignKey(es => es.EmpresaId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<EmpresaServico>()
                .HasOne(es => es.Servico)
                .WithMany(s => s.EmpresaServicos)
                .HasForeignKey(es => es.ServicoId)
                .OnDelete(DeleteBehavior.Restrict);

            // Empresas <-> Recursos (N:N)
            modelBuilder.Entity<EmpresaRecurso>()
                .HasKey(er => new { er.EmpresaId, er.RecursoId });
            modelBuilder.Entity<EmpresaRecurso>()
                .HasOne(er => er.Empresa)
                .WithMany(e => e.EmpresaRecursos)
                .HasForeignKey(er => er.EmpresaId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<EmpresaRecurso>()
                .HasOne(er => er.Recurso)
                .WithMany(r => r.EmpresaRecursos)
                .HasForeignKey(er => er.RecursoId)
                .OnDelete(DeleteBehavior.Restrict);

            // Empresas -> Projetos (1:N)
            modelBuilder.Entity<Empresa>()
                .HasMany(e => e.Projetos)
                .WithOne(p => p.Empresa)
                .HasForeignKey(p => p.EmpresaId)
                .OnDelete(DeleteBehavior.Restrict);

            // Clientes -> Projetos (1:N)
            modelBuilder.Entity<Cliente>()
                .HasMany(c => c.Projetos)
                .WithOne(p => p.Cliente)
                .HasForeignKey(p => p.ClienteId)
                .OnDelete(DeleteBehavior.Restrict);

            // Projetos -> Gerentes (N:1)
            modelBuilder.Entity<Projeto>()
                .HasOne(p => p.Recurso)
                .WithMany(g => g.Projeto)
                .HasForeignKey(p => p.RecursoId)
                .OnDelete(DeleteBehavior.Restrict);

            // Projetos -> Tarefas (1:N)
            modelBuilder.Entity<Projeto>()
                .HasMany(p => p.Tarefas)
                .WithOne(t => t.Projeto)
                .HasForeignKey(t => t.ProjetoId)
                .OnDelete(DeleteBehavior.Restrict);

            // Tarefas -> Coordenadores (N:1)
            modelBuilder.Entity<Tarefa>()
                .HasOne(t => t.Recurso)
                .WithMany(c => c.Tarefas)
                .HasForeignKey(t => t.RecursoId)
                .OnDelete(DeleteBehavior.Restrict);

            // Tarefas -> SubTarefas (1:N)
            modelBuilder.Entity<Tarefa>()
                .HasMany(t => t.SubTarefas)
                .WithOne(st => st.Tarefa)
                .HasForeignKey(st => st.TarefaId)
                .OnDelete(DeleteBehavior.Restrict);

            // SubTarefas -> Analistas (N:1)
            modelBuilder.Entity<SubTarefa>()
                .HasOne(st => st.Recurso)
                .WithMany(a => a.SubTarefas)
                .HasForeignKey(st => st.RecursoId)
                .OnDelete(DeleteBehavior.Restrict);

            // SubTarefas -> Apontamentos (1:N)
            modelBuilder.Entity<SubTarefa>()
                .HasMany(st => st.Apontamentos)
                .WithOne(a => a.SubTarefa)
                .HasForeignKey(a => a.SubTarefaId)
                .OnDelete(DeleteBehavior.Restrict);

            // Apontamentos -> Analistas (N:1)
            modelBuilder.Entity<Apontamento>()
                .HasOne(a => a.Recurso)
                .WithMany(an => an.Apontamentos)
                .HasForeignKey(a => a.RecursoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Recurso>(entity =>
            {
                entity.ToTable(tb =>
                {
                    tb.HasCheckConstraint("CK_Tipo", "Tipo IN ('A', 'G', 'C')");
                });
            });

            modelBuilder.Entity<Servico>().Property(s => s.Custo).HasColumnType("decimal(18,2)");

            // Definição das chaves primárias
            modelBuilder.Entity<Empresa>().HasKey(e => e.EmpresaId);
            modelBuilder.Entity<Cliente>().HasKey(c => c.ClienteId);
            modelBuilder.Entity<Servico>().HasKey(s => s.ServicoId);
            modelBuilder.Entity<Projeto>().HasKey(p => p.ProjetoId);
            modelBuilder.Entity<Tarefa>().HasKey(t => t.TarefaId);
            modelBuilder.Entity<SubTarefa>().HasKey(st => st.SubTarefaId);
            modelBuilder.Entity<Apontamento>().HasKey(a => a.ApontamentoId);
            modelBuilder.Entity<Recurso>().HasKey(r => r.RecursoId);
        }
    }
}