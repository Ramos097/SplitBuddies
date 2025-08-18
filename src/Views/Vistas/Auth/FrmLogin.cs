using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controllers.Controladores;
using Models;
using Proyecto_1;
using Proyecto_1.Interfaces;
using Views.Vistas.Menus;


namespace Views.Vistas.Auth
{
    public partial class FrmLogin : Form
    {
        // Controlador para manejar la lógica de usuario
        private readonly IUsuarioController _usuarioController;

        // Proveedor de servicios (puede usarse para inyección de dependencias si se requiere)
        private readonly IServiceProvider _provider;

        // Constructor del formulario
        public FrmLogin()
        {
            InitializeComponent(); // Inicializa los componentes del formulario

            // Se crea una instancia directa del controlador de usuario
            _usuarioController = new UsuarioController(); // Aquí deberías inyectar el controlador de usuario si usas un contenedor
        }

        // Evento que se ejecuta cuando el formulario termina de cargar
        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }

        // Evento del botón "Login"
        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                // Verifica que los campos de texto no estén vacíos
                if (string.IsNullOrWhiteSpace(txtId.Text) || string.IsNullOrWhiteSpace(txtPass.Text))
                {
                    MessageBox.Show("Por favor, complete todos los campos.");
                    return; // Sale del método si faltan datos
                }

                try
                {
                    // Valida la autenticación del usuario con el controlador
                    Usuario usuario = _usuarioController.ctr_ValidarAutenticacion(
                        txtId.Text.Trim(),  // Se elimina espacio extra del ID
                        txtPass.Text.Trim() // Se elimina espacio extra de la contraseña
                    );

                    // Si la validación es correcta, abre la ventana principal
                    MenuPrincipal ventana = new MenuPrincipal(usuario);
                    ventana.Show();

                    // Oculta el formulario actual de login
                    this.Hide();
                }
                catch (Exception ex)
                {
                    // Muestra el error en caso de fallo en la autenticación
                    MessageBox.Show(ex.Message);
                }

                // Aquí podrías redirigir al usuario a otra pantalla o hacer lógica adicional
            }
            catch (Exception ex)
            {
                // Captura errores generales y los muestra
                MessageBox.Show(ex.Message);
            }
        }

        // Evento del botón "Registrar"
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            // Abre el formulario de registro de usuario
            FrmRegistrarUsuario ventana = new FrmRegistrarUsuario();
            ventana.Show();

            // Oculta el formulario de login actual
            this.Hide();
        }
    }
}

