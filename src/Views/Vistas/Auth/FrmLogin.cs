using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models;
using Proyecto_1;
using Proyecto_1.Controllers;
using Proyecto_1.Interfaces;
using Views.Vistas.Usuarios;

namespace Views.Vistas.Auth
{
    public partial class FrmLogin : Form
    {
        private readonly IUsuarioController _usuarioController;
        private readonly IServiceProvider _provider;
        public FrmLogin()
        {
            InitializeComponent();
            _usuarioController = new UsuarioController(); // Aquí deberías inyectar el controlador de usuario

        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtId.Text) || string.IsNullOrWhiteSpace(txtPass.Text))
                {
                    MessageBox.Show("Por favor, complete todos los campos.");
                    return;
                }


                try
                {
                    Usuario usuario = _usuarioController.ValidarAutenticacion(txtId.Text.Trim(), txtPass.Text.Trim());
                    MessageBox.Show("Inicio de sesión exitoso.");
                    DatosUsuario ventana = new DatosUsuario(usuario);
                    ventana.Show();
                    this.Hide();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }



                // Aquí podrías redirigir al usuario a la siguiente pantalla o realizar alguna acción adicional


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            FrmRegistrarUsuario ventana = new FrmRegistrarUsuario();
            ventana.Show();
            this.Hide();
        }
    }
}
