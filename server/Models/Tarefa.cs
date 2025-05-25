namespace server.Models
{
    public class Tarefa
    {
        public int TarefaId { get; set; }
        public string? Descricao { get; set; } 
        public int DataInicio { get; set; }
        public int DataFim { get; set; }

        // public Recurso? Coordenador { get; set; }
    }
}