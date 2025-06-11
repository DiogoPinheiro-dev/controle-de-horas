using Microsoft.EntityFrameworkCore;
using server.Models;

namespace server.Db
{
    public class AppDbContext(DbContextOptions options) : DbContext(options)
    {
        // Recursos
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Servico> Servicos { get; set; }
        public DbSet<Recurso> Recursos { get; set; }
        public DbSet<EmpresaCliente> EmpresaClientes { get; set; }
        public DbSet<EmpresaServico> EmpresaServicos { get; set; }
        public DbSet<EmpresaRecurso> EmpresaRecursos { get; set; }

        // Atividades
        public DbSet<Projeto> Projetos { get; set; }
        public DbSet<Tarefa> Tarefas { get; set; }
        public DbSet<SubTarefa> SubTarefas { get; set; }
        public DbSet<Apontamento> Apontamentos { get; set; }

        // Usuarios
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<UsuariosClientes> UsuariosClientes { get; set; }
        public DbSet<UsuariosEmpresas> UsuariosEmpresas { get; set; }
        public DbSet<UsuariosRecursos> UsuariosRecursos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Empresas <-> Clientes (N:N)
            modelBuilder.Entity<EmpresaCliente>()
                .HasKey(ec => new { ec.EmpresaId, ec.ClienteId });
            modelBuilder.Entity<EmpresaCliente>()
                .HasOne(ec => ec.Empresa)
                .WithMany(e => e.EmpresaClientes)
                .HasForeignKey(ec => new { ec.EmpresaId, ec.EmpresaEmail })
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<EmpresaCliente>()
                .HasOne(ec => ec.Cliente)
                .WithMany(c => c.EmpresaClientes)
                .HasForeignKey(ec => new { ec.ClienteId, ec.ClienteEmail })
                .OnDelete(DeleteBehavior.Restrict);

            // Empresas <-> Servicos (N:N)
            modelBuilder.Entity<EmpresaServico>()
                .HasKey(es => new { es.EmpresaId, es.ServicoId });
            modelBuilder.Entity<EmpresaServico>()
                .HasOne(es => es.Empresa)
                .WithMany(e => e.EmpresaServicos)
                .HasForeignKey(es => new { es.EmpresaId, es.EmpresaEmail })
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
                .HasForeignKey(er => new { er.EmpresaId, er.EmpresaEmail })
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<EmpresaRecurso>()
                .HasOne(er => er.Recurso)
                .WithMany(r => r.EmpresaRecursos)
                .HasForeignKey(er => new { er.RecursoId, er.RecursoEmail })
                .OnDelete(DeleteBehavior.Restrict);

            // Usuario <-> Cliente (N:N)
            modelBuilder.Entity<UsuariosClientes>()
                .HasKey(uc => new { uc.UsuarioId, uc.ClienteId });
            modelBuilder.Entity<UsuariosClientes>()
                .HasOne(uc => uc.Usuario)
                .WithMany(u => u.UsuariosClientes)
                .HasForeignKey(uc => new { uc.UsuarioId, uc.UsuarioEmail })
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<UsuariosClientes>()
                .HasOne(uc => uc.Cliente)
                .WithMany(c => c.UsuariosClientes)
                .HasForeignKey(uc => new { uc.ClienteId, uc.ClienteEmail })
                .OnDelete(DeleteBehavior.Restrict);

            // Usuario <-> Empresa (N:N)
            modelBuilder.Entity<UsuariosEmpresas>()
                .HasKey(ue => new { ue.UsuarioId, ue.EmpresaId });
            modelBuilder.Entity<UsuariosEmpresas>()
                .HasOne(ue => ue.Usuario)
                .WithMany(u => u.UsuariosEmpresas)
                .HasForeignKey(ue => new { ue.UsuarioId, ue.UsuarioEmail })
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<UsuariosEmpresas>()
                .HasOne(ue => ue.Empresa)
                .WithMany(e => e.UsuariosEmpresas)
                .HasForeignKey(ue => new { ue.EmpresaId, ue.EmpresaEmail })
                .OnDelete(DeleteBehavior.Restrict);

            // Usuario <-> Recurso (N:N)
            modelBuilder.Entity<UsuariosRecursos>()
                .HasKey(ur => new { ur.UsuarioId, ur.RecursoId });
            modelBuilder.Entity<UsuariosRecursos>()
                .HasOne(ur => ur.Usuario)
                .WithMany(u => u.UsuariosRecursos)
                .HasForeignKey(ur => new { ur.UsuarioId, ur.UsuarioEmail })
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<UsuariosRecursos>()
                .HasOne(ur => ur.Recurso)
                .WithMany(r => r.UsuariosRecursos)
                .HasForeignKey(ur => new { ur.RecursoId, ur.RecursoEmail })
                .OnDelete(DeleteBehavior.Restrict);

            // Empresas -> Projetos (1:N)
            modelBuilder.Entity<Empresa>()
                .HasMany(e => e.Projetos)
                .WithOne(p => p.Empresa)
                .HasForeignKey(p => new { p.EmpresaId, p.EmpresaEmail })
                .OnDelete(DeleteBehavior.Restrict);

            // Clientes -> Projetos (1:N)
            modelBuilder.Entity<Cliente>()
                .HasMany(c => c.Projetos)
                .WithOne(p => p.Cliente)
                .HasForeignKey(p => new { p.ClienteId, p.ClienteEmail })
                .OnDelete(DeleteBehavior.Restrict);

            // Projetos -> Gerentes (N:1)
            modelBuilder.Entity<Projeto>()
                .HasOne(p => p.Recurso)
                .WithMany(g => g.Projeto)
                .HasForeignKey(p => new { p.RecursoId, p.RecursoEmail })
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
                .HasForeignKey(t => new { t.RecursoId, t.RecursoEmail })
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
                .HasForeignKey(st => new { st.RecursoId, st.RecursoEmail })
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
                .HasForeignKey(a => new { a.RecursoId, a.RecursoEmail })
                .OnDelete(DeleteBehavior.Restrict);

            // Constraints
            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.ToTable(tb =>
                {
                    tb.HasCheckConstraint("CK_Email", "Email LIKE '%@gmail.com%'");
                });
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable(tb =>
                {
                    tb.HasCheckConstraint("CK_Email", "Email LIKE '%@gmail.com%'");
                });
            });

            modelBuilder.Entity<Recurso>(entity =>
            {
                entity.ToTable(tb =>
                {
                    tb.HasCheckConstraint("CK_Email", "Email LIKE '%@gmail.com%'");
                });
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable(tb =>
                {
                    tb.HasCheckConstraint("CK_Email", "Email LIKE '%@gmail.com%'");
                });
            });
            
            modelBuilder.Entity<Recurso>(entity =>
            {
                entity.ToTable(tb =>
                {
                    tb.HasCheckConstraint("CK_Tipo", "Tipo IN ('A', 'G', 'C')");
                });
            });

            modelBuilder.Entity<Servico>()
                .Property(s => s.Custo)
                .HasColumnType("decimal(18,2)");

            // Definição das chaves primárias
            modelBuilder.Entity<Empresa>()
                .Property(e => e.EmpresaId)
                .UseIdentityColumn();
            modelBuilder.Entity<Empresa>()
                .HasKey(e => new { e.EmpresaId, e.Email });

            modelBuilder.Entity<Cliente>()
                .Property(c => c.ClienteId)
                .UseIdentityColumn();
            modelBuilder.Entity<Cliente>()
                .HasKey(c => new { c.ClienteId, c.Email });

            modelBuilder.Entity<Servico>()
                .HasKey(s => s.ServicoId);

            modelBuilder.Entity<Projeto>()
                .HasKey(p => p.ProjetoId);

            modelBuilder.Entity<Tarefa>()
                .HasKey(t => t.TarefaId);

            modelBuilder.Entity<SubTarefa>()
                .HasKey(st => st.SubTarefaId);

            modelBuilder.Entity<Apontamento>()
                .HasKey(a => a.ApontamentoId);

            modelBuilder.Entity<Recurso>()
                .Property(r => r.RecursoId)
                .UseIdentityColumn();
            modelBuilder.Entity<Recurso>()
                .HasKey(r => new { r.RecursoId, r.Email });

            modelBuilder.Entity<Usuario>()
                .Property(u => u.UsuarioId)
                .UseIdentityColumn();
            modelBuilder.Entity<Usuario>()
                .HasKey(u => new { u.UsuarioId, u.Email });
        }
    }
}