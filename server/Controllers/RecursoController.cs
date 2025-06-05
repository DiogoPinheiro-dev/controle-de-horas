using Microsoft.AspNetCore.Mvc;
using server.Dtos.Recurso;
using server.Interfaces;
using server.Mappers;
using server.Models;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecursoController(IRecursoService service) : ControllerBase
    {
        private readonly IRecursoService service = service;

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

                return Ok(modeloDeRecurso.DtoDoRecurso());

            }
            catch
            {
                throw;
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarRecurso([FromRoute] int id)
        {
            try
            {
                if (id <= 0)
                {
                    return NoContent();
                }

                var recurso = RecursoPorId(id).Result.Value;

                if (recurso == null)
                {
                    return NotFound();
                }

                await service.DeletarRecurso(recurso);

                return Ok(recurso.DtoDoRecurso());
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
                if (id <= 0)
                {
                    return NoContent();
                }

                var recurso = RecursoPorId(id).Result.Value;

                if (recurso == null)
                {
                    return NotFound();
                }

                var body = recursoDto.DtoDaAtualizacaoDoRecurso();

                if (body == null)
                {
                    return BadRequest();
                }

                await service.AtualizarRecurso(recurso, body);

                return Ok(recurso.DtoDoRecurso());
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
                List<RecursoDto> RecursosDtos = [];

                var recursos = await service.ObterTodosRecursos();

                if (recursos == null)
                {
                    return NotFound();
                }

                foreach (var recurso in recursos)
                    RecursosDtos.Add(recurso.DtoDoRecurso());

                return Ok(RecursosDtos);
            }
            catch
            {
                throw;
            }
        }

        [HttpGet("ById/{id}")]
        public async Task<ActionResult<Recurso>> RecursoPorId(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest();
                }

                var recurso = await service.ObterRecursoPorId(id);

                if (recurso == null)
                {
                    return NotFound();
                }

                return Ok(recurso.DtoDoRecurso());
            }
            catch
            {
                throw;
            }
        }

        [HttpGet("ByEmail/{email}")]
        public async Task<ActionResult<List<Recurso>>> RecursoPorEmail(string email)
        {
            try
            {
                List<RecursoDto> RecursosDtos = [];

                if (email == null)
                {
                    return BadRequest();
                }

                var recursos = await service.ObterRecursoPorEmail(email.Trim());

                if (recursos == null)
                {
                    return NotFound();
                }

                foreach (var recurso in recursos)
                    RecursosDtos.Add(recurso.DtoDoRecurso());

                return Ok(RecursosDtos);
            }
            catch
            {
                throw;
            }
        }

        [HttpGet("ByNome/{nome}")]
        public async Task<ActionResult<List<Recurso>>> RecursoPorNome(string nome)
        {
            try
            {
                List<RecursoDto> RecursosDtos = [];

                if (nome == null)
                {
                    return BadRequest();
                }

                var recursos = await service.ObterRecursoPorNome(nome.Trim());

                if (recursos == null)
                {
                    return NotFound();
                }

                foreach (var recurso in recursos)
                    RecursosDtos.Add(recurso.DtoDoRecurso());

                return Ok(recursos);
            }
            catch
            {
                throw;
            }
        }

        [HttpGet("ByTel/{tel}")]
        public async Task<ActionResult<List<Recurso>>> RecursoPorTelefone(string tel)
        {
            try
            {
                List<RecursoDto> RecursoDtos = [];

                if (tel == null)
                {
                    return BadRequest();
                }

                tel = tel.Replace(" ", "");
                tel = tel.Replace("-", "");

                if (tel.Contains("("))
                {
                    string[] parts;

                    string ddd, operadora_e_numero;
                    parts = tel.Split(")");

                    ddd = parts[0].Substring(1, 2).Trim();
                    operadora_e_numero = parts[1].Trim();

                    if (operadora_e_numero.Contains(" "))
                    {
                        operadora_e_numero = operadora_e_numero.Replace(" ", "");
                    }

                    tel = ddd + operadora_e_numero;
                }

                var recursos = await service.ObterRecursoPorTelefone(tel.Trim());

                if (recursos == null)
                {
                    return NotFound();
                }

                foreach (var recurso in recursos)
                    RecursoDtos.Add(recurso.DtoDoRecurso());

                return Ok(RecursoDtos);
            }
            catch
            {
                throw;
            }
        }

        [HttpGet("ByTipo/{tipo}")]
        public async Task<ActionResult<List<Recurso>>> RecursoPorTipo(char tipo)
        {
            try
            {
                List<RecursoDto> RecursosDtos = [];

                if (tipo.Equals(null))
                {
                    return BadRequest();
                }

                var recursos = await service.ObterRecursoPorTipo(tipo);

                if (recursos == null)
                {
                    return NotFound();
                }

                foreach (var recurso in recursos)
                    RecursosDtos.Add(recurso.DtoDoRecurso());

                return Ok(RecursosDtos);
            }
            catch
            {
                throw;
            }
        }
    }
}