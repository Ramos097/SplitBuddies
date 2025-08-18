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
        // Usuario que inició sesión
        private Usuario _usuario;

        // Controladores para manejar lógica de gastos, usuarios y grupos
        private readonly IGastosController _gastosController;
        private readonly IUsuarioController _usuarioController;
        private readonly IGrupoUsuariosController _gruposUsuariosController;

        // Constructor principal que recibe al usuario logueado
        public MenuPrincipal(Usuario usuarioLogeado)
        {
            InitializeComponent();

            // Configuración visual del ListBox de deudas
            lbDeudas.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            lbDeudas.SelectionMode = SelectionMode.One;         // Solo se puede seleccionar un item
            lbDeudas.BorderStyle = BorderStyle.FixedSingle;     // Borde simple
            lbDeudas.IntegralHeight = false;                    // Controla altura exacta
            lbDeudas.ItemHeight = 22;                           // Tamaño de cada item
            lbDeudas.BackColor = Color.FromArgb(50, 50, 50);    // Fondo oscuro
            lbDeudas.ForeColor = Color.White;                   // Texto blanco
            lbDeudas.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lbDeudas.HorizontalScrollbar = false;
            lbDeudas.HorizontalExtent = 0;
            lbDeudas.ScrollAlwaysVisible = false;

            // Colores para labels de avisos y deudas
            txtAvisoDeudas.ForeColor = Color.Orange;
            txtDeudas.ForeColor = Color.OrangeRed;

            // Inicialización de controladores
            _gastosController = new GastosController();
            _usuarioController = new UsuarioController();
            _gruposUsuariosController = new GruposUsuariosController();

            // Asignación del usuario actual
            _usuario = usuarioLogeado;

            // Carga inicial de datos en la UI
            cargarDatos();
            cargarDeudas();
        }

        // Constructor vacío (no se recomienda mucho, pero está por compatibilidad)
        public MenuPrincipal()
        {
        }

        // Método que carga las deudas del usuario en el ListBox
        private void cargarDeudas()
        {
            var deudas = _gastosController.crt_obtenerAQuieDebeUsuario(_usuario.Identificacion);

            if (deudas.Count > 0)
            {
                txtDeudas.Visible = true;
                txtAvisoDeudas.Visible = true;
                lbDeudas.Items.Clear();

                // Agregar cada deuda encontrada
                foreach (var deuda in deudas)
                {
                    lbDeudas.Items.Add(deuda);
                }
            }
            else
            {
                // Si no hay deudas, ocultar labels y limpiar lista
                txtDeudas.Visible = false;
                txtAvisoDeudas.Visible = false;
                lbDeudas.Items.Clear();
                lbDeudas.Visible = false;
            }
        }

        // Método que carga los datos básicos del usuario logueado
        private void cargarDatos()
        {
            // Mostrar nombre completo del usuario
            txtName.Text = _usuario.NombreCompleto;

            try
            {
                // Intentar cargar la imagen desde la ruta en BD
                string rutaAbsoluta = _usuarioController.ctr_ObtenerRutaImagen(_usuario.Imagen);
                pictureBox1.Image = Image.FromFile(rutaAbsoluta);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

                // Revisar si el usuario tiene invitaciones pendientes
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
                    // Si falla, cargar imagen por defecto
                    string rutaDefault = _usuarioController.ctr_ObtenerRutaImagen("imgs\\user.png");
                    pictureBox1.Image = Image.FromFile(rutaDefault);
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                catch
                {
                    // Si también falla, dejar sin imagen
                    pictureBox1.Image = null;
                }
            }
        }

        // --- EVENTOS DE BOTONES PARA CAMBIAR DE VISTAS ---

        // Registrar nuevo gasto
        private void btnRGastos_Click(object sender, EventArgs e)
        {
            FrmRGastos ventana = new FrmRGastos(_usuario);
            PanelContenido.Controls.Clear();
            ventana.Dock = DockStyle.Fill;
            PanelContenido.Controls.Add(ventana);
        }

        // Registrar nuevo grupo
        private void btnRGrupos_Click(object sender, EventArgs e)
        {
            FrmRGrupos ventana = new FrmRGrupos(_usuario);
            PanelContenido.Controls.Clear();
            ventana.Dock = DockStyle.Fill;
            PanelContenido.Controls.Add(ventana);
        }

        // Ver invitaciones
        private void btnInvitaciones_Click(object sender, EventArgs e)
        {
            FrmInvitaciones ventana = new FrmInvitaciones(_usuario);

            // Suscribirse al evento para actualizar el botón
            ventana.ActualizarBotonInvitacionesEvent += ActualizarBotonInvitaciones;

            PanelContenido.Controls.Clear();
            ventana.Dock = DockStyle.Fill;
            PanelContenido.Controls.Add(ventana);
        }

        // Método que actualiza el estilo del botón de invitaciones
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
                btnInvitaciones.BackColor = Color.FromArgb(59, 178, 113); // Verde
            }
        }

        // Información de los grupos a los que pertenece el usuario
        private void btnGrupos_Click(object sender, EventArgs e)
        {
            FrmInfoGrupos ventana = new FrmInfoGrupos(_usuario);
            PanelContenido.Controls.Clear();
            ventana.Dock = DockStyle.Fill;
            PanelContenido.Controls.Add(ventana);
        }

        // Listado de gastos
        private void btnGastos_Click(object sender, EventArgs e)
        {
            FrmListadoGastos ventana = new FrmListadoGastos(_usuario);

            // Cambio de vista a "Registrar Gasto" desde el listado
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

        // Reportes
        private void btnReportes_Click(object sender, EventArgs e)
        {
            FrmReporte ventana = new FrmReporte(_usuario);
            PanelContenido.Controls.Clear();
            ventana.Dock = DockStyle.Fill;
            PanelContenido.Controls.Add(ventana);
        }

        // Cerrar sesión y volver al login
        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            FrmLogin frmLogin = new FrmLogin();
            frmLogin.Show();
            this.Hide(); // Oculta la ventana actual
        }

        // Al cerrar el formulario, se cierra toda la aplicación
        private void MenuPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}

