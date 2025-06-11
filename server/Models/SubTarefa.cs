using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server.Models
{
    public class SubTarefa
    {
        public int SubTarefaId { get; set; }

        [MaxLength(200)]
        public string? Descricao { get; set; }

        [MaxLength(8)]
        [MinLength(8)]
        public int DataInicio { get; set; }

        [MaxLength(8)]
        [MinLength(8)]
        public int DataFim { get; set; }

        public List<Apontamento>? Apontamentos { get; set; }

        public int TarefaId { get; set; }
        public Tarefa? Tarefa { get; set; }

        public int RecursoId { get; set; }
        public string? RecursoEmail { get; set; }
        public Recurso? Recurso { get; set; }
    }
}