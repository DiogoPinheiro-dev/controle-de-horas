namespace server.Dtos.Servico
{
    public class ServicoDto
    {
        public int ServicoId { get; set; }
        public decimal Custo { get; set; }
        public string? Descricao { get; set; }
        public int EmpresaId { get; set; }
    }
}