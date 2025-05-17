using Microsoft.EntityFrameworkCore;

namespace server.Models
{
    [PrimaryKey(nameof(ProjetoId))]
    public class Projeto
    {
        public required int ProjetoId { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public string Nome { get; set; } = string.Empty;

        public DateTime DataIni { get; set; }
        public DateTime DataFim { get; set; }

        public Recurso? Gerente { get; set; }
    }
}