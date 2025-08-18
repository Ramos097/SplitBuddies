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
        private readonly Usuario _usuario;
        private readonly GrupoController _grupoController;
        private readonly IUsuarioController _usuarioController;
        private string rutaImagenSeleccionada;
        

        public FrmRGrupos(Usuario usuarioLogeado)
        {
            InitializeComponent();
            _usuario = usuarioLogeado;

            _grupoController = new GrupoController();
            _usuarioController = new UsuarioController();

            this.Load += FrmRGrupos_Load;
        }

        private void FrmRGrupos_Load(object sender, EventArgs e)
        {
            // Llenar usuarios en clbMiembros
            var usuarios = _usuarioController.ctr_ObtenerUsuarios();
            clbMiembros.Items.Clear();
            foreach (Usuario usuario in usuarios)
            {
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



        private void btnCrearGrupo_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreGrupo.Text) || string.IsNullOrEmpty(rutaImagenSeleccionada))
            {
                MessageBox.Show("Debe ingresar un nombre y seleccionar una imagen.");
                return;
            }

            var miembros = clbMiembros.CheckedItems.Cast<string>().ToList();

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
                Id = _grupoController.ctr_ObtenerUltimoIdGrupo(),
                Nombre = txtNombreGrupo.Text.Trim(),
                Imagen = rutaFinal,
            };
            List<string> miembrosSeleccionados = ObtenerMiembrosSeleccionados(miembros);






            _grupoController.ctr_CrearGrupo(nuevoGrupo, miembrosSeleccionados,_usuario.Identificacion);
        
            MessageBox.Show("Grupo creado exitosamente.");


        }


        private List<string> ObtenerMiembrosSeleccionados(List<string> miembrosMarcados)
        {
            List<string> miembrosSeleccionados = new List<string>();
            foreach (var miembro in miembrosMarcados)
            {
                // 123 -Juan Perez
                //0  -  1
                string[] partes = miembro.Split('-');
                if (partes.Length == 2)
                {
                    string identificacion = partes[0].Trim();
                    miembrosSeleccionados.Add(identificacion);

                }
            }
            return miembrosSeleccionados;
        }





        
    }
}
