using server.Dtos.Empresa;
using server.Models;

namespace server.Mappers
{
    public static class EmpresaMapper
    {
        public static Empresa DtoDaCriacaoDoEmpresa(this CriarEmpresaDto EmpresaDto)
        {
            return new Empresa
            {
                Nome = EmpresaDto.Nome,
                // ProjetoId = EmpresaDto.IdProjeto
            };
        }

        public static Empresa DtoDaDelecaoDoEmpresa(this DeletarEmpresaDto EmpresaDto)
        {
            return new Empresa
            {
                EmpresaId = EmpresaDto.EmpresaId
            };
        }

        public static Empresa DtoDaAtualizacaoDoEmpresa(this AtualizarEmpresaDto EmpresaDto)
        {
            return new Empresa
            {
                Nome = EmpresaDto.Nome,
                // ProjetoId = EmpresaDto.IdProjeto
            };
        }
    }
}