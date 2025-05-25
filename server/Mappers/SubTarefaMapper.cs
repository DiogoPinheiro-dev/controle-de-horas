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
                IdTarefa = SubTarefaDto.IdTarefa,
                IdAnalista = SubTarefaDto.IdAnalista,
            };
        }

        public static SubTarefa DtoDaAtualizacaoDaSubTarefa(this AtualizarSubTarefaDto SubTarefaDto)
        {
            return new SubTarefa
            {
                Descricao = SubTarefaDto.Descricao,
                DataFim = SubTarefaDto.DataFim,
                IdAnalista = SubTarefaDto.IdAnalista,
            };
        }

        public static SubTarefa DtoDaDelecaoDaSubTarefa(this DeletarSubTarefaDto SubTarefaDto)
        {
            return new SubTarefa
            {
                SubTarefaId = SubTarefaDto.SubTarefaId,
                IdTarefa = SubTarefaDto.IdTarefa
            };
        }
    }
}