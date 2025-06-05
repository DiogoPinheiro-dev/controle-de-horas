namespace server.Dtos.Cliente
{
    public class AtualizarClienteDto
    {
        public string? Nome { get; set; }
        public string? Telefone { get; set; }
        public int IdProjeto { get; set; }
        public int IdEmpresa { get; set; }
    }
}