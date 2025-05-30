using System.ComponentModel.DataAnnotations.Schema;

namespace server.Models
{
    public class SubTarefa
    {
        public int SubTarefaId { get; set; }
        public string? Descricao { get; set; }
        public int DataInicio { get; set; }
        public int DataFim { get; set; }

        // public int ApontamentoId { get; set; }
        public List<Apontamento>? Apontamentos { get; set; }

        public int TarefaId { get; set; }
        public Tarefa? Tarefa { get; set; }

        public int AnalistaId { get; set; }
        public Analista? Analista { get; set; }
    }
}