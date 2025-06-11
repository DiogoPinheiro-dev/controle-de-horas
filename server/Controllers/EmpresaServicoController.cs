using Microsoft.AspNetCore.Mvc;
using server.Interfaces;
using server.Models;

namespace server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpresaServicoController(IEmpresaServicoService service) : ControllerBase
    {
        private readonly IEmpresaServicoService service = service;

        [HttpGet]
        public async Task<ActionResult<List<EmpresaServico>>> ObterTodasAsRelacoesEmpresaServico()
        {
            try
            {
                List<EmpresaServico> EmpresaServicos;

                EmpresaServicos = await service.ObterTodasRelacoes();

                return Ok(EmpresaServicos);
            }
            catch
            {
                throw;
            }
        }

        [HttpGet]
        [Route("ByEmpresaId/{empresaId}")]
        public async Task<ActionResult<List<EmpresaServico>>> ObterRelacoesPorIdDaEmpresa([FromRoute] int empresaId)
        {
            try
            {
                if (empresaId <= 0)
                {
                    return NoContent();
                }

                List<EmpresaServico> EmpresaServicos;

                EmpresaServicos = await service.ObterRelacoesPorIdDaEmpresa(empresaId);

                return Ok(EmpresaServicos);
            }
            catch
            {
                throw;
            }
        }

        [HttpGet]
        [Route("ByservicoId/{servicoId}")]
        public async Task<ActionResult<List<EmpresaServico>>> ObterRelacoesPorIdDoServico([FromRoute] int servicoId)
        {
            try
            {
                if (servicoId <= 0)
                {
                    return NoContent();
                }

                List<EmpresaServico> EmpresaServicos;

                EmpresaServicos = await service.ObterRelacoesPorIdDoServico(servicoId);

                return Ok(EmpresaServicos);
            }
            catch
            {
                throw;
            }
        }
    }
}