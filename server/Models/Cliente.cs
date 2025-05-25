

namespace server.Models
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string? Nome { get; set; }
        public required string Email { get; set; }
        public string? Telefone { get; set; }
    }
}