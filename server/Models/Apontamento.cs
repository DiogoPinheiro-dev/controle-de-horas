namespace server.Models
{
    public class Apontamento
    {
        public required int ApontamentoId { get; set; }
        public required string OS { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;

        public string HorasApontadas { get; set; } = string.Empty;
        public string HorasFinalizadas { get; set; } = string.Empty;

        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }

        public SubTarefa? SubTarefa { get; set; }
    }

}