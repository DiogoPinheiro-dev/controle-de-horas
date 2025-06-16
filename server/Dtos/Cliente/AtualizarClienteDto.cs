namespace server.Dtos.Cliente
{
    public class AtualizarClienteDto
    {
        public string? Nome { get; set; }
        public string? Telefone { get; set; }
        public int ProjetoId { get; set; }
        public int EmpresaId { get; set; }
        public int UsuarioId { get; set; }
    }
}