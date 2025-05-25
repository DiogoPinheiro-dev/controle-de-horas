using server.Dtos.Cliente;
using server.Models;

namespace server.Mappers
{
    public static class ClienteMapper
    {
        public static Cliente DtoDaCriacaoDoCliente(this CriarClienteDto ClienteDto)
        {
            return new Cliente
            {
                Email = ClienteDto.Email,
                Nome = ClienteDto.Nome,
                Telefone = ClienteDto.Telefone
            };
        }

        public static Cliente DtoDaDelecaoDoCliente(this DeletarClienteDto ClienteDto)
        {
            return new Cliente
            {
                ClienteId = ClienteDto.ClienteId,
                Email = ""
            };
        }

        public static Cliente DtoDaAtualizacaoDoCliente(this AtualizarClienteDto ClienteDto)
        {
            return new Cliente
            {
                Email = "",
                Nome = ClienteDto.Nome,
                Telefone = ClienteDto.Telefone,
            };
        }
    }
}