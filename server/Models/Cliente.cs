using Microsoft.EntityFrameworkCore;

namespace server.Models{
    [PrimaryKey(nameof(Email), nameof(ClienteId))]
    public class Cliente{
        public Guid ClienteId { get; set; }
        public string? Nome { get; set; }

        public string? Email { get; set; }
        public string? Telefone { get; set; }

        public Empresa? Empresa { get; set; }
    }
}