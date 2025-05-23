using Microsoft.AspNetCore.Mvc;
using server.Dto;
using server.Interfaces;
using server.Mappers;
using server.Models;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApontamentoController : ControllerBase
    {
        private readonly IApontamentoService service;

        public ApontamentoController(IApontamentoService service)
        {
            this.service = service;
        }

        [HttpPost]
        public async Task<ActionResult> CriarApontamento([FromBody] CriarApontamentoDto apontamentoDto)
        {
            try
            {
                if (apontamentoDto == null)
                {
                    return NoContent();
                }

                var apontamento = apontamentoDto.DtoDaCriacaoDoApontamento();

                if (apontamento == null)
                {
                    return BadRequest();
                }

                await service.CriarApontamento(apontamento);

                return Ok(apontamento);
            }
            catch
            {
                throw;
            }
        }

        [HttpPatch]
        [Route("{id}")]
        public async Task<ActionResult> AlterarApontamento([FromRoute] int id, [FromBody] AtualizarApontamentoDto apontamentoDto)
        {
            try
            {
                if (id <= 0)
                {
                    return NoContent();
                }

                var apontamento = await ObterApontamentoPorId(id);

                if (apontamento.Value == null)
                {
                    return NotFound();
                }

                if (apontamentoDto == null)
                    {
                        return NoContent();
                    }

                var apontamentoBody = apontamentoDto.DtoDaAtualizacaoDoApontamento();

                if (apontamentoBody == null)
                {
                    return BadRequest();
                }

                await service.AtualizarApontamento(apontamento.Value, apontamentoBody);

                return Ok(apontamento);
            }
            catch
            {
                throw;
            }

        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Apontamento>> ObterApontamentoPorId([FromRoute] int id)
        {
            try
            {
                var apontamento = await service.ObterApontamentoPorId(id);

                return Ok(apontamento);
            }
            catch
            {
                throw;
            }
        }

    }
}