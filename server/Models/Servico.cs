namespace server.Models{
    public class Servico{
        public Guid ServicoId { get; set; }
        public decimal Custo { get; set; }
        public string? Descricao { get; set; }

        public Empresa? Empresa { get; set; }
        
    }

}