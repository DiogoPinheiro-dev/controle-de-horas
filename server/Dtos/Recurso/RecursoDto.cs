namespace server.Dto{
    public class RecursoDto{
        public Guid RecursoId { get; set; }
        public required string Nome { get; set; }
        public required string Tipo { get; set; }
        public required string Email { get; set; }
    }
}