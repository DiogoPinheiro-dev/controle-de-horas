using System.ComponentModel.DataAnnotations;

namespace server.Models
{
    public class Servico
    {
        public int ServicoId { get; set; }
        public decimal Custo { get; set; }
        
        [MaxLength(200)]
        public string? Descricao { get; set; }
        
        public int IdEmpresa { get; set; }
        public List<EmpresaServico>? EmpresaServicos { get; set; }
    }
}