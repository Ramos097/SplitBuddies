namespace Proyecto_1
{
    public partial class Usuario : Form
    {
        public Usuario()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog AbrirImagen = new OpenFileDialog();

            //Abre el explorador de archivos

            if (AbrirImagen.ShowDialog() == DialogResult.OK)
            {
                //Si el usuario selecciona un archivo, lo muestra en el PictureBox
                pictureBox1.ImageLocation = AbrirImagen.FileName;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
