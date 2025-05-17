using Microsoft.EntityFrameworkCore;

namespace server.Models
{
    [PrimaryKey(nameof(ProjetoId), nameof(TarefaId))]
    public class ProjetoTarefa
    {
        public int ProjetoId { get; set; }
        public int TarefaId { get; set; }

        public required Projeto Projeto { get; set; }
        public required Tarefa Tarefa { get; set; }
    }
}