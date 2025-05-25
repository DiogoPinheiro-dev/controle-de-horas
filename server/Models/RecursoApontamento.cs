using Microsoft.EntityFrameworkCore;

namespace server.Models
{
    [PrimaryKey(nameof(RecursoId), nameof(ApontamentoId))]
    public class RecursoApontamento
    {
        public int RecursoId { get; set; }
        public int ApontamentoId { get; set; }

        public Apontamento? Apontamento { get; set; }
        public Recurso? Recurso { get; set; }
    }
}