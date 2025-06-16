using server.Dtos.Cliente;
using server.Models;

namespace server.Mappers
{
    public static class ClienteMapper
    {
        public static ClienteDto DtoDoCliente(this Cliente cliente)
        {
            return new ClienteDto
            {
                Email = cliente.Email,
                Nome = cliente.Nome,
                Telefone = cliente.Telefone,
                EmpresaId = cliente.IdEmpresa,
                UsuarioId = cliente.IdUsuario,
                ClienteId = cliente.ClienteId
            };
        }

        public static Cliente DtoDaCriacaoDoCliente(this CriarClienteDto ClienteDto)
        {
            return new Cliente
            {
                Email = ClienteDto.Email,
                Nome = ClienteDto.Nome,
                Telefone = ClienteDto.Telefone,
                IdEmpresa = ClienteDto.EmpresaId
            };
        }

        public static Cliente DtoDaDelecaoDoCliente(this DeletarClienteDto ClienteDto)
        {
            return new Cliente
            {
                ClienteId = ClienteDto.ClienteId,
                IdEmpresa = ClienteDto.EmpresaId,
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
                IdEmpresa = ClienteDto.EmpresaId,
                IdUsuario = ClienteDto.UsuarioId
            };
        }
    }
}