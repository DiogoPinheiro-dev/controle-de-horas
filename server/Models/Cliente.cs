namespace server.Models
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string? Nome { get; set; }
        public required string Email { get; set; }
        public string? Telefone { get; set; }

        // [ForeignKey(nameof(ProjetoId))]
        public List<Projeto>? Projetos { get; set; }
        public ICollection<EmpresaCliente>? EmpresaClientes { get; set; }
    }
}