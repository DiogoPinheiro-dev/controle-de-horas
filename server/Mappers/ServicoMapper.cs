using server.Dtos.Servico;
using server.Models;

namespace server.Mappers
{
    public static class ServicoMapper
    {
        public static ServicoDto DtoDoServico(this Servico servico)
        {
            return new ServicoDto
            {
                Custo = servico.Custo,
                Descricao = servico.Descricao,
                IdEmpresa = servico.IdEmpresa
            };
        }
        
        public static Servico DtoDaCriacaoDoServico(this CriarServicoDto ServicoDto)
        {
            return new Servico
            {
                Descricao = ServicoDto.Descricao,
                Custo = ServicoDto.Custo,
                IdEmpresa = ServicoDto.IdEmpresa
            };
        }

        public static Servico DtoDaDelecaoDoServico(this DeletarServicoDto ServicoDto)
        {
            return new Servico
            {
                ServicoId = ServicoDto.ServicoId,
                IdEmpresa = ServicoDto.IdEmpresa
            };
        }

        public static Servico DtoDaAtualizacaoDoServico(this AtualizarServicoDto ServicoDto)
        {
            return new Servico
            {
                Descricao = ServicoDto.Descricao,
                Custo = ServicoDto.Custo
            };
        }
    }
}