using server.Models;

namespace server.Interfaces
{
    public interface IProjetoService 
    {
        Task<Projeto> CriarProjeto(Projeto projeto);
        Task<Projeto> AtualizarProjeto(Projeto projeto, Projeto body);
        Task<Projeto> DeletarProjeto(Projeto projeto);

        Task<Projeto> ObterProjetoPorId(int id);
        Task<List<Projeto>> ObterTodosProjetos();
        Task<List<Projeto>> ObterProjetoPorNome(string nome);
        Task<List<Projeto>> ObterProjetoPorDescricao(string descricao);
        
        Task<List<Projeto>> ObterProjetosPorData(int dataIni, int dataFim);
    }
}