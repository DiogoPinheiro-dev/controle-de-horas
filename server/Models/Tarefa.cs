namespace server.Models
{
    public class Tarefa
    {
        public int TarefaId { get; set; }
        public string? Descricao { get; set; }
        public int DataInicio { get; set; }
        public int DataFim { get; set; }

        // [ForeignKey(nameof(RecursoId))]
        public int CoordenadorId { get; set; }
        public Coordenador? Coordenador { get; set; }

        // [ForeignKey(nameof(ProjetoId))]
        public int ProjetoId { get; set; }
        public Projeto? Projeto { get; set; }

        // public int SubTarefaId { get; set; }
        public List<SubTarefa>? SubTarefas { get; set; }
    }
}