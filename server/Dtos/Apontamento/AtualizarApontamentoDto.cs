namespace server.Dto
{
    public class AtualizarApontamentoDto
    { 
        public string Descricao { get; set; } = string.Empty;
        public string HorasApontadas { get; set; } = string.Empty;
        public string HorasFinalizadas { get; set; } = string.Empty;
        public DateOnly DataInicio { get; set; }
        public DateOnly DataFim { get; set; }
    }
}