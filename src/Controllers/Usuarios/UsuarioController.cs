using System;
using Models;
using Proyecto_1.Interfaces;
using Proyecto_1.Services;


namespace Proyecto_1.Controllers
{
    public class UsuarioController : IUsuarioController

    {
        private readonly IUsuario _usuarioService;

        public UsuarioController()
        {
            _usuarioService = new UsuarioService(); 
        }

        public void AgregarUsuario(Usuario usuario)
        {
            try
            {
                _usuarioService.AgregarUsuario(usuario);
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        public Usuario ValidarAutenticacion(string id, string pass)
        {
            Usuario usuario = _usuarioService.ValidarAutenticacion(id, pass);

            if (usuario == null)
            {
                throw new Exception("Usuario o contraseña incorrectos.");
            }
            return usuario;


        }

        public string ObtenerRutaImagen(string rutaRelativa)
        {
            string basePath = AppContext.BaseDirectory;
            string srcPath = Directory.GetParent(basePath)!.Parent!.Parent!.Parent!.Parent!.FullName;
            return Path.Combine(srcPath, "LogicaNegocio", "Almacenamiento", rutaRelativa);
        }

        public bool ValidarIdentificacionRepetida(string id)
        {
            return _usuarioService.ValidarIdentificacionRepetida(id);
        }
        public IEnumerable<object> ObtenerTodosLosUsuarios() => _usuarioService.ObtenerUsuarios().Cast<object>();

    }
}
