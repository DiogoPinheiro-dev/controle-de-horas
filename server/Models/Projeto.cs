using Microsoft.EntityFrameworkCore;

namespace server.Models
{
    [PrimaryKey(nameof(ProjetoId), nameof(EmailCliente), nameof(EmailGerente))]
    public class Projeto
    {
        public required int ProjetoId { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public string Nome { get; set; } = string.Empty;

        public DateTime DataIni { get; set; }
        public DateTime DataFim { get; set; }

        public required Recurso Recurso { get; set; }
        public required Cliente Cliente { get; set; }
        public required Empresa Empresa { get; set; }

        public required string EmailGerente { get; set; } = string.Empty;
        public required string EmailCliente { get; set; } = string.Empty;
    }
}