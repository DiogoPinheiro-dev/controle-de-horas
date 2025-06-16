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
                UsuarioId = usuario.UsuarioId,
                Email = usuario.Email,
                NivelDeUsuario = usuario.NivelDeUsuario,
                Senha = usuario.Senha
            };
        }

        public static Usuario DtoDaCriacaoDoUsuario(this CriarUsuarioDto usuarioDTO)
        {
            return new Usuario
            {
                Email = usuarioDTO.Email,
                Senha = usuarioDTO.Senha,
                NivelDeUsuario = usuarioDTO.NivelDeUsuario
            };
        }

        public static Usuario DtoDaAlteracaoDoUsuario(this AlterarUsuarioDto usuarioDTO)
        {
            return new Usuario
            {
                Email = "",
                Senha = usuarioDTO.Senha,
                NivelDeUsuario = usuarioDTO.NivelDeUsuario
            };
        }

        public static Usuario DtoDaDelecaoDoUsuario(this DeletarUsuarioDto usuarioDTO)
        {
            return new Usuario
            {
                UsuarioId = usuarioDTO.UsuarioId,
                Email = "",
                Senha = ""
            };
        }
    }
}