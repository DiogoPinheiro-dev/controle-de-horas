using Microsoft.EntityFrameworkCore;

namespace server.Models
{
    [PrimaryKey(nameof(ServicoId))]
    public class Servico
    {
        public int ServicoId { get; set; }
        public decimal Custo { get; set; }
        public string Descricao { get; set; } = string.Empty;

        public required Empresa Empresa { get; set; }

    }
}