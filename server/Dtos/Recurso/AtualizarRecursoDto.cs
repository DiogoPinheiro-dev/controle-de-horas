namespace server.Dtos.Recurso
{
    public class AtualizarRecursoDto
    {
        public string? Nome { get; set; }
        public char Tipo { get; set; }
        public string? Telefone { get; set; }
        public int EmpresaId { get; set; }
        public int UsuarioId { get; set; }
    }
}