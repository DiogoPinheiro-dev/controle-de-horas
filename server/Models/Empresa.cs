using Microsoft.EntityFrameworkCore;

namespace server.Models
{
    [PrimaryKey(nameof(EmpresaId))]
    public class Empresa
    {
        public int EmpresaId { get; set; }
        public string Nome { get; set; } = string.Empty;
    }
}