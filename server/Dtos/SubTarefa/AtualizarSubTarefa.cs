namespace server.Dtos.SubTarefa
{
    public class AtualizarSubTarefaDto
    {
        public string? Descricao { get; set; }
        public int DataInicio { get; set; }
        public int DataFim { get; set; }
        public int TarefaId { get; set; }
        public int AnalistaId { get; set; }
    }
}