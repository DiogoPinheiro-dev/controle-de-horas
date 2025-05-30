namespace server.Models
{
    public class Coordenador
    {
        public int CoordenadorId { get; set; }
        public string? Nome { get; set; }
        public int RecursoId { get; set; }
        public Recurso? Recurso { get; set; }
        public List<Tarefa>? Tarefas { get; set; }

    }
}