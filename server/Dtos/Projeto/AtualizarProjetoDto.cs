namespace server.Dtos.Projeto
{
    public class AtualizarProjetoDto
    {
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public int DataFim { get; set; }
        public int ProjetoId { get; set; }
        public int EmpresaId { get; set; }
    }
}