using server.Models;

namespace server.Interfaces
{
    public interface IClienteService
    {
        Task<Cliente> CriarCliente(Cliente cliente);
        Task<Cliente> AtualizarCliente(Cliente cliente, Cliente body);
        Task<Cliente> DeletarCliente(Cliente cliente);

        Task<List<Cliente>> ObterTodosClientes();
        Task<Cliente> ObterClientePorId(int id);
        Task<List<Cliente>> ObterClientePorNome(string nome);
        Task<List<Cliente>> ObterClientePorEmail(string email);
        Task<List<Cliente>> ObterClientePorTelefone(string telefone);
    }
}