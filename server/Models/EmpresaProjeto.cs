using Microsoft.EntityFrameworkCore;

namespace server.Models
{
    [PrimaryKey(nameof(EmpresaId), nameof(ProjetoId))]
    public class EmpresaProjeto
    {
        public int EmpresaId { get; set; }
        public int ProjetoId { get; set; }

        public Empresa? Empresa { get; set; }
        public Projeto? Projeto { get; set; }
    }
}