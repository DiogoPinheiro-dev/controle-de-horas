namespace server.Models
{
    public class UsuariosRecursos
    {
        public int UsuarioId { get; set; }
        public int RecursoId{ get; set; }
        
        public string? UsuarioEmail { get; set; }
        public string? RecursoEmail { get; set; }

        public Usuario? Usuario { get; set; }
        public Recurso? Recurso { get; set; }
    }
}