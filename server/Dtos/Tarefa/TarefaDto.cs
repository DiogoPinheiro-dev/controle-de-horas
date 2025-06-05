namespace server.Dtos.Tarefa
{
    public class TarefaDto
    {
        public string? Descricao { get; set; }
        public int DataInicio { get; set; }
        public int DataFim { get; set; }
        public int RecursoId { get; set; }
        public int ProjetoId { get; set; }
    }
}