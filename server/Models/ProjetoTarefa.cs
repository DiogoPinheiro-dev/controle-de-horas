using Microsoft.EntityFrameworkCore;

namespace server.Models
{
    [PrimaryKey(nameof(ProjetoId), nameof(TarefaId))]
    public class ProjetoTarefa
    {
        public int ProjetoId { get; set; }
        public int TarefaId { get; set; }

        public Projeto? Projeto { get; set; }
        public Tarefa? Tarefa { get; set; }
    }
}