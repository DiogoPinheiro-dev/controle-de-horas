using server.Models;

namespace server.Interfaces
{
    public interface IProjetoClienteService
    {
        public Task RelacionarProjetoCliente(ProjetoCliente ProjetoCliente);
        public Task AlterarRelacaoProjetoCliente(ProjetoCliente ProjetoCliente, ProjetoCliente Body);
        public Task DeletarRelacaoProjetoCliente(ProjetoCliente ProjetoCliente);

        public Task<ProjetoCliente> ObterRelacoesPorIdDaProjeto(int idProjeto);
        public Task<ProjetoCliente> ObterRelacoesPorIdDoCliente(int idCliente);

        public Task<List<ProjetoCliente>> ObterTodasRelacoes();
    }
}