namespace server.Dtos.Empresa
{
    public class AtualizarEmpresaDto
    {
        public string? Nome { get; set; }
        public int ProjetoId { get; set; }
        public int UsuarioId { get; set; }
    }
}