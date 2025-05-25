namespace server.Models
{
    public class Recurso
    {
        public int RecursoId { get; set; }
        public string? Nome { get; set; }
        public string? Tipo { get; set; }
        public required string Email { get; set; }
        public string? Telefone { get; set; }
    }
}