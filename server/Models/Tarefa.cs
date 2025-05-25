namespace server.Models
{
    public class Tarefa
    {
        public int TarefaId { get; set; }
        public string? Descricao { get; set; }
        public int DataInicio { get; set; }
        public int DataFim { get; set; }

        public int IdCoordenador { get; set; }
        public int IdProjeto { get; set; }
    }
}