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
        public void ctr_AgregarUsuario(Usuario usuario);
        public bool ctr_ValidarIdentificacionRepetida(string id);

        public Usuario ctr_ValidarAutenticacion(string id, string pass);
        public string ctr_ObtenerRutaImagen(string rutaRelativa);
        public List<Usuario> ctr_ObtenerUsuarios();
        public Usuario ctr_ObtenerUsuarioId(string identificacion);
    }
}
