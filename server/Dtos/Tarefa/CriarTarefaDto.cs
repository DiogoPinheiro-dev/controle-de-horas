namespace server.Dtos.Tarefa
{
    public class CriarTarefaDto
    {
        public string? Descricao { get; set; }
        public int DataInicio { get; set; }
        public int IdCoordenador { get; set; }
        public int IdProjeto { get; set; }
    }
}