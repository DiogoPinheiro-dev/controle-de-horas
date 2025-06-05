namespace server.Dtos.Recurso
{
    public class CriarRecursoDto
    {
        public string? Nome { get; set; }
        public char Tipo { get; set; }
        public string? Email { get; set; }
        public string? Telefone { get; set; }
        public int IdEmpresa { get; set; }
    }
}