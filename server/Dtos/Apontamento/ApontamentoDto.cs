namespace server.Dtos.Apontamento
{
    public class ApontamentoDto
    {
        public string? OS { get; set; }
        public string? Descricao { get; set; }
        public int HorasApontadas { get; set; }
        public int HorasFinalizadas { get; set; }
        public int DataInicio { get; set; }
        public int DataFim { get; set; }
        public int SubTarefaId { get; set; }
        public int RecursoId { get; set; }
    }
}