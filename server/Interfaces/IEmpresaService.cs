using server.Models;

namespace server.Interfaces
{
    public interface IEmpresaService
    {
        Task<Empresa> CriarEmpresa(Empresa empresa);
        Task<Empresa> AtualizarEmpresa(Empresa empresam, Empresa body);
        Task<Empresa> DeletarEmpresa(Empresa empresa);

        Task<List<Empresa>> ObterTodasEmpresas();
        Task<Empresa> ObterEmpresaPorId(int id);
        Task<List<Empresa>> ObterEmpresaPorNome(string nome);
    }
}