namespace server.Dtos.Apontamento
{
    public class CriarApontamentoDto
    {
        public required string OS { get; set; }
        public string? Descricao { get; set; }
        public int HorasApontadas { get; set; }
        public int DataInicio { get; set; }
        public int SubTarefaId { get; set; }
        public int AnalistaId { get; set; }
    }
}