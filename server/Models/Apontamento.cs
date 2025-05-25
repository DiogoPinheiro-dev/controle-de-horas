namespace server.Models
{
    public class Apontamento
    {
        public int ApontamentoId { get; set; }
        public required string OS { get; set; }
        public string? Descricao { get; set; }

        public int HorasApontadas { get; set; }
        public int HorasFinalizadas { get; set; }

        public int DataInicio { get; set; }
        public int DataFim { get; set; }

        public int IdSubTarefa { get; set; }
        public int IdAnalista { get; set; }
    }

}