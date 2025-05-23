namespace server.Dto
{
    public class CriarApontamentoDto
    {
        public required string OS { get; set; }
        public string? Descricao { get; set; }
        public int HorasApontadas { get; set; }
        public int DataInicio { get; set; }
    }
}