using Microsoft.AspNetCore.Mvc;
using server.Dtos.Empresa;
using server.Interfaces;
using server.Mappers;
using server.Models;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController(IEmpresaService service) : ControllerBase
    {
        private readonly IEmpresaService service = service;

        [HttpPost]
        public async Task<ActionResult> CriarEmpresa([FromBody] CriarEmpresaDto EmpresaDto)
        {
            try
            {
                if (EmpresaDto == null)
                {
                    return NoContent();
                }

                var Empresa = EmpresaDto.DtoDaCriacaoDoEmpresa();

                if (Empresa == null)
                {
                    return BadRequest();
                }

                var res = await service.CriarEmpresa(Empresa);

                return Ok(res.DtoDaEmpresa());
            }
            catch
            {
                throw;
            }
        }

        [HttpPatch]
        [Route("{id}")]
        public async Task<ActionResult> AlterarEmpresa([FromRoute] int id, [FromBody] AtualizarEmpresaDto EmpresaDto)
        {
            try
            {
                if (id <= 0)
                {
                    return NoContent();
                }

                var Empresa = await service.ObterEmpresaPorId(id);

                if (Empresa == null)
                {
                    return NotFound();
                }

                if (EmpresaDto == null)
                {
                    return NoContent();
                }

                var EmpresaBody = EmpresaDto.DtoDaAtualizacaoDoEmpresa();

                if (EmpresaBody == null)
                {
                    return BadRequest();
                }

                var res = await service.AtualizarEmpresa(Empresa, EmpresaBody);

                return Ok(res.DtoDaEmpresa());
            }
            catch
            {
                throw;
            }

        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeletarEmpresa([FromRoute] int id)
        {
            try
            {
                if (id <= 0)
                {
                    return NoContent();
                }

                var Empresa = await service.ObterEmpresaPorId(id);

                if (Empresa == null)
                {
                    return NotFound();
                }
                var res = await service.DeletarEmpresa(Empresa);

                return Ok(res.DtoDaEmpresa());
            }
            catch
            {
                throw;
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<Empresa>>> ObterTodosEmpresas()
        {
            try
            {
                List<Empresa> Empresas = await service.ObterTodasEmpresas();
                List<EmpresaDto> EmpresasDtos = [];

                foreach (var Empresa in Empresas)
                    EmpresasDtos.Add(Empresa.DtoDaEmpresa());

                return Ok(EmpresasDtos);
            }
            catch
            {
                throw;
            }
        }

        [HttpGet]
        [Route("ById/{id}")]
        public async Task<ActionResult<Empresa>> ObterEmpresaPorId([FromRoute] int id)
        {
            try
            {
                if (id <= 0)
                {
                    return NoContent();
                }

                var Empresa = await service.ObterEmpresaPorId(id);

                if (Empresa == null)
                {
                    return NotFound();
                }

                return Ok(Empresa.DtoDaEmpresa());
            }
            catch
            {
                throw;
            }
        }

        [HttpGet]
        [Route("ByName/{nome}")]
        public async Task<ActionResult<List<Empresa>>> ObterEmpresaPorNome([FromRoute] string nome)
        {
            try
            {
                List<Empresa> Empresas;
                List<EmpresaDto> EmpresasDtos = [];

                if (nome == string.Empty)
                {
                    Empresas = await service.ObterTodasEmpresas();

                    if (Empresas == null)
                    {
                        return BadRequest();
                    }
                }
                else
                {
                    Empresas = await service.ObterEmpresaPorNome(nome.Trim());

                    if (Empresas == null)
                    {
                        return NotFound();
                    }
                }

                foreach (var Empresa in Empresas)
                    EmpresasDtos.Add(Empresa.DtoDaEmpresa());

                return Ok(EmpresasDtos);
            }
            catch
            {
                throw;
            }
        }
    }
}