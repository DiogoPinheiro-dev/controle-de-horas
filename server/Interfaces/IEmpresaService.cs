using server.Models;

namespace server.Interfaces
{
    public interface IEmpresaService
    {
        Task CriarEmpresa(Empresa empresa);
        Task AtualizarEmpresa(Empresa empresa);
        Task DeletarEmpresa(Empresa empresa);

        Task<IEnumerable<Empresa>> ObterTodasEmpresas();
        Task<IEnumerable<Empresa>> ObterEmpresaPorNome(string nome);
    }
}