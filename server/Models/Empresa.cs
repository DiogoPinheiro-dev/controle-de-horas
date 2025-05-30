using System.ComponentModel.DataAnnotations.Schema;

namespace server.Models
{
    public class Empresa
    {
        public int EmpresaId { get; set; }
        public string? Nome { get; set; }

        // [ForeignKey(nameof(ProjetoId))]
        // public int ProjetoId { get; set; }
        public List<Projeto>? Projetos { get; set; }
        public ICollection<EmpresaRecurso>? EmpresaRecursos { get; set; }
        public ICollection<EmpresaServico>? EmpresaServicos { get; set; }

        public ICollection<EmpresaCliente>? EmpresaClientes { get; set; }
    }
}