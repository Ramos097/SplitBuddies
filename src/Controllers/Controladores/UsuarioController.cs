using System;
using Models;
using Proyecto_1.Interfaces;
using Proyecto_1.Services;


// Namespace: organiza el código en un grupo lógico
namespace Controllers.Controladores
{
    // Clase que controla las operaciones relacionadas con los usuarios
    // Implementa la interfaz IUsuarioController
    public class UsuarioController : IUsuarioController
    {
        // Campo privado que guarda la referencia al servicio de usuarios
        private readonly IUsuario _usuarioService;

        // Constructor: inicializa el servicio de usuarios cuando se crea el controlador
        public UsuarioController()
        {
            _usuarioService = new UsuarioService();
        }

        // Método: agrega un nuevo usuario al sistema
        public void ctr_AgregarUsuario(Usuario usuario)
        {
            try
            {
                _usuarioService.AgregarUsuario(usuario); // llama al servicio para agregar el usuario
            }
            catch (Exception)
            {
                // si ocurre un error, lo vuelve a lanzar
                throw;
            }
        }

        // Método: valida que el usuario y la contraseña sean correctos
        public Usuario ctr_ValidarAutenticacion(string id, string pass)
        {
            Usuario usuario = _usuarioService.ValidarAutenticacion(id, pass);

            if (usuario == null) // si no se encuentra el usuario
            {
                throw new Exception("Usuario o contraseña incorrectos."); // muestra error
            }
            return usuario; // devuelve el usuario validado
        }

        // Método: obtiene la ruta completa de una imagen a partir de una ruta relativa
        public string ctr_ObtenerRutaImagen(string rutaRelativa)
        {
            string basePath = AppContext.BaseDirectory; // ruta base del proyecto
            string srcPath = Directory.GetParent(basePath)!.Parent!.Parent!.Parent!.Parent!.FullName;
            return Path.Combine(srcPath, "LogicaNegocio", "Almacenamiento", rutaRelativa);
        }

        // Método: valida si ya existe un usuario con la misma identificación
        public bool ctr_ValidarIdentificacionRepetida(string id)
        {
            return _usuarioService.ValidarIdentificacionRepetida(id);
        }

        // Método: obtiene todos los usuarios registrados
        public List<Usuario> ctr_ObtenerUsuarios()
        {
            return _usuarioService.ObtenerUsuarios();
        }

        // Método: obtiene un usuario por su identificación
        public Usuario ctr_ObtenerUsuarioId(string identificacion)
        {
            return _usuarioService.ObtenerUsuarioById(identificacion);
        }
    }
}

