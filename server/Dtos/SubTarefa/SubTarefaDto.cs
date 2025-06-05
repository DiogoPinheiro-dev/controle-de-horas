namespace server.Dtos.SubTarefa
{
    public class SubTarefaDto
    { 
        public string? Descricao { get; set; }
        public int DataInicio { get; set; }
        public int DataFim { get; set; }
        public int TarefaId { get; set; }
        public int RecursoId { get; set; }
    }
}