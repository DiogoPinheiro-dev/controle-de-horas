using server.Dtos.Projeto;
using server.Models;

namespace server.Mappers
{
    public static class ProjetoMapper
    {
        public static ProjetoDto DtoDoProjeto(this Projeto projeto)
        {
            return new ProjetoDto
            {
                ProjetoId = projeto.ProjetoId,
                Descricao = projeto.Descricao,
                Nome = projeto.Nome,
                DataInicio = projeto.DataInicio,
                DataFim = projeto.DataFim,
                RecursoId = projeto.RecursoId,
                EmpresaId = projeto.EmpresaId,
                ClienteId = projeto.ClienteId
            };
        }
        public static Projeto DtoDaCriacaoDoProjeto(this CriarProjetoDto ProjetoDto)
        {
            return new Projeto
            {
                Descricao = ProjetoDto.Descricao,
                Nome = ProjetoDto.Nome,
                DataInicio = ProjetoDto.DataInicio,
                ClienteId = ProjetoDto.ClienteId,
                RecursoId = ProjetoDto.GerenteId,
                EmpresaId = ProjetoDto.EmpresaId
            };
        }

        public static Projeto DtoDaDelecaoDoProjeto(this DeletarProjetoDto ProjetoDto)
        {
            return new Projeto
            {
                ProjetoId = ProjetoDto.ProjetoId,
                RecursoId = ProjetoDto.GerenteId
            };
        }

        public static Projeto DtoDaAtualizacaoDoProjeto(this AtualizarProjetoDto ProjetoDto)
        {
            return new Projeto
            {
                Descricao = ProjetoDto.Descricao,
                Nome = ProjetoDto.Nome,
                DataFim = ProjetoDto.DataFim,
                EmpresaId = ProjetoDto.EmpresaId
            };
        }
    }
}