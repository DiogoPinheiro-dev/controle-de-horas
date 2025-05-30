namespace server.Models
{
    public class Gerente
    {
        public int GerenteId { get; set; }
        public string? Nome { get; set; }
        public int RecursoId { get; set; }
        public Recurso? Recurso { get; set; }
        public List<Projeto>? Projetos { get; set; }
    }
}