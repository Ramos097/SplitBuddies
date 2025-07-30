using Models;
using Proyecto_1.Controllers;
using Proyecto_1.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Views.Gastos;
using Views.Vistas.Grupos;

namespace Views.Vistas.Menus
{
    public partial class MenuPrincipal : Form
    {
        private Usuario _usuario;
        private readonly IUsuarioController _usuarioController;
        public MenuPrincipal(Usuario usuarioLogeado)
        {
            InitializeComponent();
            _usuarioController = new UsuarioController();
            _usuario = usuarioLogeado;
            cargarDatos();

        }

        public MenuPrincipal()
        {
        }

        private void cargarDatos()
        {

            txtName.Text = _usuario.NombreCompleto;

            try
            {
                string rutaAbsoluta = _usuarioController.ObtenerRutaImagen(_usuario.Imagen);
                pictureBox1.Image = Image.FromFile(rutaAbsoluta);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch (Exception)
            {
                try
                {
                    // Ruta relativa a partir del ejecutable
                    string rutaDefault = _usuarioController.ObtenerRutaImagen("imgs\\user.png");
                    pictureBox1.Image = Image.FromFile(rutaDefault);
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

                }
                catch
                {
                    pictureBox1.Image = null; // Por si también falla
                }
            }
        }

        private void btnRGastos_Click(object sender, EventArgs e)
        {
            FrmRGastos ventana = new FrmRGastos(_usuario);
            PanelContenido.Controls.Clear();
            ventana.Dock = DockStyle.Fill;
            PanelContenido.Controls.Add(ventana);
        }

        private void btnRGrupos_Click(object sender, EventArgs e)
        {
            FrmRGrupos ventana = new FrmRGrupos(_usuario);
            PanelContenido.Controls.Clear();
            ventana.Dock = DockStyle.Fill;
            PanelContenido.Controls.Add(ventana);
        }
    }
}
