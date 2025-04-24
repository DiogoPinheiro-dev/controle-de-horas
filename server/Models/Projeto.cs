namespace server.Models{
    public class Projeto{
        public Guid ProjetoId { get; set; }
        public string? Descricao { get; set; }
        public string? Nome { get; set; }
        public ICollection<Tarefa>? Tarefas { get; set; }
        public string? EmailGerente { get; set; }
        public string? EmailCliente { get; set; }
        public DateTime DataIni { get; set; }
        public DateTime DataFim { get; set; }
        
        public Recurso? Gerente { get; set; }
        public Cliente? Cliente { get; set; }
    }
}