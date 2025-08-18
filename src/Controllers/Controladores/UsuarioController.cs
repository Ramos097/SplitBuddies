using System;
using Models;
using Proyecto_1.Interfaces;
using Proyecto_1.Services;


namespace Controllers.Controladores
{
    public class UsuarioController : IUsuarioController

    {
        private readonly IUsuario _usuarioService;

        public UsuarioController()
        {
            _usuarioService = new UsuarioService();
        }

        public void ctr_AgregarUsuario(Usuario usuario)
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

        public Usuario ctr_ValidarAutenticacion(string id, string pass)
        {
            Usuario usuario = _usuarioService.ValidarAutenticacion(id, pass);

            if (usuario == null)
            {
                throw new Exception("Usuario o contraseña incorrectos.");
            }
            return usuario;


        }

        public string ctr_ObtenerRutaImagen(string rutaRelativa)
        {
            string basePath = AppContext.BaseDirectory;
            string srcPath = Directory.GetParent(basePath)!.Parent!.Parent!.Parent!.Parent!.FullName;
            return Path.Combine(srcPath, "LogicaNegocio", "Almacenamiento", rutaRelativa);
        }

        public bool ctr_ValidarIdentificacionRepetida(string id)
        {
            return _usuarioService.ValidarIdentificacionRepetida(id);
        }


        public List<Usuario> ctr_ObtenerUsuarios()
        {
            return _usuarioService.ObtenerUsuarios();
        }


        public Usuario ctr_ObtenerUsuarioId(string identificacion)
        {
            return _usuarioService.ObtenerUsuarioById(identificacion);
        }
    }
}
