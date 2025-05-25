using server.Dtos.Tarefa;
using server.Models;

namespace server.Mappers
{
    public static class TarefaMapper
    {
        public static Tarefa DtoDaCriacaoDoTarefa(this CriarTarefaDto TarefaDto)
        {
            return new Tarefa
            {
                Descricao = TarefaDto.Descricao,
                DataInicio = TarefaDto.DataInicio,
                IdProjeto = TarefaDto.IdProjeto,
                IdCoordenador = TarefaDto.IdCoordenador,
            };
        }

        public static Tarefa DtoDaDelecaoDoTarefa(this DeletarTarefaDto TarefaDto)
        {
            return new Tarefa
            {
                TarefaId = TarefaDto.TarefaId
            };
        }

        public static Tarefa DtoDaAtualizacaoDoTarefa(this AtualizarTarefaDto TarefaDto)
        {
            return new Tarefa
            {
                Descricao = TarefaDto.Descricao,
                DataInicio = TarefaDto.DataInicio,
                DataFim = TarefaDto.DataFim
            };
        }
    }
}