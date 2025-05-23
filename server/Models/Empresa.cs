using Microsoft.EntityFrameworkCore;

namespace server.Models
{
    [PrimaryKey(nameof(EmpresaId))]
    public class Empresa
    {
        public required int EmpresaId { get; set; }
        public string? Nome { get; set; }
    }
}