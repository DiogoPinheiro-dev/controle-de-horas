namespace server.Models
{
    public class Recurso
    {
        public int RecursoId { get; set; }
        public string? Nome { get; set; }
        public string? Tipo { get; set; }
        public required string Email { get; set; }
        public string? Telefone { get; set; }

        public List<Analista>? Analistas { get; set; }
        public List<Gerente>? Gerentes { get; set; }
        public List<Coordenador>? Coordenadores { get; set; }
        public List<EmpresaRecurso>? EmpresaRecursos { get; set; }
    }
}