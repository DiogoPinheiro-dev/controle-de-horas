namespace server.Models
{
    public class Tarefa
    {
        public int TarefaId { get; set; }
        public string? DescricaoTarefa { get; set; } 
        public string? DataInicio { get; set; }
        public string? DataFim { get; set; }

        public Recurso? Coordenador { get; set; }
    }
}