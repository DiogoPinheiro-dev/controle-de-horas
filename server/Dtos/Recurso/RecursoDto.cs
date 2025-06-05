namespace server.Dtos.Recurso
{
    public class RecursoDto
    {
        public string? Nome { get; set; }
        public char Tipo { get; set; }
        public required string Email { get; set; }
        public string? Telefone { get; set; }
        public int IdEmpresa { get; set; }
    }
}