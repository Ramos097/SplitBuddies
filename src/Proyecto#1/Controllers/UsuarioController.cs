using System;
using Proyecto_1.Services;

namespace Proyecto_1.Controllers
{
    internal class UsuarioController
    {
        private readonly IUsuario _usuarioService;

        public UsuarioController(IUsuario usuarioService)
        {
            _usuarioService = usuarioService ?? throw new ArgumentNullException(nameof(usuarioService));
        }

        public void AgregarUsuario(Models.Usuario usuario)
        {
            if (usuario == null)
                throw new ArgumentNullException(nameof(usuario), "El usuario no puede ser nulo.");

            if (string.IsNullOrWhiteSpace(usuario.NombreCompleto) ||
                string.IsNullOrWhiteSpace(usuario.Correo) ||
                string.IsNullOrWhiteSpace(usuario.Contraseña))
            {
                throw new ArgumentException("Los campos Nombre Completo, Correo y Contraseña son obligatorios.");
            }

            _usuarioService.AgregarUsuario(usuario);
        }
    }
}
