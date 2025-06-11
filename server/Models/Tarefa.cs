using System.ComponentModel.DataAnnotations;

namespace server.Models
{
    public class Tarefa
    {
        public int TarefaId { get; set; }

        [MaxLength(200)]
        public string? Descricao { get; set; }

        
        [MaxLength(8)]
        [MinLength(8)]
        public int DataInicio { get; set; }
        
        [MaxLength(8)]
        [MinLength(8)]
        public int DataFim { get; set; }

        public int RecursoId { get; set; }
        public string? RecursoEmail { get; set; }
        public Recurso? Recurso { get; set; }

        public int ProjetoId { get; set; }
        public Projeto? Projeto { get; set; }

        public List<SubTarefa>? SubTarefas { get; set; }
    }
}