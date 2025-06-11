namespace server.Dtos.Usuario
{
    public class UsuarioDto
    {
        public int UsuarioId { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
        public int NivelDeUsuario { get; set; }
    }
}