namespace server.Dtos.SubTarefa
{
    public class CriarSubTarefaDto
    {
        public string? Descricao { get; set; }
        public int DataInicio { get; set; }
        public int IdTarefa { get; set; }
        public int IdAnalista { get; set;}
    }
}