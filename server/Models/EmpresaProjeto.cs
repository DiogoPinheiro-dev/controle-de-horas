using Microsoft.EntityFrameworkCore;

namespace server.Models
{
    [PrimaryKey(nameof(EmpresaId), nameof(ProjetoId))]
    public class EmpresaProjeto
    {
        public int EmpresaId { get; set; }
        public int ProjetoId { get; set; }

        public required Empresa Empresa { get; set; }
        public required Projeto Projeto { get; set; }
    }
}