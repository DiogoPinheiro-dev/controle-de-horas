using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using server.Dtos.Servico;
using server.Interfaces;
using server.Mappers;
using server.Models;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicoController : ControllerBase
    {
        private readonly IServicoService service;

        public ServicoController(IServicoService service)
        {
            this.service = service;
        }

        [HttpPost]
        public async Task<ActionResult> CriarServico([FromBody] CriarServicoDto ServicoDto)
        {
            try
            {
                if (ServicoDto == null)
                {
                    return NoContent();
                }

                var Servico = ServicoDto.DtoDaCriacaoDoServico();

                if (Servico == null)
                {
                    return BadRequest();
                }

                await service.CriarServico(Servico);

                return Ok(Servico);
            }
            catch
            {
                throw;
            }
        }

        [HttpPatch]
        [Route("{id}")]
        public async Task<ActionResult> AlterarServico([FromRoute] int id, [FromBody] AtualizarServicoDto ServicoDto)
        {
            try
            {
                if (id <= 0)
                {
                    return NoContent();
                }

                var Servico = await service.ObterServicoPorId(id);

                if (Servico == null)
                {
                    return NotFound();
                }

                if (ServicoDto == null)
                {
                    return NoContent();
                }

                var ServicoBody = ServicoDto.DtoDaAtualizacaoDoServico();

                if (ServicoBody == null)
                {
                    return BadRequest();
                }

                await service.AtualizarServico(Servico, ServicoBody);

                return Ok(Servico);
            }
            catch
            {
                throw;
            }

        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeletarServico([FromRoute] int id)
        {
            try
            {
                if (id <= 0)
                {
                    return NoContent();
                }

                var Servico = await service.ObterServicoPorId(id);

                if (Servico == null)
                {
                    return NotFound();
                }
                await service.DeletarServico(Servico);

                return Ok(Servico);
            }
            catch
            {
                throw;
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<Servico>>> ObterTodosServicos()
        {
            try
            {
                List<Servico> Servicos = await service.ObterTodosServicos();

                return Ok(Servicos);
            }
            catch
            {
                throw;
            }
        }

        [HttpGet]
        [Route("ById/{id}")]
        public async Task<ActionResult<Servico>> ObterServicoPorId([FromRoute] int id)
        {
            try
            {
                if (id <= 0)
                {
                    return NoContent();
                }

                var Servico = await service.ObterServicoPorId(id);

                if (Servico == null)
                {
                    return NotFound();
                }

                return Ok(Servico);
            }
            catch
            {
                throw;
            }
        }

        [HttpGet]
        [Route("ByDescricao/{descricao}")]
        public async Task<ActionResult<List<Servico>>> ObterServicoPorNome([FromRoute] string descricao)
        {
            try
            {
                List<Servico> Servicos;

                if (descricao == string.Empty)
                {
                    Servicos = await service.ObterTodosServicos();

                    if (Servicos == null)
                    {
                        return BadRequest();
                    }
                }
                else
                {
                    Servicos = await service.ObterServicoPorDescricao(descricao.Trim());

                    if (Servicos == null)
                    {
                        return NotFound();
                    }
                }

                return Ok(Servicos);
            }
            catch
            {
                throw;
            }
        }  

        [HttpGet]
        [Route("ByCusto/{custo}")]
        public async Task<ActionResult<List<Servico>>> ObterServicoPorCusto([FromRoute] string custo)
        {
            try
            {
                List<Servico> Servicos;

                if (custo == string.Empty)
                {
                    Servicos = await service.ObterTodosServicos();

                    if (Servicos == null)
                    {
                        return BadRequest();
                    }
                }
                else
                {
                    string[] data = custo.Split(" ");

                    var custoIni = decimal.Parse(data[0]);
                    var custoFim = decimal.Parse(data[1]);

                    Servicos = await service.ObterServicoPorCusto(custoIni, custoFim);

                    if (Servicos == null)
                    {
                        return NotFound();
                    }
                }

                return Ok(Servicos);
            }
            catch
            {
                throw;
            }
        }  
    }
}