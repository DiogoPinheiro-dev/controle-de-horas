using server.Models;

namespace server.Interfaces
{
    public interface IProjetoService 
    {
        Task CriarProjeto(Projeto projeto);
        Task AtualizarProjeto(Projeto projeto);
        Task DeletarProjeto(Projeto projeto);

        Task<IEnumerable<Projeto>> ObterTodosProjetos();
        Task<IEnumerable<Projeto>> ObterProjetoPorNome(string nome);
        Task<IEnumerable<Projeto>> ObterProjetoPorDescricao(string descricao);
        
        Task<IEnumerable<Projeto>> ObterProjetoPorDataInicio(DateTime dataIni, DateTime dataFim);
    }
}