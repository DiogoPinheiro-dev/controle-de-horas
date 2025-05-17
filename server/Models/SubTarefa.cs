namespace server.Models
{
    public class SubTarefa
    {
        public required int SubTarefaId { get; set; }
        public string DescricaoSubTarefa { get; set; } = string.Empty;
        public DateTime DataIni { get; set; }
        public DateTime DataFim { get; set; }
        
        public Tarefa? Tarefa { get; set; }
    }
}