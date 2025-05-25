using Microsoft.AspNetCore.Mvc;
using server.Dtos.Tarefa;
using server.Interfaces;
using server.Mappers;
using server.Models;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefaService service;

        public TarefaController(ITarefaService service)
        {
            this.service = service;
        }

        [HttpPost]
        public async Task<ActionResult> CriarTarefa([FromBody] CriarTarefaDto TarefaDto)
        {
            try
            {
                if (TarefaDto == null)
                {
                    return NoContent();
                }

                var Tarefa = TarefaDto.DtoDaCriacaoDoTarefa();

                if (Tarefa == null)
                {
                    return BadRequest();
                }

                await service.CriarTarefa(Tarefa);

                return Ok(Tarefa);
            }
            catch
            {
                throw;
            }
        }

        [HttpPatch]
        [Route("{id}")]
        public async Task<ActionResult> AlterarTarefa([FromRoute] int id, [FromBody] AtualizarTarefaDto TarefaDto)
        {
            try
            {
                if (id <= 0)
                {
                    return NoContent();
                }

                var Tarefa = await service.ObterTarefaPorId(id);

                if (Tarefa == null)
                {
                    return NotFound();
                }

                if (TarefaDto == null)
                {
                    return NoContent();
                }

                var TarefaBody = TarefaDto.DtoDaAtualizacaoDoTarefa();

                if (TarefaBody == null)
                {
                    return BadRequest();
                }

                await service.AtualizarTarefa(Tarefa, TarefaBody);

                return Ok(Tarefa);
            }
            catch
            {
                throw;
            }

        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeletarTarefa([FromRoute] int id)
        {
            try
            {
                if (id <= 0)
                {
                    return NoContent();
                }

                var Tarefa = await service.ObterTarefaPorId(id);

                if (Tarefa == null)
                {
                    return NotFound();
                }
                await service.DeletarTarefa(Tarefa);

                return Ok(Tarefa);
            }
            catch
            {
                throw;
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<Tarefa>>> ObterTodosTarefas()
        {
            try
            {
                List<Tarefa> Tarefas = await service.ObterTodasTarefas();

                return Ok(Tarefas);
            }
            catch
            {
                throw;
            }
        }

        [HttpGet]
        [Route("ById/{id}")]
        public async Task<ActionResult<Tarefa>> ObterTarefaPorId([FromRoute] int id)
        {
            try
            {
                if (id <= 0)
                {
                    return NoContent();
                }

                var Tarefa = await service.ObterTarefaPorId(id);

                if (Tarefa == null)
                {
                    return NotFound();
                }

                return Ok(Tarefa);
            }
            catch
            {
                throw;
            }
        }
        
        [HttpGet]
        [Route("ByDescricao/{descricao}")]
        public async Task<ActionResult<List<Tarefa>>> ObterTarefaPorDescricao([FromRoute] string descricao)
        {
            try
            {
                List<Tarefa> Tarefas;

                if (descricao == string.Empty)
                {
                    Tarefas = await service.ObterTodasTarefas();

                    if (Tarefas == null)
                    {
                        return BadRequest();
                    }
                }
                else
                {
                    Tarefas = await service.ObterTarefaPorDescricao(descricao.Trim());

                    if (Tarefas == null)
                    {
                        return NotFound();
                    }
                }

                return Ok(Tarefas);
            }
            catch
            {
                throw;
            }
        }

        [HttpGet]
        [Route("ByData/{deAte}")]
        public async Task<ActionResult<List<Tarefa>>> ObterTarefaPorData([FromRoute] string deAte) // "aaaammdd aaaammdd"
        {
            try
            {
                List<Tarefa> Tarefas;
                string[] data;
                int dataIni, dataFim;

                data = deAte.Split(" ");

                dataIni = int.Parse(data[0]);
                dataFim = int.Parse(data[1]);

                if (dataIni <= dataFim)
                {
                    Tarefas = await service.ObterTarefasPorData(dataIni, dataFim);
                }
                else
                {
                    Tarefas = await service.ObterTodasTarefas();
                }

                if (Tarefas == null)
                {
                    return NotFound();
                }

                return Ok(Tarefas);

            }
            catch
            {
                throw;
            }
        }
    }
}