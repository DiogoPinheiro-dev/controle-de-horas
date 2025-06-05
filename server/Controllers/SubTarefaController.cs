using Microsoft.AspNetCore.Mvc;
using server.Dtos.SubTarefa;
using server.Interfaces;
using server.Mappers;
using server.Models;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubTarefaController(ISubTarefaService service) : ControllerBase
    {
        private readonly ISubTarefaService service = service;

        [HttpPost]
        public async Task<ActionResult> CriarSubTarefa([FromBody] CriarSubTarefaDto SubTarefaDto)
        {
            try
            {
                if (SubTarefaDto == null)
                {
                    return NoContent();
                }

                var SubTarefa = SubTarefaDto.DtoDaCriacaoDaSubTarefa();

                if (SubTarefa == null)
                {
                    return BadRequest();
                }

                await service.CriarSubTarefa(SubTarefa);

                return Ok(SubTarefa.DtoDaSubTarefa());
            }
            catch
            {
                throw;
            }
        }

        [HttpPatch]
        [Route("{id}")]
        public async Task<ActionResult> AlterarSubTarefa([FromRoute] int id, [FromBody] AtualizarSubTarefaDto SubTarefaDto)
        {
            try
            {
                if (id <= 0)
                {
                    return NoContent();
                }

                var SubTarefa = await service.ObterSubTarefaPorId(id);

                if (SubTarefa == null)
                {
                    return NotFound();
                }

                if (SubTarefaDto == null)
                {
                    return NoContent();
                }

                var SubTarefaBody = SubTarefaDto.DtoDaAtualizacaoDaSubTarefa();

                if (SubTarefaBody == null)
                {
                    return BadRequest();
                }

                await service.AtualizarSubTarefa(SubTarefa, SubTarefaBody);

                return Ok(SubTarefa.DtoDaSubTarefa());
            }
            catch
            {
                throw;
            }

        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeletarSubTarefa([FromRoute] int id)
        {
            try
            {
                if (id <= 0)
                {
                    return NoContent();
                }

                var SubTarefa = await service.ObterSubTarefaPorId(id);

                if (SubTarefa == null)
                {
                    return NotFound();
                }
                await service.DeletarSubTarefa(SubTarefa);

                return Ok(SubTarefa.DtoDaSubTarefa());
            }
            catch
            {
                throw;
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<SubTarefa>>> ObterTodosSubTarefas()
        {
            try
            {
                List<SubTarefa> SubTarefas = await service.ObterTodasSubTarefas();
                List<SubTarefaDto> SubTarefasDtos = [];

                foreach (var SubTarefa in SubTarefas)
                    SubTarefasDtos.Add(SubTarefa.DtoDaSubTarefa());

                return Ok(SubTarefasDtos);
            }
            catch
            {
                throw;
            }
        }

        [HttpGet]
        [Route("ById/{id}")]
        public async Task<ActionResult<SubTarefa>> ObterSubTarefaPorId([FromRoute] int id)
        {
            try
            {
                if (id <= 0)
                {
                    return NoContent();
                }

                var SubTarefa = await service.ObterSubTarefaPorId(id);

                if (SubTarefa == null)
                {
                    return NotFound();
                }

                return Ok(SubTarefa.DtoDaSubTarefa());
            }
            catch
            {
                throw;
            }
        }
        
        [HttpGet]
        [Route("ByDescricao/{descricao}")]
        public async Task<ActionResult<List<SubTarefa>>> ObterSubTarefaPorDescricao([FromRoute] string descricao)
        {
            try
            {
                List<SubTarefa> SubTarefas;
                List<SubTarefaDto> SubTarefasDtos = [];

                if (descricao == string.Empty)
                {
                    SubTarefas = await service.ObterTodasSubTarefas();

                    if (SubTarefas == null)
                    {
                        return BadRequest();
                    }
                }
                else
                {
                    SubTarefas = await service.ObterSubTarefaPorDescricao(descricao.Trim());

                    if (SubTarefas == null)
                    {
                        return NotFound();
                    }
                }

                foreach (var SubTarefa in SubTarefas)
                    SubTarefasDtos.Add(SubTarefa.DtoDaSubTarefa());

                return Ok(SubTarefasDtos);
            }
            catch
            {
                throw;
            }
        }

        [HttpGet]
        [Route("ByData/{deAte}")]
        public async Task<ActionResult<List<SubTarefa>>> ObterSubTarefaPorData([FromRoute] string deAte) // "aaaammdd aaaammdd"
        {
            try
            {
                List<SubTarefa> SubTarefas;
                List<SubTarefaDto> SubTarefasDtos = [];

                string[] data;
                int dataIni, dataFim;

                data = deAte.Split(" ");

                dataIni = int.Parse(data[0]);
                dataFim = int.Parse(data[1]);

                if (dataIni <= dataFim)
                {
                    SubTarefas = await service.ObterSubTarefasPorData(dataIni, dataFim);
                }
                else
                {
                    SubTarefas = await service.ObterTodasSubTarefas();
                }

                if (SubTarefas == null)
                {
                    return NotFound();
                }

                foreach (var SubTarefa in SubTarefas)
                    SubTarefasDtos.Add(SubTarefa.DtoDaSubTarefa());

                return Ok(SubTarefasDtos);
            }
            catch
            {
                throw;
            }
        }
    }
}