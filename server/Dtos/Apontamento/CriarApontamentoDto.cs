namespace server.Dtos.Apontamento
{
    public class CriarApontamentoDto
    {
        public required string OS { get; set; }
        public string? Descricao { get; set; }
        public int HorasApontadas { get; set; }
        public int DataInicio { get; set; }
        public int IdSubTarefa { get; set; }
        public int IdAnalista { get; set; }
    }
}