using Microsoft.EntityFrameworkCore;

namespace server.Models{
    [PrimaryKey(nameof(OS), nameof(ApontamentoId))]
    public class Apontamento{
        public Guid ApontamentoId { get; set; }

        public string? OS { get; set; }
        public string? Descricao { get; set; }

        public Recurso? Recurso { get; set; }

        public string? HorasApontadas { get; set; }
        public string? HorasFinalizadas { get; set; }

        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
    }
    
}