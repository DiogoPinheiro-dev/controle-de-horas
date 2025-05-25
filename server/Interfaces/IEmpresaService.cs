using server.Models;

namespace server.Interfaces
{
    public interface IEmpresaService
    {
        Task CriarEmpresa(Empresa empresa);
        Task AtualizarEmpresa(Empresa empresam, Empresa body);
        Task DeletarEmpresa(Empresa empresa);

        Task<List<Empresa>> ObterTodasEmpresas();
        Task<Empresa> ObterEmpresaPorId(int id);
        Task<List<Empresa>> ObterEmpresaPorNome(string nome);
    }
}