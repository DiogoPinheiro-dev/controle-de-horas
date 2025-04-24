namespace server.Models{
    public class Empresa{
        public Guid EmpresaId { get; set; }
        public string? Nome { get; set; }

        public ICollection<Cliente>? Clientes { get; set; }
        public ICollection<Servico>? Servicos { get; set; }
    }
}