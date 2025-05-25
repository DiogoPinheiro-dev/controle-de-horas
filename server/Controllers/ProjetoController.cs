using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using server.Dtos.Projeto;
using server.Interfaces;
using server.Mappers;
using server.Models;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjetoController : ControllerBase
    {
        private readonly IProjetoService service;

        public ProjetoController(IProjetoService service)
        {
            this.service = service;
        }

        [HttpPost]
        public async Task<ActionResult> CriarProjeto([FromBody] CriarProjetoDto ProjetoDto)
        {
            try
            {
                if (ProjetoDto == null)
                {
                    return NoContent();
                }

                var Projeto = ProjetoDto.DtoDaCriacaoDoProjeto();

                if (Projeto == null)
                {
                    return BadRequest();
                }

                await service.CriarProjeto(Projeto);

                return Ok(Projeto);
            }
            catch
            {
                throw;
            }
        }

        [HttpPatch]
        [Route("{id}")]
        public async Task<ActionResult> AlterarProjeto([FromRoute] int id, [FromBody] AtualizarProjetoDto ProjetoDto)
        {
            try
            {
                if (id <= 0)
                {
                    return NoContent();
                }

                var Projeto = await service.ObterProjetoPorId(id);

                if (Projeto == null)
                {
                    return NotFound();
                }

                if (ProjetoDto == null)
                {
                    return NoContent();
                }

                var ProjetoBody = ProjetoDto.DtoDaAtualizacaoDoProjeto();

                if (ProjetoBody == null)
                {
                    return BadRequest();
                }

                await service.AtualizarProjeto(Projeto, ProjetoBody);

                return Ok(Projeto);
            }
            catch
            {
                throw;
            }

        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeletarProjeto([FromRoute] int id)
        {
            try
            {
                if (id <= 0)
                {
                    return NoContent();
                }

                var Projeto = await service.ObterProjetoPorId(id);

                if (Projeto == null)
                {
                    return NotFound();
                }
                await service.DeletarProjeto(Projeto);

                return Ok(Projeto);
            }
            catch
            {
                throw;
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<Projeto>>> ObterTodosProjetos()
        {
            try
            {
                List<Projeto> Projetos = await service.ObterTodosProjetos();

                return Ok(Projetos);
            }
            catch
            {
                throw;
            }
        }

        [HttpGet]
        [Route("ById/{id}")]
        public async Task<ActionResult<Projeto>> ObterProjetoPorId([FromRoute] int id)
        {
            try
            {
                if (id <= 0)
                {
                    return NoContent();
                }

                var Projeto = await service.ObterProjetoPorId(id);

                if (Projeto == null)
                {
                    return NotFound();
                }

                return Ok(Projeto);
            }
            catch
            {
                throw;
            }
        }

        [HttpGet]
        [Route("ByNome/{nome}")]
        public async Task<ActionResult<List<Projeto>>> ObterProjetoPorNome([FromRoute] string nome)
        {
            try
            {
                List<Projeto> Projetos;

                if (nome == string.Empty)
                {
                    Projetos = await service.ObterTodosProjetos();

                    if (Projetos == null)
                    {
                        return BadRequest();
                    }
                }
                else
                {
                    Projetos = await service.ObterProjetoPorNome(nome.Trim());

                    if (Projetos == null)
                    {
                        return NotFound();
                    }
                }

                return Ok(Projetos);
            }
            catch
            {
                throw;
            }
        }
        
        [HttpGet]
        [Route("ByDescricao/{descricao}")]
        public async Task<ActionResult<List<Projeto>>> ObterProjetoPorDescricao([FromRoute] string descricao)
        {
            try
            {
                List<Projeto> Projetos;

                if (descricao == string.Empty)
                {
                    Projetos = await service.ObterTodosProjetos();

                    if (Projetos == null)
                    {
                        return BadRequest();
                    }
                }
                else
                {
                    Projetos = await service.ObterProjetoPorDescricao(descricao.Trim());

                    if (Projetos == null)
                    {
                        return NotFound();
                    }
                }

                return Ok(Projetos);
            }
            catch
            {
                throw;
            }
        }

        [HttpGet]
        [Route("ByData/{deAte}")]
        public async Task<ActionResult<List<Projeto>>> ObterProjetoPorData([FromRoute] string deAte) // "aaaammdd aaaammdd"
        {
            try
            {
                List<Projeto> Projetos;
                string[] data;
                int dataIni, dataFim;

                data = deAte.Split(" ");

                dataIni = int.Parse(data[0]);
                dataFim = int.Parse(data[1]);

                if (dataIni <= dataFim)
                {
                    Projetos = await service.ObterProjetosPorData(dataIni, dataFim);
                }
                else
                {
                    Projetos = await service.ObterTodosProjetos();
                }

                if (Projetos == null)
                {
                    return NotFound();
                }

                return Ok(Projetos);

            }
            catch
            {
                throw;
            }
        }
    }
}