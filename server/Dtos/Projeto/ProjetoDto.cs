namespace server.Dtos.Projeto
{
    public class ProjetoDto
    {
        public int ProjetoId { get; set; }
        public string? Descricao { get; set; }
        public string? Nome { get; set; }
        public int DataInicio { get; set; }
        public int DataFim { get; set; }
        public int RecursoId { get; set; }
        public int EmpresaId { get; set; }
        public int ClienteId { get; set; }
    }
}