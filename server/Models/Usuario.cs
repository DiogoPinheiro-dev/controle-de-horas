namespace server.Models
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public required string? Email { get; set; }
        public required string? Senha { get; set; }
        public int NivelDeUsuario { get; set; }

        public List<UsuariosRecursos>? UsuariosRecursos { get; set; }
        public List<UsuariosClientes>? UsuariosClientes { get; set; }
        public List<UsuariosEmpresas>? UsuariosEmpresas { get; set; }
    }
}