using Microsoft.AspNetCore.Mvc;
using server.Dtos.Apontamento;
using server.Interfaces;
using server.Mappers;
using server.Models;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApontamentoController(IApontamentoService service) : ControllerBase
    {
        private readonly IApontamentoService service = service;

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

                return Ok(apontamento.DtoDoApontamento());
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

                var apontamento = await service.ObterApontamentoPorId(id);

                if (apontamento == null)
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

                var res = await service.AtualizarApontamento(apontamento, apontamentoBody);

                return Ok(res.DtoDoApontamento());
            }
            catch
            {
                throw;
            }

        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeletarApontamento([FromRoute] int id)
        {
            try
            {
                if (id <= 0)
                {
                    return NoContent();
                }

                var apontamento = await service.ObterApontamentoPorId(id);

                if (apontamento == null)
                {
                    return NotFound();
                }
                var res = await service.DeletarApontamento(apontamento);

                return Ok(res.DtoDoApontamento());
            }
            catch
            {
                throw;
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<ApontamentoDto>>> ObterTodosApontamentos()
        {
            try
            {
                List<Apontamento> apontamentos = await service.ObterTodosApontamentos();
                List<ApontamentoDto> apontamentosDtos = [];

                foreach (var apontamento in apontamentos)
                    apontamentosDtos.Add(apontamento.DtoDoApontamento());


                return Ok(apontamentosDtos);
            }
            catch
            {
                throw;
            }
        }

        [HttpGet]
        [Route("ById/{id}")]
        public async Task<ActionResult<Apontamento>> ObterApontamentoPorId([FromRoute] int id)
        {
            try
            {

                if (id <= 0)
                {
                    return NoContent();
                }

                var apontamento = await service.ObterApontamentoPorId(id);

                if (apontamento == null)
                {
                    return NotFound();
                }

                return Ok(apontamento.DtoDoApontamento());
            }
            catch
            {
                throw;
            }
        }

        [HttpGet]
        [Route("ByOs/{os}")]
        public async Task<ActionResult<List<Apontamento>>> ObterApontamentoPorOs([FromRoute] string os)
        {
            try
            {
                List<Apontamento> apontamentos;
                List<ApontamentoDto> apontamentoDtos = [];

                if (os == string.Empty)
                {
                    apontamentos = await service.ObterTodosApontamentos();

                    if (apontamentos == null)
                    {
                        return BadRequest();
                    }
                }
                else
                {
                    apontamentos = await service.ObterApontamentoPorOS(os.Trim());

                    if (apontamentos == null)
                    {
                        return NotFound();
                    }
                }

                foreach (var apontamento in apontamentos)
                    apontamentoDtos.Add(apontamento.DtoDoApontamento());

                return Ok(apontamentoDtos);
            }
            catch
            {
                throw;
            }
        }

        [HttpGet]
        [Route("ByData/{dataIni}/{dataFim}")]
        public async Task<ActionResult<List<Apontamento>>> ObterApontamentoDeAte([FromRoute] int dataIni, [FromRoute] int dataFim)
        {
            try
            {
                List<Apontamento> apontamentos;
                List<ApontamentoDto> apontamentoDtos = [];

                if (dataIni <= dataFim)
                {
                    apontamentos = await service.ObterApontamentosPorData(dataIni, dataFim);
                }
                else
                {
                    apontamentos = await service.ObterTodosApontamentos();
                }

                if (apontamentos == null)
                {
                    return NotFound();
                }

                foreach (var apontamento in apontamentos)
                    apontamentoDtos.Add(apontamento.DtoDoApontamento());

                return Ok(apontamentos);
            }
            catch
            {
                throw;
            }
        }
    }
}