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

        [HttpPost]
        public async Task<ActionResult> RelacionarEmpresaServico([FromBody] EmpresaServico body)
        {
            try
            {
                if (body == null)
                {
                    return NoContent();
                }

                var res = await service.RelacionarEmpresaServico(body);

                return Ok(res);
            }
            catch
            {
                throw;
            }
        }

        [HttpPatch]
        [Route("ById/{servicoId}/{empresaId}")]
        public async Task<ActionResult> AtualizarRelacaoPorId([FromRoute] int servicoId, [FromRoute] int empresaId, [FromBody] EmpresaServico body)
        {
            try
            {
                if (servicoId <= 0)
                {
                    return NoContent();
                }

                EmpresaServico atual = await service.ObterRelacaoPorId(servicoId, empresaId);

                if (atual == null)
                {
                    return NotFound();
                }

                if (body == null)
                {
                    return NoContent();
                }

                var res = await service.AlterarRelacaoEmpresaServico(atual, body);

                return Ok(res);
            }
            catch
            {
                throw;
            }
        }

        [HttpDelete]
        public async Task<ActionResult> DeletarRelacaoEmpresaServico([FromBody] EmpresaServico body)
        {
            try
            {
                if (body == null)
                {
                    return NoContent();
                }

                var res = await service.DeletarRelacaoEmpresaServico(body);

                return Ok(res);
            }
            catch
            {
                throw;
            }
        }

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