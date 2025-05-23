namespace server.Models
{
    public class Apontamento
    {
        public required int ApontamentoId { get; set; }
        public required string OS { get; set; }
        public string? Descricao { get; set; } 

        public int HorasApontadas { get; set; }
        public int HorasFinalizadas { get; set; }

        public int DataInicio { get; set; }
        public int DataFim { get; set; }

        public SubTarefa? SubTarefa { get; set; }
    }

}