using Microsoft.EntityFrameworkCore;

namespace server.Models
{
    [PrimaryKey(nameof(ProjetoId))]
    public class Projeto
    {
        public required int ProjetoId { get; set; }
        public string? Descricao { get; set; } 
        public string? Nome { get; set; } 

        public string? DataIni { get; set; }
        public string? DataFim { get; set; }

        public Recurso? Gerente { get; set; }
    }
}