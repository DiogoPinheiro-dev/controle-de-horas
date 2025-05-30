using server.Dtos.Projeto;
using server.Models;

namespace server.Mappers
{
    public static class ProjetoMapper
    {
        public static Projeto DtoDaCriacaoDoProjeto(this CriarProjetoDto ProjetoDto)
        {
            return new Projeto
            {
                Descricao = ProjetoDto.Descricao,
                Nome = ProjetoDto.Nome,
                DataInicio = ProjetoDto.DataIni,
                ClienteId = ProjetoDto.IdCliente,
                GerenteId = ProjetoDto.IdGerente
                // TarefaId = ProjetoDto.IdTarefa
            };
        }

        public static Projeto DtoDaDelecaoDoProjeto(this DeletarProjetoDto ProjetoDto)
        {
            return new Projeto
            {
                ProjetoId = ProjetoDto.ProjetoId,
                GerenteId = ProjetoDto.IdGerente
            };
        }

        public static Projeto DtoDaAtualizacaoDoProjeto(this AtualizarProjetoDto ProjetoDto)
        {
            return new Projeto
            {
                Descricao = ProjetoDto.Descricao,
                Nome = ProjetoDto.Nome,
                DataFim = ProjetoDto.DataFim
            };
        }
    }
}