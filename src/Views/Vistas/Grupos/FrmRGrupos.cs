using Models;
using Proyecto_1.Controllers;
using Proyecto_1.Interfaces;
using Proyecto_1.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Views.Vistas.Grupos
{
    public partial class FrmRGrupos : UserControl
    {
        private readonly Usuario _usuario;
        private readonly GrupoController _grupoController;
        private readonly IUsuarioController _usuarioController;
        private string rutaImagenSeleccionada;

        public FrmRGrupos(Usuario usuarioLogeado)
        {
            InitializeComponent();
            _usuario = usuarioLogeado;

            _grupoController = new GrupoController(new LogicaNegocio.Services.GrupoService());
            _usuarioController = new UsuarioController();

            this.Load += FrmRGrupos_Load;
        }

        private void FrmRGrupos_Load(object sender, EventArgs e)
        {
            // Llenar usuarios en clbMiembros
            var usuarios = _usuarioController.ObtenerTodosLosUsuarios();
            clbMiembros.Items.Clear();
            foreach (var usuario in usuarios)
            {
                clbMiembros.Items.Add(usuario, false);
            }
        }

        private void btnSeleccionarImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.bmp";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                rutaImagenSeleccionada = ofd.FileName;
                pbImagenGrupo.Image = Image.FromFile(rutaImagenSeleccionada);
                pbImagenGrupo.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void btnCrearGrupo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreGrupo.Text) || string.IsNullOrEmpty(rutaImagenSeleccionada))
            {
                MessageBox.Show("Debe ingresar un nombre y seleccionar una imagen.");
                return;
            }

            var miembros = clbMiembros.CheckedItems.Cast<Usuario>().ToList();

            if (miembros.Count == 0)
            {
                MessageBox.Show("Debe seleccionar al menos un miembro.");
                return;
            }

            string carpetaDestino = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "imagenes_grupo");
            if (!Directory.Exists(carpetaDestino))
                Directory.CreateDirectory(carpetaDestino);

            string nombreImagen = Path.GetFileName(rutaImagenSeleccionada);
            string rutaFinal = Path.Combine(carpetaDestino, nombreImagen);
            File.Copy(rutaImagenSeleccionada, rutaFinal, true);

            Grupo nuevoGrupo = new Grupo
            {
                Id = Guid.NewGuid().ToString(),
                Nombre = txtNombreGrupo.Text.Trim(),
                Imagen = rutaFinal,
                Miembros = miembros
            };

            _grupoController.CrearGrupo(nuevoGrupo);
            MessageBox.Show("Grupo creado exitosamente.");
        }

        private void btnSeleccionarImagen_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.bmp";

            if (ofd.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            rutaImagenSeleccionada = ofd.FileName;
            pbImagenGrupo.Image = Image.FromFile(rutaImagenSeleccionada);
            pbImagenGrupo.SizeMode = PictureBoxSizeMode.StretchImage;
        }
    }
}
