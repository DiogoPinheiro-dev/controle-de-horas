namespace server.Dtos.Apontamento
{
    public class DeletarApontamentoDto
    { 
        public required int ApontamentoId { get; set; }
        public int IdSubTarefa { get; set; }
    }
}