namespace server.Dto
{
    public class DeletarRecursoDto
    {
        public Guid RecursoId { get; set; }
        public required string Nome { get; set; }
        public required string Tipo { get; set; }
        public required string Email { get; set; }
        public required string Telefone { get; set; }
    }
}