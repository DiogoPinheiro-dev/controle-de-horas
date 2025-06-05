using System.ComponentModel.DataAnnotations;

namespace server.Models
{
    public class Cliente
    {
        public int ClienteId { get; set; }

        [MaxLength(60)]
        public string? Nome { get; set; }

        [MaxLength(60)]
        public required string Email { get; set; }

        [MaxLength(16)]
        public string? Telefone { get; set; }

        public int ProjetoId { get; set; }
        public List<Projeto>? Projetos { get; set; }

        public int IdEmpresa { get; set; }
        public List<EmpresaCliente>? EmpresaClientes { get; set; }
    }
}