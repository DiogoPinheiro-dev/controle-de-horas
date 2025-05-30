namespace server.Models
{
    public class Analista
    {
        public int AnalistaId { get; set; }
        public string? Nome { get; set; }
        public int RecursoId { get; set; }
        public Recurso? Recurso { get; set; }
        public List<SubTarefa>? SubTarefas { get; set; }
        public List<Apontamento>? Apontamentos { get; set; }

    }
}