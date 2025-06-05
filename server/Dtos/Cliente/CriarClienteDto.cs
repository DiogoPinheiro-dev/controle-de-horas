namespace server.Dtos.Cliente
{
    public class CriarClienteDto
    {
        public string? Nome { get; set; }
        public required string Email { get; set; }
        public string? Telefone { get; set; }
        public int IdEmpresa { get; set; }
    }
}