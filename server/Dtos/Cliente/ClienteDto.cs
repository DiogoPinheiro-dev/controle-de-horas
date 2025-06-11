namespace server.Dtos.Cliente
{
    public class ClienteDto
    {
        public int ClienteId { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Telefone { get; set; }
        public int ProjetoId { get; set; }
        public int IdEmpresa { get; set; }
        public int UsuarioId { get; set; }
    }
}