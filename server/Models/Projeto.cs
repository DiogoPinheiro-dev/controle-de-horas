using System.ComponentModel.DataAnnotations.Schema;

namespace server.Models
{
    public class Projeto
    {
        public int ProjetoId { get; set; }
        public string? Descricao { get; set; }
        public string? Nome { get; set; }
        public int DataInicio { get; set; }
        public int DataFim { get; set; } 

        public int GerenteId { get; set; }
        public Gerente? Gerente { get; set; }

        public int EmpresaId { get; set; }
        public Empresa? Empresa { get; set; }

        public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; }

        // public int TarefaId { get; set; }
        public List<Tarefa>? Tarefas { get; set; }
    }
}