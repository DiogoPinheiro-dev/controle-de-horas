using server.Dto;
using server.Models;

namespace server.Mappers
{
    public static class RecursoMapper
    {
        public static Recurso DtoDaCriacaoDoRecurso(this CriarRecursoDto recursoDto)
        {
            return new Recurso
            {
                Nome = recursoDto.Nome,
                Tipo = recursoDto.Tipo,
                Email = recursoDto.Email,
                Telefone = recursoDto.Telefone
            };
        }

        public static Recurso DtoDaAtualizacaoDoRecurso(this AtualizarRecursoDto recursoDto)
        {
            return new Recurso
            {
                Nome = recursoDto.Nome,
                Tipo = recursoDto.Tipo,
                Email = recursoDto.Email,
                Telefone = recursoDto.Telefone
            };
        }

        public static Recurso DtoDaDelecaoDoRecurso(this DeletarRecursoDto recursoDto)
        {
            return new Recurso
            {
                RecursoId = recursoDto.RecursoId,
                Email = ""
            };
        }
    }
}