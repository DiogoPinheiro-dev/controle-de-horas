using Microsoft.EntityFrameworkCore;

namespace server.Models
{
    [PrimaryKey(nameof(ProjetoId), nameof(ClienteId))]
    public class ProjetoCliente
    {
        public int ProjetoId { get; set; }
        public int ClienteId { get; set; }

        public Cliente? Cliente { get; set; }
        public Projeto? Projeto { get; set; }
    }
}