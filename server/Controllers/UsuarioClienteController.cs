using Microsoft.AspNetCore.Mvc;
using server.Interfaces;
using server.Models;

namespace server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosClientesController(IUsuariosClientesService service) : ControllerBase
    {
        private readonly IUsuariosClientesService service = service;

        [HttpGet]
        public async Task<ActionResult<List<UsuariosClientes>>> ObterTodasAsRelacionamentoUsuariosClientes()
        {
            try
            {
                List<UsuariosClientes> UsuariosClientess;

                UsuariosClientess = await service.ObterTodosRelacionamentos();

                return Ok(UsuariosClientess);
            }
            catch
            {
                throw;
            }
        }

        [HttpGet]
        [Route("ByUsuariosId/{UsuariosId}")]
        public async Task<ActionResult<List<UsuariosClientes>>> ObterRelacionamentoPorIdDaUsuarios([FromRoute] int UsuariosId)
        {
            try
            {
                if (UsuariosId <= 0)
                {
                    return NoContent();
                }

                List<UsuariosClientes> UsuariosClientess;

                UsuariosClientess = await service.ObterRelacionamentoPorIdDeUsuario(UsuariosId);

                return Ok(UsuariosClientess);
            }
            catch
            {
                throw;
            }
        }

        [HttpGet]
        [Route("ByClientesId/{ClientesId}")]
        public async Task<ActionResult<List<UsuariosClientes>>> ObterRelacionamentoPorIdDeEmpresa([FromRoute] int ClientesId)
        {
            try
            {
                if (ClientesId <= 0)
                {
                    return NoContent();
                }

                List<UsuariosClientes> UsuariosClientess;

                UsuariosClientess = await service.ObterRelacionamentoPorIdDeCliente(ClientesId);

                return Ok(UsuariosClientess);
            }
            catch
            {
                throw;
            }

        }
    }
}