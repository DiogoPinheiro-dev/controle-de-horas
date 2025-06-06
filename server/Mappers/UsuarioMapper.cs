using server.Models;
using server.Dtos.Usuario;

namespace server.Mappers
{
    public static class UsuarioMapper
    {
        public static UsuarioDto DtoDoUsuario(this Usuario usuario)
        {
            return new UsuarioDto
            {
                Email = usuario.Email,
                NivelDeUsuario = usuario.NivelDeUsuario,
                IdRecurso = usuario.RecursoId,
                IdCliente = usuario.ClienteId,
                IdEmpresa = usuario.EmpresaId
            };
        }

        public static Usuario DtoDaCriacaoDoUsuario(this CriarUsuarioDto usuarioDTO)
        {
            return new Usuario
            {
                Email = usuarioDTO.Email,
                Senha = usuarioDTO.Senha,
                NivelDeUsuario = usuarioDTO.NivelDeUsuario,
                RecursoId = usuarioDTO.IdRecurso,
                ClienteId = usuarioDTO.IdCliente,
                EmpresaId = usuarioDTO.IdEmpresa
            };
        }

        public static Usuario DtoDaAlteracaoDoUsuario(this AlterarUsuarioDto usuarioDTO)
        {
            return new Usuario
            {
                Email = usuarioDTO.Email,
                Senha = usuarioDTO.Senha,
                NivelDeUsuario = usuarioDTO.NivelDeUsuario,
                RecursoId = usuarioDTO.IdRecurso,
                ClienteId = usuarioDTO.IdCliente,
                EmpresaId = usuarioDTO.IdEmpresa
            };
        }

        public static Usuario DtoDaDelecaoDoUsuario(this DeletarUsuarioDto usuarioDTO)
        {
            return new Usuario
            {
                UsuarioId = usuarioDTO.Id,
                Email = "",
                Senha = ""
            };
        }
    }
}