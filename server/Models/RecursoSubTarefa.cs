using Microsoft.EntityFrameworkCore;

namespace server.Models
{
    [PrimaryKey(nameof(RecursoId), nameof(SubTarefaId))]
    public class RecursoSubTarefa
    {
        public int RecursoId { get; set; }
        public int SubTarefaId { get; set; }

        public Recurso? Recurso { get; set; }
        public SubTarefa? SubTarefa { get; set; }
    }    
}