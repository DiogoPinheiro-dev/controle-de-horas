using System.ComponentModel.DataAnnotations;

namespace server.Models
{
    public class Empresa
    {
        public int EmpresaId { get; set; }

        [MaxLength(60)]
        public string? Nome { get; set; }

        public int ProjetoId { get; set; }
        public List<Projeto>? Projetos { get; set; }

        public List<EmpresaRecurso>? EmpresaRecursos { get; set; }
        public List<EmpresaServico>? EmpresaServicos { get; set; }
        public List<EmpresaCliente>? EmpresaClientes { get; set; }
    }
}