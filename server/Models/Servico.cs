namespace server.Models
{
    public class Servico
    {
        public int ServicoId { get; set; }
        public decimal Custo { get; set; }
        public string? Descricao { get; set; }
        public ICollection<EmpresaServico> EmpresaServicos { get; set; }
    }
}