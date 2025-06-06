namespace server.Dtos.Usuario
{
    public class AlterarUsuarioDto
    {
        public string? Email { get; set; }
        public string? Senha { get; set; }
        public int NivelDeUsuario { get; set; }
        public int IdEmpresa { get; set; }
        public int IdRecurso { get; set; }
        public int IdCliente { get; set; }
    }
}