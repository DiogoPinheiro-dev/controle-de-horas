using server.Models;

namespace server.Dto
{
    public class AtualizarRecursoDto
    {
        public string? Nome { get; set; }
        public string? Tipo { get; set; }
        public string? Email { get; set; }
        public string? Telefone { get; set; }

        public ICollection<Projeto>? Projetos { get; set; }
        public ICollection<Tarefa>? Tarefas { get; set; }
        public ICollection<SubTarefa>? SubTarefas { get; set; }
        public ICollection<Apontamento>? Apontamentos { get; set; }

    }
}