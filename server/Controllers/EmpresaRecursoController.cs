using Microsoft.AspNetCore.Mvc;
using server.Interfaces;
using server.Models;

namespace server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpresaRecursoController(IEmpresaRecursoService service) : ControllerBase
    {
        private readonly IEmpresaRecursoService service = service;

        [HttpPost]
        public async Task<ActionResult> RelacionarEmpresaRecurso([FromBody] EmpresaRecurso body)
        {
            try
            {
                if (body == null)
                {
                    return NoContent();
                }

                await service.RelacionarEmpresaRecurso(body);

                return Ok();
            }
            catch
            {
                throw;
            }
        }

        [HttpPatch]
        [Route("ById/{recursoId}/{empresaId}")]
        public async Task<ActionResult> AtualizarRelacaoPorId([FromRoute] int recursoId, [FromRoute] int empresaId, [FromBody] EmpresaRecurso body)
        {
            try
            {
                if (recursoId <= 0)
                {
                    return NoContent();
                }

                EmpresaRecurso atual = await service.ObterRelacaoPorId(recursoId, empresaId);

                if (atual == null)
                {
                    return NotFound();
                }

                if (body == null)
                {
                    return NoContent();
                }

                await service.AlterarRelacaoEmpresaRecurso(atual, body);

                return Ok(body);
            }
            catch
            {
                throw;
            }
        }

        [HttpDelete]
        public async Task<ActionResult> DeletarRelacaoEmpresaRecurso([FromBody] EmpresaRecurso body)
        {
            try
            {
                if (body == null)
                {
                    return NoContent();
                }

                await service.DeletarRelacaoEmpresaRecurso(body);

                return Ok(body);
            }
            catch
            {
                throw;
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<EmpresaRecurso>>> ObterTodasAsRelacoesEmpresaRecurso()
        {
            try
            {
                List<EmpresaRecurso> empresaRecursos;

                empresaRecursos = await service.ObterTodasRelacoes();

                return Ok(empresaRecursos);
            }
            catch
            {
                throw;
            }
        }

        [HttpGet]
        [Route("ByEmpresaId/{empresaId}")]
        public async Task<ActionResult<List<EmpresaRecurso>>> ObterRelacoesPorIdDaEmpresa([FromRoute] int empresaId)
        {
            try
            {
                if (empresaId <= 0)
                {
                    return NoContent();
                }

                List<EmpresaRecurso> empresaRecursos;

                empresaRecursos = await service.ObterRelacoesPorIdDaEmpresa(empresaId);

                return Ok(empresaRecursos);
            }
            catch
            {
                throw;
            }
        }

        [HttpGet]
        [Route("ByRecursoId/{recursoId}")]
        public async Task<ActionResult<List<EmpresaRecurso>>> ObterRelacoesPorIdDoRecurso([FromRoute] int recursoId)
        {
            try
            {
                if (recursoId <= 0)
                {
                    return NoContent();
                }

                List<EmpresaRecurso> empresaRecursos;

                empresaRecursos = await service.ObterRelacoesPorIdDoRecurso(recursoId);

                return Ok(empresaRecursos);
            }
            catch
            {
                throw;
            }

        }
    }
}