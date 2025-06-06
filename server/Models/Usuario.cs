namespace server.Models
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public required string? Email { get; set; }
        public required string? Senha { get; set; }
        public int NivelDeUsuario { get; set; }

        public int RecursoId { get; set; }
        public int ClienteId { get; set; }
        public int EmpresaId { get; set; }
        public Recurso? Recurso { get; set; }
        public Cliente? Cliente { get; set; }
        public Empresa? Empresa { get; set; }
    }
}