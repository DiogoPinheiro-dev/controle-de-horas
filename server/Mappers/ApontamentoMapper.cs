using server.Dtos.Apontamento;
using server.Models;

namespace server.Mappers
{
    public static class ApontamentoMapper
    {
        public static Apontamento DtoDaCriacaoDoApontamento(this CriarApontamentoDto apontamentoDto)
        {
            return new Apontamento
            {
                OS = apontamentoDto.OS,
                Descricao = apontamentoDto.Descricao,
                HorasApontadas = apontamentoDto.HorasApontadas,
                DataInicio = apontamentoDto.DataInicio,
                IdAnalista = apontamentoDto.IdAnalista,
                IdSubTarefa = apontamentoDto.IdSubTarefa
            };
        }

        public static Apontamento DtoDaDelecaoDoApontamento(this DeletarApontamentoDto apontamentoDto)
        {
            return new Apontamento
            {
                ApontamentoId = apontamentoDto.ApontamentoId,
                IdSubTarefa = apontamentoDto.IdSubTarefa,
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
                IdAnalista = apontamentoDto.IdAnalista,
            };
        }
    }
}