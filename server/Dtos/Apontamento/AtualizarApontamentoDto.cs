namespace server.Dtos.Apontamento
{
    public class AtualizarApontamentoDto
    {
        public string? Descricao { get; set; }
        public int HorasFinalizadas { get; set; }
        public int DataFim { get; set; }
        public int AnalistaId { get; set; }
    }
}