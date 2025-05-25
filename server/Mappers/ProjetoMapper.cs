using server.Dto;
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
                DataIni = ProjetoDto.DataIni
            };
        }

        public static Projeto DtoDaDelecaoDoProjeto(this DeletarProjetoDto ProjetoDto)
        {
            return new Projeto
            {
                ProjetoId = ProjetoDto.ProjetoId

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