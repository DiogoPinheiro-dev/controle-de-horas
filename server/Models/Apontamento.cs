namespace server.Models
{
    public class Apontamento
    {
        public required int ApontamentoId { get; set; }
        public required string OS { get; set; }
        public string? Descricao { get; set; } 

        public string? HorasApontadas { get; set; }
        public string? HorasFinalizadas { get; set; }

        public DateOnly DataInicio { get; set; }
        public DateOnly DataFim { get; set; }

        public SubTarefa? SubTarefa { get; set; }
    }

}