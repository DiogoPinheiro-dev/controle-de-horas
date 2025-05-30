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
                ProjetoId = TarefaDto.IdProjeto,
                CoordenadorId = TarefaDto.IdCoordenador
            };
        }

        public static Tarefa DtoDaDelecaoDoTarefa(this DeletarTarefaDto TarefaDto)
        {
            return new Tarefa
            {
                TarefaId = TarefaDto.TarefaId,
                ProjetoId = TarefaDto.IdProjeto
            };
        }

        public static Tarefa DtoDaAtualizacaoDoTarefa(this AtualizarTarefaDto TarefaDto)
        {
            return new Tarefa
            {
                Descricao = TarefaDto.Descricao,
                DataFim = TarefaDto.DataFim,
                // SubTarefaId = TarefaDto.IdSubTarefa
            };
        }
    }
}