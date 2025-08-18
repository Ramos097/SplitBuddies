using Controllers.Controladores;
using Models;
using Proyecto_1.Interfaces;
using Proyecto_1.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Views.Vistas.Menus;

namespace Views.Vistas.Grupos
{
    public partial class FrmRGrupos : UserControl
    {
        // Usuario logeado actualmente en el sistema
        private readonly Usuario _usuario;

        // Controlador encargado de manejar operaciones de grupos
        private readonly GrupoController _grupoController;

        // Controlador encargado de manejar operaciones de usuarios
        private readonly IUsuarioController _usuarioController;

        // Ruta de la imagen seleccionada para el grupo
        private string rutaImagenSeleccionada;

        // Constructor que recibe al usuario logeado
        public FrmRGrupos(Usuario usuarioLogeado)
        {
            InitializeComponent(); // Inicializa los componentes visuales
            _usuario = usuarioLogeado; // Se guarda el usuario que inició sesión

            _grupoController = new GrupoController();       // Inicializa el controlador de grupos
            _usuarioController = new UsuarioController();   // Inicializa el controlador de usuarios

            // Se suscribe al evento Load del formulario
            this.Load += FrmRGrupos_Load;
        }

        // Evento que se ejecuta cuando carga el formulario
        private void FrmRGrupos_Load(object sender, EventArgs e)
        {
            // Se obtienen todos los usuarios registrados
            var usuarios = _usuarioController.ctr_ObtenerUsuarios();

            // Se limpia el checklist antes de cargar usuarios
            clbMiembros.Items.Clear();

            // Se recorren los usuarios y se agregan al checklist
            foreach (Usuario usuario in usuarios)
            {
                // Marca como seleccionado el usuario logeado, los demás quedan desmarcados
                if (usuario.Identificacion.Equals(_usuario.Identificacion))
                {
                    clbMiembros.Items.Add(usuario.Identificacion + "-" + usuario.NombreCompleto, true);
                }
                else
                {
                    clbMiembros.Items.Add(usuario.Identificacion + "-" + usuario.NombreCompleto, false);
                }
            }
        }

        // Evento del botón para seleccionar una imagen del grupo
        private void btnSeleccionarImagen_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.bmp"; // Solo permite imágenes

            // Si el usuario cancela, no se hace nada
            if (ofd.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            // Se guarda la ruta de la imagen seleccionada
            rutaImagenSeleccionada = ofd.FileName;

            // Se muestra la imagen en el PictureBox
            pbImagenGrupo.Image = Image.FromFile(rutaImagenSeleccionada);
            pbImagenGrupo.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        // Evento del botón para crear un grupo nuevo
        private void btnCrearGrupo_Click_1(object sender, EventArgs e)
        {
            // Validación: nombre vacío o sin imagen
            if (string.IsNullOrWhiteSpace(txtNombreGrupo.Text) || string.IsNullOrEmpty(rutaImagenSeleccionada))
            {
                MessageBox.Show("Debe ingresar un nombre y seleccionar una imagen.");
                return;
            }

            // Se obtienen los miembros seleccionados en el checklist
            var miembros = clbMiembros.CheckedItems.Cast<string>().ToList();

            // Validación: debe haber al menos un miembro
            if (miembros.Count == 0)
            {
                MessageBox.Show("Debe seleccionar al menos un miembro.");
                return;
            }

            // Se define la carpeta donde se almacenarán las imágenes
            string carpetaDestino = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "imagenes_grupo");

            // Si no existe la carpeta, se crea
            if (!Directory.Exists(carpetaDestino))
                Directory.CreateDirectory(carpetaDestino);

            // Se obtiene el nombre de la imagen y se copia en la carpeta destino
            string nombreImagen = Path.GetFileName(rutaImagenSeleccionada);
            string rutaFinal = Path.Combine(carpetaDestino, nombreImagen);
            File.Copy(rutaImagenSeleccionada, rutaFinal, true);

            // Se crea el objeto Grupo con los datos ingresados
            Grupo nuevoGrupo = new Grupo
            {
                Id = _grupoController.ctr_ObtenerUltimoIdGrupo(), // Se obtiene el último Id disponible
                Nombre = txtNombreGrupo.Text.Trim(),              // Nombre ingresado
                Imagen = rutaFinal                                // Ruta de la imagen guardada
            };

            // Se procesan los miembros seleccionados para obtener solo las identificaciones
            List<string> miembrosSeleccionados = ObtenerMiembrosSeleccionados(miembros);

            // Se registra el grupo en el controlador, indicando también el usuario creador
            _grupoController.ctr_CrearGrupo(nuevoGrupo, miembrosSeleccionados, _usuario.Identificacion);

            // Mensaje de confirmación
            MessageBox.Show("Grupo creado exitosamente.");
        }

        // Método auxiliar que procesa la lista de miembros seleccionados
        private List<string> ObtenerMiembrosSeleccionados(List<string> miembrosMarcados)
        {
            List<string> miembrosSeleccionados = new List<string>();

            foreach (var miembro in miembrosMarcados)
            {
                // Ejemplo de cadena: "123 - Juan Perez"
                string[] partes = miembro.Split('-');

                // Validación: la cadena debe tener exactamente dos partes
                if (partes.Length == 2)
                {
                    string identificacion = partes[0].Trim(); // Se extrae solo la identificación
                    miembrosSeleccionados.Add(identificacion);
                }
            }

            return miembrosSeleccionados;
        }
    }
}
