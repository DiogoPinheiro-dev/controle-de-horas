using server.Models;

namespace server.Interfaces
{
    public interface IProjetoService 
    {
        Task CriarProjeto(Projeto projeto);
        Task AtualizarProjeto(Projeto projeto, Projeto body);
        Task DeletarProjeto(Projeto projeto);

        Task<Projeto> ObterProjetoPorId(int id);
        Task<List<Projeto>> ObterTodosProjetos();
        Task<List<Projeto>> ObterProjetoPorNome(string nome);
        Task<List<Projeto>> ObterProjetoPorDescricao(string descricao);
        
        Task<List<Projeto>> ObterProjetosPorData(int dataIni, int dataFim);
    }
}