using Microsoft.EntityFrameworkCore;

namespace server.Models{
    [PrimaryKey(nameof(EmailCoordenador), nameof(TarefaId))]
    public class Tarefa{
        public Guid TarefaId { get; set; }
        public string? DescricaoTarefa { get; set; }

        public ICollection<SubTarefa>? SubTarefas { get; set; }

        public string? EmailCoordenador { get; set; }

        public DateTime DataInicio { get; set; }     
        public DateTime DataFim { get; set; }     
        
        public Projeto? Projeto { get; set; }   
        public Recurso? Coordenador { get; set; }
   }
}