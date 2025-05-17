namespace server.Models
{
    public class Tarefa
    {
        public int TarefaId { get; set; }
        public string DescricaoTarefa { get; set; } = string.Empty;
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }

        public Recurso? Coordenador { get; set; }
    }
}