namespace server.Dtos.Empresa
{
    public class EmpresaDto
    {
        public int EmpresaId { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public int ProjetoId { get; set; }
        public int UsuarioId { get; set; }
    }
}