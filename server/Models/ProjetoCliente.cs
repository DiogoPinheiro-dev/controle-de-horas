using Microsoft.EntityFrameworkCore;

namespace server.Models
{
    [PrimaryKey(nameof(ProjetoId), nameof(ClienteId))]
    public class ProjetoCliente
    {
        public int ProjetoId { get; set; }
        public int ClienteId { get; set; }

        public required Cliente Cliente { get; set; }
        public required Projeto Projeto { get; set; }
    }
}