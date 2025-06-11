using System.ComponentModel.DataAnnotations;

namespace server.Models
{
    public class Apontamento
    {
        public int ApontamentoId { get; set; }

        [MaxLength(9)]
        public required string OS { get; set; }

        [MaxLength(200)]
        public string? Descricao { get; set; }

        [MaxLength(4)]
        public int HorasApontadas { get; set; }

        [MaxLength(4)]
        public int HorasFinalizadas { get; set; }

        [MaxLength(8)]
        [MinLength(8)]
        public int DataInicio { get; set; }
       
        [MaxLength(8)]
        [MinLength(8)]
        public int DataFim { get; set; }

        public int SubTarefaId { get; set; }
        public SubTarefa? SubTarefa { get; set; }

        public int RecursoId { get; set; }
        public string? RecursoEmail { get; set; }
        public Recurso? Recurso { get; set; }
    }

}