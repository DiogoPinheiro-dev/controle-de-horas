using Microsoft.EntityFrameworkCore;

namespace server.Models
{
    [PrimaryKey(nameof(EmpresaId), nameof(ServicoId))]
    public class EmpresaServico
    {
        public int EmpresaId { get; set; }
        public int ServicoId { get; set; }

        public Empresa? Empresa { get; set; }
        public Servico? Servico { get; set; }
    }
}