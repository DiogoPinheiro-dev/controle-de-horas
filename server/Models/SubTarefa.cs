namespace server.Models
{
    public class SubTarefa
    {
        public required int SubTarefaId { get; set; }
        public string? DescricaoSubTarefa { get; set; } 
        public string? DataIni { get; set; }
        public string? DataFim { get; set; }
        
        public Tarefa? Tarefa { get; set; }
    }
}