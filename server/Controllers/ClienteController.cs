using Microsoft.AspNetCore.Mvc;
using server.Dtos.Cliente;
using server.Interfaces;
using server.Mappers;
using server.Models;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController(IClienteService service) : ControllerBase
    {
        private readonly IClienteService service = service;

        [HttpPost]
        public async Task<ActionResult> CriarCliente([FromBody] CriarClienteDto ClienteDto)
        {
            try
            {
                if (ClienteDto == null)
                {
                    return NoContent();
                }

                var Cliente = ClienteDto.DtoDaCriacaoDoCliente();

                if (Cliente == null)
                {
                    return BadRequest();
                }

                await service.CriarCliente(Cliente);

                return Ok(Cliente.DtoDoCliente());
            }
            catch
            {
                throw;
            }
        }

        [HttpPatch]
        [Route("{id}")]
        public async Task<ActionResult> AlterarCliente([FromRoute] int id, [FromBody] AtualizarClienteDto ClienteDto)
        {
            try
            {
                if (id <= 0)
                {
                    return NoContent();
                }

                var Cliente = await service.ObterClientePorId(id);

                if (Cliente == null)
                {
                    return NotFound();
                }

                if (ClienteDto == null)
                {
                    return NoContent();
                }

                var ClienteBody = ClienteDto.DtoDaAtualizacaoDoCliente();

                if (ClienteBody == null)
                {
                    return BadRequest();
                }

                await service.AtualizarCliente(Cliente, ClienteBody);

                return Ok(Cliente.DtoDoCliente());
            }
            catch
            {
                throw;
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeletarCliente([FromRoute] int id)
        {
            try
            {
                if (id <= 0)
                {
                    return NoContent();
                }

                var Cliente = await service.ObterClientePorId(id);

                if (Cliente == null)
                {
                    return NotFound();
                }
                await service.DeletarCliente(Cliente);

                return Ok(Cliente.DtoDoCliente());
            }
            catch
            {
                throw;
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<Cliente>>> ObterTodosClientes()
        {
            try
            {
                List<Cliente> Clientes = await service.ObterTodosClientes();
                List<ClienteDto> ClientesDto = [];

                foreach (var Cliente in Clientes)
                    ClientesDto.Add(Cliente.DtoDoCliente());

                return Ok(ClientesDto);
            }
            catch
            {
                throw;
            }
        }

        [HttpGet]
        [Route("ById/{id}")]
        public async Task<ActionResult<Cliente>> ObterClientePorId([FromRoute] int id)
        {
            try
            {
                if (id <= 0)
                {
                    return NoContent();
                }

                var Cliente = await service.ObterClientePorId(id);

                if (Cliente == null)
                {
                    return NotFound();
                }

                return Ok(Cliente.DtoDoCliente());
            }
            catch
            {
                throw;
            }
        }

        [HttpGet]
        [Route("ByName/{nome}")]
        public async Task<ActionResult<List<Cliente>>> ObterClientePorNome([FromRoute] string nome)
        {
            try
            {
                List<Cliente> Clientes;
                List<ClienteDto> ClientesDto = [];

                if (nome == string.Empty)
                {
                    Clientes = await service.ObterTodosClientes();

                    if (Clientes == null)
                    {
                        return BadRequest();
                    }
                }
                else
                {
                    Clientes = await service.ObterClientePorNome(nome.Trim());

                    if (Clientes == null)
                    {
                        return NotFound();
                    }
                }

                foreach (var Cliente in Clientes)
                    ClientesDto.Add(Cliente.DtoDoCliente());

                return Ok(ClientesDto);
            }
            catch
            {
                throw;
            }
        }

        [HttpGet]
        [Route("ByEmail/{email}")]
        public async Task<ActionResult<List<Cliente>>> ObterClientePorEmail([FromRoute] string email)
        {
            try
            {
                List<Cliente> Clientes;
                List<ClienteDto> ClientesDto = [];

                if (email == string.Empty)
                {
                    Clientes = await service.ObterTodosClientes();

                    if (Clientes == null)
                    {
                        return BadRequest();
                    }
                }
                else
                {
                    Clientes = await service.ObterClientePorEmail(email.Trim());

                    if (Clientes == null)
                    {
                        return NotFound();
                    }
                }

                foreach (var Cliente in Clientes)
                    ClientesDto.Add(Cliente.DtoDoCliente());

                return Ok(ClientesDto);
            }
            catch
            {
                throw;
            }
        }

        [HttpGet]
        [Route("ByTelefone/{tel}")]
        public async Task<ActionResult<List<Cliente>>> ObterClientePorTelefone([FromRoute] string tel)
        {
            try
            {
                List<ClienteDto> ClienteDtos = [];

                if (tel == null)
                {
                    return BadRequest();
                }

                tel = tel.Replace(" ", "");
                tel = tel.Replace("-", "");

                if (tel.Contains('('))
                {
                    string[] parts;

                    string ddd, operadora_e_numero;
                    parts = tel.Split(')');

                    ddd = parts[0].Substring(1, 2).Trim();
                    operadora_e_numero = parts[1].Trim();

                    if (operadora_e_numero.Contains(' '))
                    {
                        operadora_e_numero = operadora_e_numero.Replace(" ", "");
                    }

                    tel = ddd + operadora_e_numero;
                }

                var clientes = await service.ObterClientePorTelefone(tel.Trim());

                if (clientes == null)
                {
                    return NotFound();
                }

                foreach (var cliente in clientes)
                    ClienteDtos.Add(cliente.DtoDoCliente());

                return Ok(ClienteDtos);
            }
            catch
            {
                throw;
            }
        }
    }
}