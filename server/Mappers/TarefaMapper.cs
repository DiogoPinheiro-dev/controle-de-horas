using server.Dtos.Tarefa;
using server.Models;

namespace server.Mappers
{
    public static class TarefaMapper
    {
        public static TarefaDto DtoDaTarefa(this Tarefa tarefa)
        {
            return new TarefaDto
            {
                TarefaId = tarefa.TarefaId,
                Descricao = tarefa.Descricao,
                DataInicio = tarefa.DataInicio,
                DataFim = tarefa.DataFim,
                CoordenadorId = tarefa.RecursoId,
                ProjetoId = tarefa.ProjetoId
            };
        }
        
        public static Tarefa DtoDaCriacaoDoTarefa(this CriarTarefaDto TarefaDto)
        {
            return new Tarefa
            {
                Descricao = TarefaDto.Descricao,
                DataInicio = TarefaDto.DataInicio,
                ProjetoId = TarefaDto.ProjetoId,
                RecursoId = TarefaDto.CoordenadorId
            };
        }

        public static Tarefa DtoDaDelecaoDoTarefa(this DeletarTarefaDto TarefaDto)
        {
            return new Tarefa
            {
                TarefaId = TarefaDto.TarefaId,
                ProjetoId = TarefaDto.ProjetoId
            };
        }

        public static Tarefa DtoDaAtualizacaoDoTarefa(this AtualizarTarefaDto TarefaDto)
        {
            return new Tarefa
            {
                Descricao = TarefaDto.Descricao,
                DataInicio = TarefaDto.DataInicio,
                DataFim = TarefaDto.DataFim,
                RecursoId = TarefaDto.CoordenadorId,
                ProjetoId = TarefaDto.ProjetoId
            };
        }
    }
}