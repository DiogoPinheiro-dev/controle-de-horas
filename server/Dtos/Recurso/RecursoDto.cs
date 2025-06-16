namespace server.Dtos.Recurso
{
    public class RecursoDto
    {
        public int RecursoId { get; set; }
        public string? Nome { get; set; }
        public char Tipo { get; set; }
        public string? Email { get; set; }
        public string? Telefone { get; set; }
        public int EmpresaId { get; set; }
        public int UsuarioId { get; set; }
    }
}