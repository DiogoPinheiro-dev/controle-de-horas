namespace server.Models
{
    public class Recurso
    {
        public required int RecursoId { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Tipo { get; set; } = string.Empty;
        public required string Email { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
    }
}