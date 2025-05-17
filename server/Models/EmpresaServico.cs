using Microsoft.EntityFrameworkCore;

namespace server.Models
{
    [PrimaryKey(nameof(EmpresaId), nameof(ServicoId))]
    public class EmpresaServico
    {
        public int EmpresaId { get; set; }
        public int ServicoId { get; set; }

        public required Empresa Empresa { get; set; }
        public required Servico Servico { get; set; }
    }
}