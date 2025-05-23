namespace server.Models
{
    public class SubTarefa
    {
        public required int SubTarefaId { get; set; }
        public string? DescricaoSubTarefa { get; set; } 
        public DateOnly DataIni { get; set; }
        public DateOnly DataFim { get; set; }
        
        public Tarefa? Tarefa { get; set; }
    }
}