using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Proyecto_1.Interfaces
{
    public interface IUsuarioController
    {
        public void AgregarUsuario(Usuario usuario);
        public bool ValidarIdentificacionRepetida(string id);

        public Usuario ValidarAutenticacion(string id, string pass);
        public string ObtenerRutaImagen(string rutaRelativa);

    }
}
