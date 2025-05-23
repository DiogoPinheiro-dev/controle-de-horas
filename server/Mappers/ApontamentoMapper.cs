using server.Dto;
using server.Models;

namespace server.Mappers
{
    public static class ApontamentoMapper
    {
        public static Apontamento DtoDaCriacaoDoApontamento(this CriarApontamentoDto apontamentoDto)
        {
            return new Apontamento
            {
                ApontamentoId = 0,
                OS = apontamentoDto.OS,
                Descricao = apontamentoDto.Descricao,
                HorasApontadas = apontamentoDto.HorasApontadas,
                DataInicio = apontamentoDto.DataInicio,
            };
        }

        public static Apontamento DtoDaDelecaoDoApontamento(this DeletarApontamentoDto apontamentoDto)
        {
            return new Apontamento
            {
                ApontamentoId = apontamentoDto.ApontamentoId,
                OS = "",
            };
        }

        public static Apontamento DtoDaAtualizacaoDoApontamento(this AtualizarApontamentoDto apontamentoDto)
        {
            return new Apontamento
            {
                ApontamentoId = 0,
                OS = "",
                Descricao = apontamentoDto.Descricao,
                HorasApontadas = apontamentoDto.HorasApontadas,
                HorasFinalizadas = apontamentoDto.HorasFinalizadas,
                DataInicio = apontamentoDto.DataInicio,
                DataFim = apontamentoDto.DataFim
            };
        }
    }
}