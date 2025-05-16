using Microsoft.EntityFrameworkCore;

namespace server.Models
{
    [PrimaryKey(nameof(SubTarefaId))]
    public class SubTarefa
    {
        public required int SubTarefaId { get; set; }
        public string DescricaoSubTarefa { get; set; } = string.Empty;

        public DateTime DataIni { get; set; }
        public DateTime DataFim { get; set; }

        public required Recurso Recurso { get; set; }
        public required Tarefa Tarefa { get; set; }
    }
}