using Microsoft.AspNetCore.Mvc;
using server.Interfaces;
using server.Models;

namespace server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosRecursosController(IUsuariosRecursosService service) : ControllerBase
    {
        private readonly IUsuariosRecursosService service = service;

        [HttpGet]
        public async Task<ActionResult<List<UsuariosRecursos>>> ObterTodasAsRelacionamentoUsuariosRecursos()
        {
            try
            {
                List<UsuariosRecursos> UsuariosRecursoss;

                UsuariosRecursoss = await service.ObterTodosRelacionamentos();

                return Ok(UsuariosRecursoss);
            }
            catch
            {
                throw;
            }
        }

        [HttpGet]
        [Route("ByUsuariosId/{UsuariosId}")]
        public async Task<ActionResult<List<UsuariosRecursos>>> ObterRelacionamentoPorIdDaUsuarios([FromRoute] int UsuariosId)
        {
            try
            {
                if (UsuariosId <= 0)
                {
                    return NoContent();
                }

                List<UsuariosRecursos> UsuariosRecursoss;

                UsuariosRecursoss = await service.ObterRelacionamentoPorIdDeUsuario(UsuariosId);

                return Ok(UsuariosRecursoss);
            }
            catch
            {
                throw;
            }
        }

        [HttpGet]
        [Route("ByRecursosId/{RecursosId}")]
        public async Task<ActionResult<List<UsuariosRecursos>>> ObterRelacionamentoPorIdDeRecurso([FromRoute] int RecursosId)
        {
            try
            {
                if (RecursosId <= 0)
                {
                    return NoContent();
                }

                List<UsuariosRecursos> UsuariosRecursoss;

                UsuariosRecursoss = await service.ObterRelacionamentoPorIdDeRecurso(RecursosId);

                return Ok(UsuariosRecursoss);
            }
            catch
            {
                throw;
            }

        }
    }
}