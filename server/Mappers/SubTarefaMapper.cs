using server.Dtos.SubTarefa;
using server.Models;

namespace server.Mappers
{
    public static class SubTarefaMapper
    {
        public static SubTarefa DtoDaCriacaoDaSubTarefa(this CriarSubTarefaDto SubTarefaDto)
        {
            return new SubTarefa
            {
                Descricao = SubTarefaDto.Descricao,
                DataInicio = SubTarefaDto.DataInicio,
                TarefaId = SubTarefaDto.IdTarefa,
                AnalistaId = SubTarefaDto.IdAnalista
            };
        }

        public static SubTarefa DtoDaAtualizacaoDaSubTarefa(this AtualizarSubTarefaDto SubTarefaDto)
        {
            return new SubTarefa
            {
                Descricao = SubTarefaDto.Descricao,
                DataFim = SubTarefaDto.DataFim,
                // ApontamentoId = SubTarefaDto.IdApontamento,
                AnalistaId = SubTarefaDto.IdAnalista,
            };
        }

        public static SubTarefa DtoDaDelecaoDaSubTarefa(this DeletarSubTarefaDto SubTarefaDto)
        {
            return new SubTarefa
            {
                SubTarefaId = SubTarefaDto.SubTarefaId,
                TarefaId = SubTarefaDto.IdTarefa
            };
        }
    }
}