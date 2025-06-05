using server.Dtos.Empresa;
using server.Models;

namespace server.Mappers
{
    public static class EmpresaMapper
    {
        public static EmpresaDto DtoDaEmpresa(this Empresa empresa)
        {
            return new EmpresaDto
            {
                Nome = empresa.Nome,
                ProjetoId = empresa.ProjetoId
            };
        }

        public static Empresa DtoDaCriacaoDoEmpresa(this CriarEmpresaDto EmpresaDto)
        {
            return new Empresa
            {
                Nome = EmpresaDto.Nome
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
                ProjetoId = EmpresaDto.IdProjeto
            };
        }
    }
}