namespace server.Dtos.Servico
{
    public class AtualizarServicoDto
    { 
        public decimal Custo { get; set; }
        public string? Descricao { get; set; } 
        public int EmpresaId { get; set; }
    }
}