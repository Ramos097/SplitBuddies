using Models;
using Proyecto_1.Controllers;
using Proyecto_1.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Views.Vistas.Grupos
{
    public partial class FormcrearGrupo : Form
    {
        private readonly GrupoController _grupoController;
        private readonly IUsuarioController _usuarioController;
        private string rutaImagenSeleccionada;

        public FormcrearGrupo(GrupoController grupoController, IUsuarioController usuarioController)
        {
            InitializeComponent();
            _grupoController = grupoController;
            _usuarioController = usuarioController;

            this.Load += FormcrearGrupo_Load;
        }

        private void FormcrearGrupo_Load(object sender, EventArgs e)
        {
            var usuarios = _usuarioController.ObtenerTodosLosUsuarios();
            clbMiembros.Items.Clear();
            foreach (var usuario in usuarios)
            {
                clbMiembros.Items.Add(usuario, false); // Añadir sin marcar
            }
        }

        private void btnSeleccionarImg_Click(object sender, EventArgs e)
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
            this.Close();
        }

        private void txtNombreGrupo_TextChanged(object sender, EventArgs e)
        {

        }

        private void pbImagenGrupo_Click(object sender, EventArgs e)
        {

        }
    }
}
