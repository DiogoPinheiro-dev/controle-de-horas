using Microsoft.AspNetCore.Mvc;
using server.Interfaces;
using server.Models;

namespace server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpresaClienteController(IEmpresaClienteService service) : ControllerBase
    {
        private readonly IEmpresaClienteService service = service;

        [HttpGet]
        public async Task<ActionResult<List<EmpresaCliente>>> ObterTodasAsRelacoesEmpresaCliente()
        {
            try
            {
                List<EmpresaCliente> EmpresaClientes;

                EmpresaClientes = await service.ObterTodasRelacoes();

                return Ok(EmpresaClientes);
            }
            catch
            {
                throw;
            }
        }

        [HttpGet]
        [Route("ByEmpresaId/{empresaId}")]
        public async Task<ActionResult<List<EmpresaCliente>>> ObterRelacoesPorIdDaEmpresa([FromRoute] int empresaId)
        {
            try
            {
                if (empresaId <= 0)
                {
                    return NoContent();
                }

                List<EmpresaCliente> EmpresaClientes;

                EmpresaClientes = await service.ObterRelacoesPorIdDaEmpresa(empresaId);

                return Ok(EmpresaClientes);
            }
            catch
            {
                throw;
            }
        }

        [HttpGet]
        [Route("ByclienteId/{clienteId}")]
        public async Task<ActionResult<List<EmpresaCliente>>> ObterRelacoesPorIdDoCliente([FromRoute] int clienteId)
        {
            try
            {
                if (clienteId <= 0)
                {
                    return NoContent();
                }

                List<EmpresaCliente> EmpresaClientes;

                EmpresaClientes = await service.ObterRelacoesPorIdDoCliente(clienteId);

                return Ok(EmpresaClientes);
            }
            catch
            {
                throw;
            }

        }
    }
}