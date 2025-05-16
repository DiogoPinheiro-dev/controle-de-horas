using Microsoft.EntityFrameworkCore;

namespace server.Models
{
    [PrimaryKey(nameof(OS), nameof(ApontamentoId))]
    public class Apontamento
    {
        public int ApontamentoId { get; set; }
        public required string OS { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;

        public string HorasApontadas { get; set; } = string.Empty;
        public string HorasFinalizadas { get; set; } = string.Empty;

        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }

        public required Recurso Recurso { get; set; }
        public required SubTarefa SubTarefa { get; set; }
    }

}