namespace server.Models
{
    public class Projeto
    {
        public int ProjetoId { get; set; }
        public string? Descricao { get; set; }
        public string? Nome { get; set; }

        public int DataInicio { get; set; }
        public int DataFim { get; set; }

        public int IdGerente { get; set; }
    }
}