namespace server.Models
{
    public class Projeto
    {
        public int ProjetoId { get; set; }
        public string? Descricao { get; set; } 
        public string? Nome { get; set; } 

        public string? DataIni { get; set; }
        public string? DataFim { get; set; }

        public Recurso? Gerente { get; set; }
    }
}