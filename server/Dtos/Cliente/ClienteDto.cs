namespace server.Dtos.Cliente
{
    public class ClienteDto
    { 
        public string? Nome { get; set; }
        public required string Email { get; set; }
        public string? Telefone { get; set; }
        public int ProjetoId { get; set; }
        public int IdEmpresa { get; set; }
    }
}