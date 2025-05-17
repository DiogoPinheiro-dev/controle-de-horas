using server.Models;

namespace server.Dto {
    public class AtualizarRecursoDto
    {
        public string Nome { get; set; } = string.Empty;
        public string Tipo { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public int EmpresaId { get; set; }

    }
}