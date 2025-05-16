using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using server.Dto;
using server.Mappers;
using server.Models;
using server.Services;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecursoController : ControllerBase
    {
        private readonly IRecursoService service;

        public RecursoController(IRecursoService service)
        {
            this.service = service;

        }

        [HttpPost]
        public async Task<ActionResult> CriarRecurso([FromBody] CriarRecursoDto recursoDto)
        {
            try
            {
                if (recursoDto == null)
                {
                    return NoContent();
                }

                var modeloDeRecurso = recursoDto.DtoDaCriacaoDoRecurso();

                if (modeloDeRecurso == null)
                {
                    return StatusCode(500);
                }

                await service.CriarRecurso(modeloDeRecurso);

                return Ok(modeloDeRecurso);

            }
            catch
            {
                throw;
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeletarRecurso([FromBody] DeletarRecursoDto recursoDto)
        {
            try
            {
                if (recursoDto == null)
                {
                    return NoContent();
                }

                var modeloDeRecurso = recursoDto.DtoDaDelecaoDoRecurso();

                if (modeloDeRecurso == null)
                {
                    return StatusCode(500);
                }

                await service.DeletarRecurso(modeloDeRecurso);

                return Ok(modeloDeRecurso);

            }
            catch
            {
                throw;
            }
        }

        [HttpPatch]
        [Route("{id}")]
        public async Task<ActionResult> AtualizarRecurso([FromRoute] int id, [FromBody] AtualizarRecursoDto recursoDto)
        {
            try
            {
                var recurso = await service.ObterRecursoPorId(id);

                if (recurso == null)
                {
                    return NotFound();
                }

                var modeloDeRecurso = recursoDto.DtoDaAtualizacaoDoRecurso();

                if (!TryValidateModel(modeloDeRecurso))
                {
                    return BadRequest(ModelState);
                }

                await service.AtualizarRecurso(recurso, modeloDeRecurso);

                return Ok(recurso);
            }
            catch
            {
                throw;
            }

        }

        [HttpGet]
        public async Task<ActionResult<List<Recurso>>> TodosRecursos()
        {
            try
            {
                var recursos = await service.ObterTodosRecursos();

                return Ok(recursos);

            }
            catch
            {

                throw;
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Recurso>> RecursoPorId(int id)
        {
            try
            {
                var recurso = await service.ObterRecursoPorId(id);

                return Ok(recurso);
            }
            catch
            {
                throw;

            }
        }
    }
}