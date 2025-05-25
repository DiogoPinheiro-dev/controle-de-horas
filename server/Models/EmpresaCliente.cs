using Microsoft.EntityFrameworkCore;

namespace server.Models
{
    [PrimaryKey(nameof(EmpresaId), nameof(ClienteId))]
    public class EmpresaCliente
    {
        public int EmpresaId { get; set; }
        public int ClienteId { get; set; }

        public Empresa? Empresa { get; set; }
        public Cliente? Cliente { get; set; }
    }
}