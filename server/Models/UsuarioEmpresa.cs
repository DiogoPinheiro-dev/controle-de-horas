namespace server.Models
{
    public class UsuariosEmpresas
    {
        public int UsuarioId { get; set; }
        public int EmpresaId { get; set; }

        public string? UsuarioEmail { get; set; }
        public string? EmpresaEmail { get; set; }
        
        public Usuario? Usuario { get; set; }
        public Empresa? Empresa { get; set; }
    }
}