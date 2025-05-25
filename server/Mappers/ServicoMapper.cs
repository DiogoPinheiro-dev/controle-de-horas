using server.Dtos.Servico;
using server.Models;

namespace server.Mappers
{
    public static class ServicoMapper
    {
        public static Servico DtoDaCriacaoDoServico(this CriarServicoDto ServicoDto)
        {
            return new Servico
            {
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
                Descricao = ServicoDto.Descricao,
                Custo = ServicoDto.Custo
            };
        }
    }
}