using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Db;
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
        public async Task<ActionResult> CriarRecurso([FromBody] AtualizarECriarRecursoDto recursoDto)
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

        [HttpPut]
        public async Task<ActionResult> AtualizarRecurso([FromBody] AtualizarECriarRecursoDto recursoDto)
        {
            try
            {
                if (recursoDto == null)
                {
                    return NoContent();
                }

                var modeloDeRecurso = recursoDto.DtoDaAtualizacaoDoRecurso();

                if (modeloDeRecurso == null)
                {
                    return StatusCode(500);
                }

                await service.AtualizarRecurso(modeloDeRecurso);

                return Ok(modeloDeRecurso);

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
        public async Task<ActionResult<Recurso>> RecursoPorId(Guid id)
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