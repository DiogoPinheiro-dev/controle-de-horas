using server.Models;

namespace server.Interfaces
{
    public interface IClienteService
    {
        Task CriarCliente(Cliente cliente);
        Task AtualizarCliente(Cliente cliente, Cliente body);
        Task DeletarCliente(Cliente cliente);

        Task<List<Cliente>> ObterTodosClientes();
        Task<Cliente> ObterClientePorId(int id);
        Task<List<Cliente>> ObterClientePorNome(string nome);
        Task<List<Cliente>> ObterClientePorEmail(string email);
        Task<List<Cliente>> ObterClientePorTelefone(string telefone);
    }
}