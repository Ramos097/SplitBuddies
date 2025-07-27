using Models;
using Proyecto_1.Controllers;
using Proyecto_1.Interfaces;
using Views.Vistas.Auth;

namespace Proyecto_1
{
    public partial class FrmRegistrarUsuario : Form
    {
        private readonly IUsuarioController _usuarioController;

        public FrmRegistrarUsuario()
        {

            InitializeComponent();
            _usuarioController = new UsuarioController();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private string rutaRelativaImagen = "";
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog AbrirImagen = new OpenFileDialog();

            //Abre el explorador de archivos

            if (AbrirImagen.ShowDialog() == DialogResult.OK)
            {
                //Si el usuario selecciona un archivo, lo muestra en el PictureBox
                pictureBox1.ImageLocation = AbrirImagen.FileName;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                rutaRelativaImagen = AbrirImagen.FileName;

            }
        }
        //private void button1_Click(object sender, EventArgs e)
        //{
        //    OpenFileDialog AbrirImagen = new OpenFileDialog();
        //    AbrirImagen.Filter = "Archivos de imagen (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";

        //    if (AbrirImagen.ShowDialog() == DialogResult.OK)
        //    {
        //        // Mostrar imagen en PictureBox
        //        pictureBox1.ImageLocation = AbrirImagen.FileName;
        //        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

        //        // Ruta original
        //        string imagenOriginal = AbrirImagen.FileName;

        //        // Obtener ruta base del proyecto (sube desde bin/Debug)
        //        string? basePath = AppContext.BaseDirectory;
        //        string? rutaProyecto = Directory.GetParent(basePath)?.Parent?.Parent?.Parent?.Parent?.FullName;

        //        // Ruta destino final
        //        string carpetaDestino = Path.Combine(rutaProyecto!, "LogicaNegocio", "Almacenamiento", "imgs");

        //        // Crear carpeta si no existe
        //        if (!Directory.Exists(carpetaDestino))
        //            Directory.CreateDirectory(carpetaDestino);

        //        // Nombre del archivo
        //        string nombreArchivo = Path.GetFileName(imagenOriginal);
        //        string destinoFinal = Path.Combine(carpetaDestino, nombreArchivo);

        //        // Evitar duplicados
        //        if (File.Exists(destinoFinal))
        //        {
        //            string ext = Path.GetExtension(nombreArchivo);
        //            string nombreSinExt = Path.GetFileNameWithoutExtension(nombreArchivo);
        //            nombreArchivo = $"{nombreSinExt}_{DateTime.Now.Ticks}{ext}";
        //            destinoFinal = Path.Combine(carpetaDestino, nombreArchivo);
        //        }

        //        // Copiar imagen
        //        File.Copy(imagenOriginal, destinoFinal);

        //        // Guardar ruta relativa
        //        rutaRelativaImagen = Path.Combine("imgs", nombreArchivo);

        //    }
        //}






        private void txt_Edad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Evita que se ingresen caracteres no numéricos
            }
        }

        private void btn_AgregarUsuario_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_NombreCompleto.Text.Trim()) ||
                string.IsNullOrEmpty(txt_Corrreo.Text.Trim()) ||
                string.IsNullOrEmpty(txt_Contraseña.Text.Trim()) ||
                string.IsNullOrEmpty(txt_Id.Text.Trim()))
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios.");
                return;
            }

            if (string.IsNullOrEmpty(rutaRelativaImagen))
            {
                MessageBox.Show("Por favor, seleccione una imagen para el usuario.");
                return;
            }

            if (_usuarioController.ValidarIdentificacionRepetida(txt_Id.Text.Trim()) == true)
            {
                MessageBox.Show("La identificación ya está registrada. Por favor, ingrese una identificación diferente.");
                return;
            }


            Usuario usuario = new Usuario
            {
                Identificacion = txt_Id.Text.Trim(),
                NombreCompleto = txt_NombreCompleto.Text.Trim(),
                Correo = txt_Corrreo.Text.Trim(),
                Edad = int.TryParse(txt_Edad.Text.Trim(), out int edad) ? edad : 0,
                Contrasenia = txt_Contraseña.Text.Trim(),
                Imagen = rutaRelativaImagen // La imagen se asignará después de copiarla

            };



            try
            {
                _usuarioController.AgregarUsuario(usuario);
                MessageBox.Show("Usuario agregado exitosamente.");
                FrmLogin ventana = new FrmLogin();
                ventana.Show();
                this.Hide(); // Cierra el formulario actual

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar el usuario: {ex.Message}");
            }
        }

        private void btnCargarFoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog AbrirImagen = new OpenFileDialog();

            //Abre el explorador de archivos

            if (AbrirImagen.ShowDialog() == DialogResult.OK)
            {
                //Si el usuario selecciona un archivo, lo muestra en el PictureBox
                pictureBox1.ImageLocation = AbrirImagen.FileName;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                rutaRelativaImagen = AbrirImagen.FileName;

            }
        }
    }
}
