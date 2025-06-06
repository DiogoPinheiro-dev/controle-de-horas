using System.ComponentModel.DataAnnotations;

namespace server.Models
{
    public class Recurso
    {
        public int RecursoId { get; set; }

        [MaxLength(60)]
        public string? Nome { get; set; }
        
        public char Tipo { get; set; }

        [MaxLength(60)]
        public required string Email { get; set; }

        [MaxLength(16)]
        public string? Telefone { get; set; }
        
        public int UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }
        
        public int IdEmpresa { get; set; }
        public List<EmpresaRecurso>? EmpresaRecursos { get; set; }

        public List<Projeto>? Projeto { get; set; }
        public List<Tarefa>? Tarefas { get; set; }
        public List<SubTarefa>? SubTarefas { get; set; }
        public List<Apontamento>? Apontamentos { get; set; }
    }
}