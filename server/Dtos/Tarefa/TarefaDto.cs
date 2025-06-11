namespace server.Dtos.Tarefa
{
    public class TarefaDto
    {
        public int TarefaId { get; set; }
        public string? Descricao { get; set; }
        public int DataInicio { get; set; }
        public int DataFim { get; set; }
        public int CoordenadorId { get; set; }
        public int ProjetoId { get; set; }
    }
}