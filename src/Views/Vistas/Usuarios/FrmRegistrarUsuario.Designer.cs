
namespace Proyecto_1
{
    partial class FrmRegistrarUsuario
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnCargarFoto = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txt_NombreCompleto = new TextBox();
            txt_Corrreo = new TextBox();
            txt_Edad = new TextBox();
            pictureBox1 = new PictureBox();
            txt_Contraseña = new TextBox();
            label4 = new Label();
            txt_Id = new TextBox();
            label5 = new Label();
            PanelPlantilla = new Panel();
            panel3 = new Panel();
            btn_AgregarUsuario = new Button();
            panel2 = new Panel();
            label10 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            PanelPlantilla.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // btnCargarFoto
            // 
            btnCargarFoto.BackColor = Color.FromArgb(255, 255, 192);
            btnCargarFoto.FlatAppearance.BorderSize = 0;
            btnCargarFoto.FlatStyle = FlatStyle.Flat;
            btnCargarFoto.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCargarFoto.Location = new Point(460, 125);
            btnCargarFoto.Margin = new Padding(3, 2, 3, 2);
            btnCargarFoto.Name = "btnCargarFoto";
            btnCargarFoto.Size = new Size(109, 36);
            btnCargarFoto.TabIndex = 0;
            btnCargarFoto.Text = "Cargar Foto";
            btnCargarFoto.UseVisualStyleBackColor = false;
            btnCargarFoto.Click += btnCargarFoto_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(34, 62);
            label1.Name = "label1";
            label1.Size = new Size(139, 20);
            label1.TabIndex = 1;
            label1.Text = "Nombre Completo";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label2.ForeColor = Color.White;
            label2.Location = new Point(34, 107);
            label2.Name = "label2";
            label2.Size = new Size(56, 20);
            label2.TabIndex = 2;
            label2.Text = "Correo";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label3.ForeColor = Color.White;
            label3.Location = new Point(34, 186);
            label3.Name = "label3";
            label3.Size = new Size(88, 20);
            label3.TabIndex = 3;
            label3.Text = "Contraseña";
            // 
            // txt_NombreCompleto
            // 
            txt_NombreCompleto.Font = new Font("Segoe UI", 11F);
            txt_NombreCompleto.Location = new Point(190, 62);
            txt_NombreCompleto.Margin = new Padding(3, 2, 3, 2);
            txt_NombreCompleto.Name = "txt_NombreCompleto";
            txt_NombreCompleto.Size = new Size(195, 27);
            txt_NombreCompleto.TabIndex = 4;
            // 
            // txt_Corrreo
            // 
            txt_Corrreo.Font = new Font("Segoe UI", 11F);
            txt_Corrreo.Location = new Point(190, 102);
            txt_Corrreo.Margin = new Padding(3, 2, 3, 2);
            txt_Corrreo.Name = "txt_Corrreo";
            txt_Corrreo.Size = new Size(195, 27);
            txt_Corrreo.TabIndex = 5;
            // 
            // txt_Edad
            // 
            txt_Edad.Font = new Font("Segoe UI", 11F);
            txt_Edad.Location = new Point(190, 145);
            txt_Edad.Margin = new Padding(3, 2, 3, 2);
            txt_Edad.Name = "txt_Edad";
            txt_Edad.Size = new Size(195, 27);
            txt_Edad.TabIndex = 6;
            txt_Edad.KeyPress += txt_Edad_KeyPress;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(460, 20);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(109, 89);
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            // 
            // txt_Contraseña
            // 
            txt_Contraseña.Font = new Font("Segoe UI", 11F);
            txt_Contraseña.Location = new Point(190, 186);
            txt_Contraseña.Margin = new Padding(3, 2, 3, 2);
            txt_Contraseña.Name = "txt_Contraseña";
            txt_Contraseña.Size = new Size(195, 27);
            txt_Contraseña.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label4.ForeColor = Color.White;
            label4.Location = new Point(34, 150);
            label4.Name = "label4";
            label4.Size = new Size(43, 20);
            label4.TabIndex = 9;
            label4.Text = "Edad";
            // 
            // txt_Id
            // 
            txt_Id.Font = new Font("Segoe UI", 11F);
            txt_Id.Location = new Point(190, 20);
            txt_Id.Margin = new Padding(3, 2, 3, 2);
            txt_Id.Name = "txt_Id";
            txt_Id.Size = new Size(195, 27);
            txt_Id.TabIndex = 12;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label5.ForeColor = Color.White;
            label5.Location = new Point(34, 20);
            label5.Name = "label5";
            label5.Size = new Size(104, 20);
            label5.TabIndex = 11;
            label5.Text = "Identificación";
            // 
            // PanelPlantilla
            // 
            PanelPlantilla.BackColor = Color.FromArgb(50, 50, 50);
            PanelPlantilla.Controls.Add(panel3);
            PanelPlantilla.Controls.Add(panel2);
            PanelPlantilla.Dock = DockStyle.Fill;
            PanelPlantilla.Location = new Point(0, 0);
            PanelPlantilla.Name = "PanelPlantilla";
            PanelPlantilla.Size = new Size(617, 343);
            PanelPlantilla.TabIndex = 13;
            // 
            // panel3
            // 
            panel3.Controls.Add(btn_AgregarUsuario);
            panel3.Controls.Add(btnCargarFoto);
            panel3.Controls.Add(txt_Id);
            panel3.Controls.Add(pictureBox1);
            panel3.Controls.Add(label5);
            panel3.Controls.Add(label1);
            panel3.Controls.Add(label2);
            panel3.Controls.Add(label4);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(txt_Contraseña);
            panel3.Controls.Add(txt_NombreCompleto);
            panel3.Controls.Add(txt_Corrreo);
            panel3.Controls.Add(txt_Edad);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 47);
            panel3.Name = "panel3";
            panel3.Size = new Size(617, 296);
            panel3.TabIndex = 2;
            // 
            // btn_AgregarUsuario
            // 
            btn_AgregarUsuario.BackColor = Color.LightGreen;
            btn_AgregarUsuario.FlatAppearance.BorderSize = 0;
            btn_AgregarUsuario.FlatStyle = FlatStyle.Flat;
            btn_AgregarUsuario.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btn_AgregarUsuario.Location = new Point(190, 230);
            btn_AgregarUsuario.Margin = new Padding(3, 2, 3, 2);
            btn_AgregarUsuario.Name = "btn_AgregarUsuario";
            btn_AgregarUsuario.Size = new Size(167, 37);
            btn_AgregarUsuario.TabIndex = 16;
            btn_AgregarUsuario.Text = "Registrar Usuario";
            btn_AgregarUsuario.UseVisualStyleBackColor = false;
            btn_AgregarUsuario.Click += btn_AgregarUsuario_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(50, 150, 50);
            panel2.Controls.Add(label10);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(617, 47);
            panel2.TabIndex = 1;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label10.ForeColor = Color.White;
            label10.Location = new Point(190, 9);
            label10.Name = "label10";
            label10.Size = new Size(243, 28);
            label10.TabIndex = 5;
            label10.Text = "REGISTRO DE USUARIOS";
            // 
            // FrmRegistrarUsuario
            // 
            AccessibleName = "Usuario";
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(617, 343);
            Controls.Add(PanelPlantilla);
            Margin = new Padding(3, 2, 3, 2);
            Name = "FrmRegistrarUsuario";
            Text = "Usuario";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            PanelPlantilla.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }



        #endregion

        private Button btnCargarFoto;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txt_NombreCompleto;
        private TextBox txt_Corrreo;
        private TextBox txt_Edad;
        private PictureBox pictureBox1;
        private TextBox txt_Contraseña;
        private Label label4;
        private TextBox txt_Id;
        private Label label5;
        private Panel PanelPlantilla;
        private Panel panel3;
        private Button btn_AgregarUsuario;
        private Panel panel2;
        private Label label10;
    }
}
