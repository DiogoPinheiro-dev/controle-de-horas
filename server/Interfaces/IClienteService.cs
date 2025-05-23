using server.Models;

namespace server.Interfaces
{
    public interface IClienteService
    {
        Task CriarCliente(Cliente cliente);
        Task AtualizarCliente(Cliente cliente);
        Task DeletarCliente(Cliente cliente);

        Task<IEnumerable<Cliente>> ObterTodosClientes();
        Task<IEnumerable<Cliente>> ObterClientePorNome(string nome);
        Task<IEnumerable<Cliente>> ObterClientePorEmail(string email);
        Task<IEnumerable<Cliente>> ObterClientePorTelefone(string telefone);
    }
}