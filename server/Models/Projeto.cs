using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server.Models
{
    public class Projeto
    {
        public int ProjetoId { get; set; }

        [MaxLength(200)]
        public string? Descricao { get; set; }

        [MaxLength(60)]
        public string? Nome { get; set; }

        [MaxLength(8)]
        [MinLength(8)]
        public int DataInicio { get; set; }
        
        [MaxLength(8)]
        [MinLength(8)]
        public int DataFim { get; set; } 

        public int RecursoId { get; set; }
        public Recurso? Recurso { get; set; }

        public int EmpresaId { get; set; }
        public Empresa? Empresa { get; set; }

        public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; }

        // public int TarefaId { get; set; }
        public List<Tarefa>? Tarefas { get; set; }
    }
}