using Controllers.Controladores;
using Models;
using Proyecto_1.Interfaces;
using Views.Vistas.Auth;

namespace Proyecto_1
{
    // Formulario de registro de usuario
    public partial class FrmRegistrarUsuario : Form
    {
        // Controlador para manejar operaciones relacionadas con usuarios
        private readonly IUsuarioController _usuarioController;

        // Constructor
        public FrmRegistrarUsuario()
        {
            InitializeComponent(); // Inicializa los componentes gráficos
            _usuarioController = new UsuarioController(); // Se instancia el controlador de usuarios
        }

        // Evento que se ejecuta al cargar el formulario
        private void Form1_Load(object sender, EventArgs e)
        {
            // Actualmente no hace nada
        }

        // Ruta de la imagen seleccionada (inicialmente vacía)
        private string rutaRelativaImagen = "";

        // Evento del botón para cargar imagen (button1)
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog AbrirImagen = new OpenFileDialog(); // Abre explorador de archivos

            // Si el usuario selecciona un archivo válido
            if (AbrirImagen.ShowDialog() == DialogResult.OK)
            {
                // Se muestra la imagen seleccionada en el PictureBox
                pictureBox1.ImageLocation = AbrirImagen.FileName;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

                // Se guarda la ruta de la imagen seleccionada
                rutaRelativaImagen = AbrirImagen.FileName;
            }
        }

        /*
        ⚠️ Código alternativo comentado para cargar imagen:
        Este código copia la imagen seleccionada a una carpeta fija dentro del proyecto 
        (LogicaNegocio/Almacenamiento/imgs) y evita duplicados al renombrar si es necesario.
        Guarda la ruta relativa en lugar de la ruta absoluta.
        */

        // Validación para que en el campo edad solo se permitan números
        private void txt_Edad_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Solo permite dígitos y teclas de control (ejemplo: retroceso)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Bloquea el ingreso de letras o símbolos
            }
        }

        // Evento del botón para agregar usuario
        private void btn_AgregarUsuario_Click(object sender, EventArgs e)
        {
            // Validación de campos obligatorios
            if (string.IsNullOrEmpty(txt_NombreCompleto.Text.Trim()) ||
                string.IsNullOrEmpty(txt_Corrreo.Text.Trim()) ||
                string.IsNullOrEmpty(txt_Contraseña.Text.Trim()) ||
                string.IsNullOrEmpty(txt_Id.Text.Trim()))
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios.");
                return;
            }

            // Validación de que haya imagen seleccionada
            if (string.IsNullOrEmpty(rutaRelativaImagen))
            {
                MessageBox.Show("Por favor, seleccione una imagen para el usuario.");
                return;
            }

            // Validación de identificación única
            if (_usuarioController.ctr_ValidarIdentificacionRepetida(txt_Id.Text.Trim()) == true)
            {
                MessageBox.Show("La identificación ya está registrada. Por favor, ingrese una identificación diferente.");
                return;
            }

            // Se construye el objeto Usuario con la información del formulario
            Usuario usuario = new Usuario
            {
                Identificacion = txt_Id.Text.Trim(),
                NombreCompleto = txt_NombreCompleto.Text.Trim(),
                Correo = txt_Corrreo.Text.Trim(),
                Edad = int.TryParse(txt_Edad.Text.Trim(), out int edad) ? edad : 0, // Si no es número, se pone 0
                Contrasenia = txt_Contraseña.Text.Trim(),
                Imagen = rutaRelativaImagen // Se asigna la ruta de la imagen
            };

            try
            {
                // Se agrega el usuario llamando al controlador
                _usuarioController.ctr_AgregarUsuario(usuario);

                // Mensaje de éxito
                MessageBox.Show("Usuario agregado exitosamente.");

                // Se abre la ventana de login
                FrmLogin ventana = new FrmLogin();
                ventana.Show();

                // Se oculta el formulario actual
                this.Hide();
            }
            catch (Exception ex)
            {
                // Manejo de errores en caso de excepción
                MessageBox.Show($"Error al agregar el usuario: {ex.Message}");
            }
        }

        // Evento alternativo para cargar foto (btnCargarFoto)
        private void btnCargarFoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog AbrirImagen = new OpenFileDialog();

            if (AbrirImagen.ShowDialog() == DialogResult.OK)
            {
                // Muestra la imagen seleccionada en el PictureBox
                pictureBox1.ImageLocation = AbrirImagen.FileName;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

                // Guarda la ruta seleccionada
                rutaRelativaImagen = AbrirImagen.FileName;
            }
        }
    }
}
