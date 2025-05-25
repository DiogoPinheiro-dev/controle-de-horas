using Microsoft.EntityFrameworkCore;

namespace server.Models
{
    [PrimaryKey(nameof(EmpresaId), nameof(RecursoId))]
    public class EmpresaRecurso
    {
        public int EmpresaId { get; set; }
        public int RecursoId { get; set; }

        public Empresa? Empresa { get; set; }
        public Recurso? Recurso { get; set; }
    }
}