using Microsoft.EntityFrameworkCore;

namespace server.Models
{
    [PrimaryKey(nameof(RecursoId), nameof(SubTarefaId))]
    public class RecursoSubTarefa
    {
        public int RecursoId { get; set; }
        public int SubTarefaId { get; set; }

        public required Recurso Recurso { get; set; }
        public required SubTarefa SubTarefa { get; set; }
    }    
}