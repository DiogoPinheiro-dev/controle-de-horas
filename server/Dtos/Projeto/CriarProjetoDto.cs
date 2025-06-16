namespace server.Dtos.Projeto
{
    public class CriarProjetoDto
    {
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public int DataInicio { get; set; }
        public int ClienteId { get; set; }
        public int GerenteId { get; set; }
        public int EmpresaId { get; set; }
    }
}