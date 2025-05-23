using Microsoft.EntityFrameworkCore;

namespace server.Models
{
    [PrimaryKey(nameof(Email))]
    public class Cliente
    {
        public required int ClienteId { get; set; }
        public string? Nome { get; set; }
        public required string Email { get; set; }
        public string? Telefone { get; set; }
    }
}