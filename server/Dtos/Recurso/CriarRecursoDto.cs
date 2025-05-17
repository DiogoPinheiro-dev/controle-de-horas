using server.Models;

namespace server.Dto {
    public class CriarRecursoDto
    {
        public required string Nome { get; set; }
        public required string Tipo { get; set; }
        public required string Email { get; set; }
        public required string Telefone { get; set; }
        public required int EmpresaId { get; set; }

    }
}