using server.Dtos.Usuario;
using server.Mappers;
using server.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController(IUsuarioService servico) : ControllerBase
    {
        private readonly IUsuarioService servico = servico;

        [HttpPost]
        public async Task<IActionResult> CriarUsuario([FromBody] CriarUsuarioDto usuarioDto)
        {
            try
            {
                if (usuarioDto == null)
                {
                    return BadRequest("Dados do usuário inválidos");
                }

                var usuario = usuarioDto.DtoDaCriacaoDoUsuario();

                if (usuario == null)
                {
                    return BadRequest("Erro ao mapear os dados do usuário");
                }

                var resultado = await servico.CriarUsuario(usuario);

                if (resultado == null)
                {
                    return BadRequest("Erro ao criar o usuário");
                }

                return Ok(resultado.DtoDoUsuario());
            }
            catch
            {
                throw;
            }
        }

        [HttpPatch]
        [Route("{id}")]
        public async Task<IActionResult> AlterarUsuario([FromRoute] int id, [FromBody] AlterarUsuarioDto usuarioDto)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("ID do usuário inválido");
                }

                if (usuarioDto == null)
                {
                    return BadRequest("Dados do usuário para atualização inválidos");
                }

                var usuario = await servico.ObterUsuarioPorIdDeUsuario(id);

                if (usuario == null)
                {
                    return NotFound("Usuário não encontrado");
                }

                var body = usuarioDto.DtoDaAlteracaoDoUsuario();

                if (body == null)
                {
                    return BadRequest("Dados do usuário para atualização inválidos");
                }

                var resultado = await servico.AlterarUsuario(usuario, body);

                if (resultado == null)
                {
                    return BadRequest("Erro ao atualizar o usuário");
                }

                return Ok(resultado.DtoDoUsuario());
            }
            catch
            {
                throw;
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeletarUsuario([FromRoute] int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("ID do usuário inválido");
                }

                var usuario = await servico.ObterUsuarioPorIdDeUsuario(id);

                if (usuario == null)
                {
                    return NotFound("Usuário não encontrado");
                }

                var resultado = await servico.DeletarUsuario(usuario);

                if (resultado == null)
                {
                    return BadRequest("Erro ao deletar o usuário");
                }

                return Ok(resultado.DtoDoUsuario());
            }
            catch
            {
                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodosOsUsuarios()
        {
            try
            {
                List<UsuarioDto> usuariosDto = [];

                var usuarios = await servico.ObterTodosOsUsuarios();

                if (usuarios == null)
                {
                    return NotFound("Nenhum usuário encontrado");
                }

                usuariosDto = usuarios.Select(u => u.DtoDoUsuario()).ToList();

                return Ok(usuariosDto);
            }
            catch
            {
                throw;
            }
        }

        [HttpGet]
        [Route("ByEmail/{email}")]
        public async Task<IActionResult> ObterUsuarioPorEmail([FromRoute] string email)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(email))
                {
                    return BadRequest("Email inválido");
                }

                var usuario = await servico.ObterUsuarioPorEmail(email);

                if (usuario == null)
                {
                    return NotFound("Usuário não encontrado");
                }

                return Ok(usuario.DtoDoUsuario());
            }
            catch
            {
                throw;
            }
        }

        [HttpGet]
        [Route("ById/{id}")]
        public async Task<IActionResult> ObterUsuarioPorId([FromRoute] int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("ID do usuário inválido");
                }

                var usuario = await servico.ObterUsuarioPorIdDeUsuario(id);

                if (usuario == null)
                {
                    return NotFound("Usuário não encontrado");
                }

                return Ok(usuario.DtoDoUsuario());
            }
            catch
            {
                throw;
            }
        }

        [HttpGet]
        [Route("ByNivelDeUsuario/{nivelDeUsuario}")]
        public async Task<IActionResult> ObterUsuariosPorNivelDeUsuario([FromRoute] int nivelDeUsuario)
        {
            try
            {
                List<UsuarioDto> usuariosDto = [];

                if (nivelDeUsuario < 0)
                {
                    return BadRequest("Nível de usuário inválido");
                }

                var usuarios = await servico.ObterUsuariosPorNivelDeUsuario(nivelDeUsuario);

                if (usuarios == null)
                {
                    return NotFound("Nenhum usuário encontrado para este nível");
                }

                usuariosDto = usuarios.Select(u => u.DtoDoUsuario()).ToList();

                return Ok(usuariosDto);
            }
            catch
            {
                throw;
            }
        }
    }
}