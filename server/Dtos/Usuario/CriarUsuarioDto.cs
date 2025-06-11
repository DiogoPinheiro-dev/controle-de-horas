namespace server.Dtos.Usuario
{
    public class CriarUsuarioDto
    {
        public required string? Email { get; set; }
        public required string? Senha { get; set; }
        public required int NivelDeUsuario { get; set; }
    }
}