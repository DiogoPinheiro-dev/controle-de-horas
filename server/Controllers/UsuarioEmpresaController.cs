using Microsoft.AspNetCore.Mvc;
using server.Interfaces;
using server.Models;

namespace server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosEmpresasController(IUsuariosEmpresasService service) : ControllerBase
    {
        private readonly IUsuariosEmpresasService service = service;

        [HttpGet]
        public async Task<ActionResult<List<UsuariosEmpresas>>> ObterTodasAsRelacionamentoUsuariosEmpresas()
        {
            try
            {
                List<UsuariosEmpresas> UsuariosEmpresass;

                UsuariosEmpresass = await service.ObterTodosRelacionamentos();

                return Ok(UsuariosEmpresass);
            }
            catch
            {
                throw;
            }
        }

        [HttpGet]
        [Route("ByUsuariosId/{UsuariosId}")]
        public async Task<ActionResult<List<UsuariosEmpresas>>> ObterRelacionamentoPorIdDaUsuarios([FromRoute] int UsuariosId)
        {
            try
            {
                if (UsuariosId <= 0)
                {
                    return NoContent();
                }

                List<UsuariosEmpresas> UsuariosEmpresass;

                UsuariosEmpresass = await service.ObterRelacionamentoPorIdDeUsuario(UsuariosId);

                return Ok(UsuariosEmpresass);
            }
            catch
            {
                throw;
            }
        }

        [HttpGet]
        [Route("ByEmpresasId/{EmpresasId}")]
        public async Task<ActionResult<List<UsuariosEmpresas>>> ObterRelacionamentoPorIdDeEmpresa([FromRoute] int EmpresasId)
        {
            try
            {
                if (EmpresasId <= 0)
                {
                    return NoContent();
                }

                List<UsuariosEmpresas> UsuariosEmpresass;

                UsuariosEmpresass = await service.ObterRelacionamentoPorIdDeEmpresa(EmpresasId);

                return Ok(UsuariosEmpresass);
            }
            catch
            {
                throw;
            }

        }
    }
}