using Microsoft.EntityFrameworkCore;

namespace server.Models
{
    [PrimaryKey(nameof(Email))]
    public class Cliente
    {
        public required int ClienteId { get; set; }
        public string Nome { get; set; } = string.Empty;
        public required string Email { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
    }
}