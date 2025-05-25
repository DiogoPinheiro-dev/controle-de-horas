using Microsoft.EntityFrameworkCore;

namespace server.Models
{
    [PrimaryKey(nameof(ProjetoId), nameof(RecursoId))]
    public class ProjetoRecurso
    {
        public int ProjetoId { get; set; }
        public int RecursoId { get; set; }

        public Recurso? Recurso { get; set; }
        public Projeto? Projeto { get; set; }
    }
}