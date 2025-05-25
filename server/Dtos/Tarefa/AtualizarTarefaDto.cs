namespace server.Dtos.Tarefa
{
    public class AtualizarTarefaDto
    {
        public string? Descricao { get; set; }
        public int DataInicio { get; set; }
        public int DataFim { get; set; }
    }
}