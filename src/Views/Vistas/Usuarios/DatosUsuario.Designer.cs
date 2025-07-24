namespace Views.Vistas.Usuarios
{
    partial class DatosUsuario
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txt_Id = new TextBox();
            label5 = new Label();
            label4 = new Label();
            txt_Contraseña = new TextBox();
            pictureBox1 = new PictureBox();
            txt_Edad = new TextBox();
            txt_Corrreo = new TextBox();
            txt_NombreCompleto = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            btnIrACrearGrupo = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // txt_Id
            // 
            txt_Id.Location = new Point(184, 59);
            txt_Id.Margin = new Padding(3, 2, 3, 2);
            txt_Id.Name = "txt_Id";
            txt_Id.ReadOnly = true;
            txt_Id.Size = new Size(195, 23);
            txt_Id.TabIndex = 23;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(28, 59);
            label5.Name = "label5";
            label5.Size = new Size(79, 15);
            label5.TabIndex = 22;
            label5.Text = "Identificación";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(28, 180);
            label4.Name = "label4";
            label4.Size = new Size(33, 15);
            label4.TabIndex = 21;
            label4.Text = "Edad";
            // 
            // txt_Contraseña
            // 
            txt_Contraseña.Location = new Point(184, 216);
            txt_Contraseña.Margin = new Padding(3, 2, 3, 2);
            txt_Contraseña.Name = "txt_Contraseña";
            txt_Contraseña.ReadOnly = true;
            txt_Contraseña.Size = new Size(195, 23);
            txt_Contraseña.TabIndex = 20;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(569, 59);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(109, 89);
            pictureBox1.TabIndex = 19;
            pictureBox1.TabStop = false;
            // 
            // txt_Edad
            // 
            txt_Edad.Location = new Point(184, 175);
            txt_Edad.Margin = new Padding(3, 2, 3, 2);
            txt_Edad.Name = "txt_Edad";
            txt_Edad.ReadOnly = true;
            txt_Edad.Size = new Size(195, 23);
            txt_Edad.TabIndex = 18;
            // 
            // txt_Corrreo
            // 
            txt_Corrreo.Location = new Point(184, 132);
            txt_Corrreo.Margin = new Padding(3, 2, 3, 2);
            txt_Corrreo.Name = "txt_Corrreo";
            txt_Corrreo.ReadOnly = true;
            txt_Corrreo.Size = new Size(195, 23);
            txt_Corrreo.TabIndex = 17;
            // 
            // txt_NombreCompleto
            // 
            txt_NombreCompleto.Location = new Point(184, 92);
            txt_NombreCompleto.Margin = new Padding(3, 2, 3, 2);
            txt_NombreCompleto.Name = "txt_NombreCompleto";
            txt_NombreCompleto.ReadOnly = true;
            txt_NombreCompleto.Size = new Size(195, 23);
            txt_NombreCompleto.TabIndex = 16;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(28, 216);
            label3.Name = "label3";
            label3.Size = new Size(67, 15);
            label3.TabIndex = 15;
            label3.Text = "Contraseña";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(28, 137);
            label2.Name = "label2";
            label2.Size = new Size(43, 15);
            label2.TabIndex = 14;
            label2.Text = "Correo";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(28, 92);
            label1.Name = "label1";
            label1.Size = new Size(107, 15);
            label1.TabIndex = 13;
            label1.Text = "Nombre Completo";
            // 
            // btnIrACrearGrupo
            // 
            btnIrACrearGrupo.Location = new Point(12, 270);
            btnIrACrearGrupo.Name = "btnIrACrearGrupo";
            btnIrACrearGrupo.Size = new Size(95, 23);
            btnIrACrearGrupo.TabIndex = 24;
            btnIrACrearGrupo.Text = "Crear Grupo";
            btnIrACrearGrupo.UseVisualStyleBackColor = true;
            btnIrACrearGrupo.Click += btnIrACrearGrupo_Click;
            // 
            // DatosUsuario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(btnIrACrearGrupo);
            Controls.Add(txt_Id);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(txt_Contraseña);
            Controls.Add(pictureBox1);
            Controls.Add(txt_Edad);
            Controls.Add(txt_Corrreo);
            Controls.Add(txt_NombreCompleto);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "DatosUsuario";
            Text = "DatosUsuario";
            Load += DatosUsuario_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txt_Id;
        private Label label5;
        private Label label4;
        private TextBox txt_Contraseña;
        private PictureBox pictureBox1;
        private TextBox txt_Edad;
        private TextBox txt_Corrreo;
        private TextBox txt_NombreCompleto;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button btnIrACrearGrupo;
    }
}