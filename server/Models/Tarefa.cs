using Microsoft.EntityFrameworkCore;

namespace server.Models
{
    [PrimaryKey(nameof(EmailCoordenador), nameof(TarefaId))]
    public class Tarefa
    {
        public int TarefaId { get; set; }
        public string DescricaoTarefa { get; set; } = string.Empty;

        public required string EmailCoordenador { get; set; }

        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }

        public required Projeto Projeto { get; set; }
        public required Recurso Recurso { get; set; }
    }
}