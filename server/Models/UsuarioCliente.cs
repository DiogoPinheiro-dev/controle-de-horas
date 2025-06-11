namespace server.Models
{
    public class UsuariosClientes
    {
        public int UsuarioId { get; set; }
        public int ClienteId { get; set; }

        public string? UsuarioEmail { get; set; }
        public string? ClienteEmail { get; set; }
        
        public Usuario? Usuario { get; set; }
        public Cliente? Cliente { get; set; }
    }
}