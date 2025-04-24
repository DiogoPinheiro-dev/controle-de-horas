using server.Dto;
using server.Models;

namespace server.Mappers
{
    public static class RecursoMapper
    {
        public static RecursoDto DtoDeRecurso(this Recurso modeloDoRecurso)
        {
            return new RecursoDto
            {
                RecursoId = modeloDoRecurso.RecursoId,
                Nome = modeloDoRecurso.Nome,
                Tipo = modeloDoRecurso.Tipo,
                Email = modeloDoRecurso.Email
            };
        }

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
                Telefone = recursoDto.Telefone,
                Projetos = recursoDto.Projetos,
                Tarefas = recursoDto.Tarefas,
                SubTarefas = recursoDto.SubTarefas,
                Apontamentos = recursoDto.Apontamentos
            };
        }

        public static Recurso DtoDaDelecaoDoRecurso(this DeletarRecursoDto recursoDto)
        {
            return new Recurso
            {
                RecursoId = recursoDto.RecursoId,
                Nome = recursoDto.Nome,
                Tipo = recursoDto.Tipo,
                Email = recursoDto.Email,
                Telefone = recursoDto.Telefone
            };
        }
    }
}