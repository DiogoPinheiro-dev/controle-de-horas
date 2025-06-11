using server.Dtos.SubTarefa;
using server.Models;

namespace server.Mappers
{
    public static class SubTarefaMapper
    {
        public static SubTarefaDto DtoDaSubTarefa(this SubTarefa subTarefa)
        {
            return new SubTarefaDto
            {
                SubTarefaId = subTarefa.SubTarefaId,
                Descricao = subTarefa.Descricao,
                DataInicio = subTarefa.DataInicio,
                DataFim = subTarefa.DataFim,
                TarefaId = subTarefa.TarefaId,
                AnalistaId = subTarefa.RecursoId
            };
        }

        public static SubTarefa DtoDaCriacaoDaSubTarefa(this CriarSubTarefaDto SubTarefaDto)
        {
            return new SubTarefa
            {
                Descricao = SubTarefaDto.Descricao,
                DataInicio = SubTarefaDto.DataInicio,
                TarefaId = SubTarefaDto.IdTarefa,
                RecursoId = SubTarefaDto.IdAnalista
            };
        }

        public static SubTarefa DtoDaAtualizacaoDaSubTarefa(this AtualizarSubTarefaDto SubTarefaDto)
        {
            return new SubTarefa
            {
                Descricao = SubTarefaDto.Descricao,
                DataFim = SubTarefaDto.DataFim,
                RecursoId = SubTarefaDto.IdAnalista
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