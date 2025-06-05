using server.Dtos.Apontamento;
using server.Models;

namespace server.Mappers
{
    public static class ApontamentoMapper
    {
        public static ApontamentoDto DtoDoApontamento(this Apontamento apontamentoDto)
        {
            return new ApontamentoDto
            {
                OS = apontamentoDto.OS,
                Descricao = apontamentoDto.Descricao,
                HorasApontadas = apontamentoDto.HorasApontadas,
                HorasFinalizadas = apontamentoDto.HorasFinalizadas,
                DataInicio = apontamentoDto.DataInicio,
                DataFim = apontamentoDto.DataFim,
                SubTarefaId = apontamentoDto.SubTarefaId,
                RecursoId = apontamentoDto.RecursoId
            };
        }

        public static Apontamento DtoDaCriacaoDoApontamento(this CriarApontamentoDto apontamentoDto)
        {
            return new Apontamento
            {
                OS = apontamentoDto.OS,
                Descricao = apontamentoDto.Descricao,
                HorasApontadas = apontamentoDto.HorasApontadas,
                DataInicio = apontamentoDto.DataInicio,
                RecursoId = apontamentoDto.IdAnalista,
                SubTarefaId = apontamentoDto.IdSubTarefa
            };
        }

        public static Apontamento DtoDaDelecaoDoApontamento(this DeletarApontamentoDto apontamentoDto)
        {
            return new Apontamento
            {
                ApontamentoId = apontamentoDto.ApontamentoId,
                SubTarefaId = apontamentoDto.IdSubTarefa,
                OS = "",
            };
        }

        public static Apontamento DtoDaAtualizacaoDoApontamento(this AtualizarApontamentoDto apontamentoDto)
        {
            return new Apontamento
            {
                OS = "",
                Descricao = apontamentoDto.Descricao,
                HorasFinalizadas = apontamentoDto.HorasFinalizadas,
                DataFim = apontamentoDto.DataFim,
                RecursoId = apontamentoDto.IdAnalista,
            };
        }
    }
}