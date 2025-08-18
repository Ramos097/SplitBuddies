using Controllers.Controladores;
using Controllers.Interfaces;
using LogicaNegocio.Interfaces;
using Models;
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
using Views.Vistas.Auth;
using Views.Vistas.Gastos;
using Views.Vistas.Grupos;
using Views.Vistas.Invitaciones;
using Views.Vistas.Reportes;

namespace Views.Vistas.Menus
{
    public partial class MenuPrincipal : Form
    {
        private Usuario _usuario;
        private readonly IGastosController _gastosController;
        private readonly IUsuarioController _usuarioController;
        private readonly IGrupoUsuariosController _gruposUsuariosController;

        public MenuPrincipal(Usuario usuarioLogeado)
        {
            InitializeComponent();
            lbDeudas.Font = new Font("Segoe UI", 10, FontStyle.Regular);

            lbDeudas.SelectionMode = SelectionMode.One;
            lbDeudas.BorderStyle = BorderStyle.FixedSingle;
            lbDeudas.IntegralHeight = false;
            lbDeudas.ItemHeight = 22; // ítems más altos
            lbDeudas.BackColor = Color.FromArgb(50, 50, 50);
            lbDeudas.ForeColor = Color.White;
            lbDeudas.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lbDeudas.HorizontalScrollbar = false;
            lbDeudas.HorizontalExtent = 0;

            lbDeudas.ScrollAlwaysVisible = false;
            txtAvisoDeudas.ForeColor = Color.Orange;
            txtDeudas.ForeColor = Color.OrangeRed;


            _gastosController = new GastosController();
            _usuarioController = new UsuarioController();
            _gruposUsuariosController = new GruposUsuariosController();

            _usuario = usuarioLogeado;
            //txtAvisos.Visible = false;

            cargarDatos();
            cargarDeudas();


        }

        private void cargarDeudas()
        {
            var deudas = _gastosController.crt_obtenerAQuieDebeUsuario(_usuario.Identificacion);
            if (deudas.Count > 0)
            {
                txtDeudas.Visible = true;
                txtAvisoDeudas.Visible = true;
                lbDeudas.Items.Clear();
                foreach (var deuda in deudas)
                {
                    lbDeudas.Items.Add(deuda);
                }
            }
            else
            {
                txtDeudas.Visible = false;
                txtAvisoDeudas.Visible = false;
                lbDeudas.Items.Clear();
                lbDeudas.Visible = false;
            }
        }


        public MenuPrincipal()
        {
        }

        private void cargarDatos()
        {

            txtName.Text = _usuario.NombreCompleto;


            try
            {
                string rutaAbsoluta = _usuarioController.ctr_ObtenerRutaImagen(_usuario.Imagen);
                pictureBox1.Image = Image.FromFile(rutaAbsoluta);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                var GruposUsuario = _gruposUsuariosController.crt_ObtenerGruposPorUsuario(_usuario.Identificacion);
                foreach (var grupo in GruposUsuario)
                {
                    if (grupo.EstadoInvitacion.Equals("PENDIENTE"))
                    {
                        btnInvitaciones.Text = "Invitacion Pendiente";
                        btnInvitaciones.BackColor = Color.Orange;

                    }
                }
            }
            catch (Exception)
            {
                try
                {
                    // Ruta relativa a partir del ejecutable
                    string rutaDefault = _usuarioController.ctr_ObtenerRutaImagen("imgs\\user.png");
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

        private void btnInvitaciones_Click(object sender, EventArgs e)
        {

            FrmInvitaciones ventana = new FrmInvitaciones(_usuario);
            ventana.ActualizarBotonInvitacionesEvent += ActualizarBotonInvitaciones;
            PanelContenido.Controls.Clear();
            ventana.Dock = DockStyle.Fill;
            PanelContenido.Controls.Add(ventana);

        }

        private void ActualizarBotonInvitaciones(bool estado)
        {
            if (estado)
            {
                btnInvitaciones.Text = "Invitacion Pendiente";
                btnInvitaciones.BackColor = Color.Orange;
            }
            else
            {
                btnInvitaciones.Text = "Invitaciones";
                btnInvitaciones.BackColor = Color.FromArgb(59, 178, 113);

            }
        }

        private void btnGrupos_Click(object sender, EventArgs e)
        {
            FrmInfoGrupos ventana = new FrmInfoGrupos(_usuario);
            PanelContenido.Controls.Clear();
            ventana.Dock = DockStyle.Fill;
            PanelContenido.Controls.Add(ventana);
        }

        private void btnGastos_Click(object sender, EventArgs e)
        {
            FrmListadoGastos ventana = new FrmListadoGastos(_usuario);

            ventana.CambiarVista += (idGasto, usuario) =>
            {
                FrmRGastos frmRGastos = new FrmRGastos(idGasto, usuario);
                PanelContenido.Controls.Clear();
                frmRGastos.Dock = DockStyle.Fill;
                PanelContenido.Controls.Add(frmRGastos);
            };


            PanelContenido.Controls.Clear();
            ventana.Dock = DockStyle.Fill;
            PanelContenido.Controls.Add(ventana);
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            FrmReporte ventana = new FrmReporte(_usuario);
            PanelContenido.Controls.Clear();
            ventana.Dock = DockStyle.Fill;
            PanelContenido.Controls.Add(ventana);
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            FrmLogin frmLogin = new FrmLogin();
            frmLogin.Show();
            this.Hide();
        }

   

        private void MenuPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
