using Microsoft.EntityFrameworkCore;

namespace server.Models{
    [PrimaryKey(nameof(IdTarefa), nameof(SubTarefaId))]
    public class SubTarefa{
        public Guid SubTarefaId { get; set; }
        public string? DescricaoSubTarefa { get; set; }

        public Guid IdTarefa { get; set; }

        public DateTime DataIni { get; set; }
        public DateTime DataFim { get; set; }

        public Tarefa? Tarefa { get; set; }
        public Recurso? Analista { get; set; }
    }
}