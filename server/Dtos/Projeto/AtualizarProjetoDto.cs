namespace server.Dtos.Projeto
{
    public class AtualizarProjetoDto
    {
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public int DataFim { get; set; }
        public int IdProjeto { get; set; }
        public int IdEmpresa { get; set; }
    }
}