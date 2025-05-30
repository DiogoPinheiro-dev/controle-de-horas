using System.ComponentModel.DataAnnotations.Schema;

namespace server.Models
{
    public class Apontamento
    {
        public int ApontamentoId { get; set; }
        public required string OS { get; set; }
        public string? Descricao { get; set; }
        public int HorasApontadas { get; set; }
        public int HorasFinalizadas { get; set; }
        public int DataInicio { get; set; }
        public int DataFim { get; set; }

        // [ForeignKey(nameof(SubTarefaId))]
        public int SubTarefaId { get; set; }
        public SubTarefa? SubTarefa { get; set; }

        // [ForeignKey(nameof(RecursoId))]
        public int AnalistaId { get; set; }
        public Analista? Analista { get; set; }
    }

}