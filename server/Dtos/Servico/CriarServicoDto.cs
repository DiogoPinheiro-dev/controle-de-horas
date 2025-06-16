namespace server.Dtos.Servico
{
    public class CriarServicoDto
    {
        public decimal Custo { get; set; }
        public string? Descricao { get; set; }
        public int EmpresaId { get; set; }
    }
}