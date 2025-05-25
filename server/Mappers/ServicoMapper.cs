using server.Dto;
using server.Models;

namespace server.Mappers
{
    public static class ServicoMapper
    {
        public static Servico DtoDaCriacaoDoServico(this CriarServicoDto ServicoDto)
        {
            return new Servico
            {
                ServicoId = 0,
                Descricao = ServicoDto.Descricao,
                Custo = ServicoDto.Custo,
            };
        }

        public static Servico DtoDaDelecaoDoServico(this DeletarServicoDto ServicoDto)
        {
            return new Servico
            {
                ServicoId = ServicoDto.ServicoId,
            };
        }

        public static Servico DtoDaAtualizacaoDoServico(this AtualizarServicoDto ServicoDto)
        {
            return new Servico
            {
                ServicoId = 0,
                Descricao = ServicoDto.Descricao,
                Custo = ServicoDto.Custo
            };
        }
    }
}