using server.Dtos.Recurso;
using server.Models;

namespace server.Mappers
{
    public static class RecursoMapper
    {
        public static RecursoDto DtoDoRecurso(this Recurso recurso)
        {
            return new RecursoDto
            {
                RecursoId = recurso.RecursoId,
                Nome = recurso.Nome,
                Email = recurso.Email,
                Tipo = recurso.Tipo,
                Telefone = recurso.Telefone,
                EmpresaId = recurso.IdEmpresa,
                UsuarioId = recurso.IdUsuario
            };
        }
        
        public static Recurso DtoDaCriacaoDoRecurso(this CriarRecursoDto recursoDto)
        {
            return new Recurso
            {
                Nome = recursoDto.Nome,
                Tipo = recursoDto.Tipo,
                Email = recursoDto.Email,
                Telefone = recursoDto.Telefone,
                IdEmpresa = recursoDto.EmpresaId
            };
        }

        public static Recurso DtoDaAtualizacaoDoRecurso(this AtualizarRecursoDto recursoDto)
        {
            return new Recurso
            {
                Nome = recursoDto.Nome,
                Tipo = recursoDto.Tipo,
                Email = "",
                Telefone = recursoDto.Telefone,
                IdEmpresa = recursoDto.EmpresaId,
                IdUsuario = recursoDto.UsuarioId
            };
        }

        public static Recurso DtoDaDelecaoDoRecurso(this DeletarRecursoDto recursoDto)
        {
            return new Recurso
            {
                RecursoId = recursoDto.RecursoId,
                IdEmpresa = recursoDto.EmpresaId,
                Email = ""
            };
        }
    }
}