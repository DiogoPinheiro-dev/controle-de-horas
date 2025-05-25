using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using server.Dto;
using server.Interfaces;
using server.Mappers;
using server.Models;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService service;

        public ClienteController(IClienteService service)
        {
            this.service = service;
        }

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

                return Ok(Cliente);
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

                return Ok(Cliente);
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

                return Ok(Cliente);
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

                return Ok(Clientes);
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

                return Ok(Cliente);
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

                return Ok(Clientes);
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

                return Ok(Clientes);
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

                if (tel == null)
                {
                    return BadRequest();
                }

                tel = tel.Replace(" ", "");
                tel = tel.Replace("-", "");

                if (tel.Contains("("))
                {
                    string[] parts;

                    string ddd, operadora_e_numero;
                    parts = tel.Split(")");

                    ddd = parts[0].Substring(1, 2).Trim();
                    operadora_e_numero = parts[1].Trim();

                    if (operadora_e_numero.Contains(" "))
                    {
                        operadora_e_numero = operadora_e_numero.Replace(" ", "");
                    }

                    tel = ddd + operadora_e_numero;
                }

                var recursos = await service.ObterClientePorTelefone(tel.Trim());

                if (recursos == null)
                {
                    return NotFound();
                }

                return Ok(recursos);
            }
            catch
            {
                throw;
            }
        }

        
        
    }
}