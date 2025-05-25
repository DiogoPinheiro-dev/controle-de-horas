namespace server.Models
{
    public class SubTarefa
    {
        public int SubTarefaId { get; set; }
        public string? Descricao { get; set; }
        public int DataInicio { get; set; }
        public int DataFim { get; set; }

        public int IdTarefa { get; set; }
        public int IdAnalista { get; set; }
    }
}