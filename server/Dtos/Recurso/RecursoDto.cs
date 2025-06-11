namespace server.Dtos.Recurso
{
    public class RecursoDto
    {
        public int RecursoId { get; set; }
        public string? Nome { get; set; }
        public char Tipo { get; set; }
        public string? Email { get; set; }
        public string? Telefone { get; set; }
        public int IdEmpresa { get; set; }
        public string? EmailEmpresa { get; set; }
        public int IdUsuario { get; set; }
    }
}