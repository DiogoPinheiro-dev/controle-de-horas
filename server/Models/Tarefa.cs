namespace server.Models
{
    public class Tarefa
    {
        public int TarefaId { get; set; }
        public string? DescricaoTarefa { get; set; } 
        public DateOnly DataInicio { get; set; }
        public DateOnly DataFim { get; set; }

        public Recurso? Coordenador { get; set; }
    }
}