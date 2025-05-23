namespace server.Dto
{
    public class CriarApontamentoDto
    {
        public required string OS { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public string HorasApontadas { get; set; } = string.Empty;
        public DateOnly DataInicio { get; set; }
    }
}