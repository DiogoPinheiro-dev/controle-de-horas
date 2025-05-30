namespace server.Dtos.Projeto
{
    public class CriarProjetoDto
    {
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public int DataIni { get; set; }
        public int IdCliente { get; set; }
        // public int IdTarefa { get; set; }
        public int IdGerente { get; set; }
    }
}