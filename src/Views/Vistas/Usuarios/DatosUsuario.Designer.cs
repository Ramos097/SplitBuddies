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
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // txt_Id
            // 
            txt_Id.Location = new Point(210, 79);
            txt_Id.Name = "txt_Id";
            txt_Id.ReadOnly = true;
            txt_Id.Size = new Size(222, 27);
            txt_Id.TabIndex = 23;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(32, 79);
            label5.Name = "label5";
            label5.Size = new Size(99, 20);
            label5.TabIndex = 22;
            label5.Text = "Identificación";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(32, 240);
            label4.Name = "label4";
            label4.Size = new Size(43, 20);
            label4.TabIndex = 21;
            label4.Text = "Edad";
            // 
            // txt_Contraseña
            // 
            txt_Contraseña.Location = new Point(210, 288);
            txt_Contraseña.Name = "txt_Contraseña";
            txt_Contraseña.ReadOnly = true;
            txt_Contraseña.Size = new Size(222, 27);
            txt_Contraseña.TabIndex = 20;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(650, 79);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(125, 119);
            pictureBox1.TabIndex = 19;
            pictureBox1.TabStop = false;
            // 
            // txt_Edad
            // 
            txt_Edad.Location = new Point(210, 233);
            txt_Edad.Name = "txt_Edad";
            txt_Edad.ReadOnly = true;
            txt_Edad.Size = new Size(222, 27);
            txt_Edad.TabIndex = 18;
            // 
            // txt_Corrreo
            // 
            txt_Corrreo.Location = new Point(210, 176);
            txt_Corrreo.Name = "txt_Corrreo";
            txt_Corrreo.ReadOnly = true;
            txt_Corrreo.Size = new Size(222, 27);
            txt_Corrreo.TabIndex = 17;
            // 
            // txt_NombreCompleto
            // 
            txt_NombreCompleto.Location = new Point(210, 123);
            txt_NombreCompleto.Name = "txt_NombreCompleto";
            txt_NombreCompleto.ReadOnly = true;
            txt_NombreCompleto.Size = new Size(222, 27);
            txt_NombreCompleto.TabIndex = 16;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(32, 288);
            label3.Name = "label3";
            label3.Size = new Size(83, 20);
            label3.TabIndex = 15;
            label3.Text = "Contraseña";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(32, 183);
            label2.Name = "label2";
            label2.Size = new Size(54, 20);
            label2.TabIndex = 14;
            label2.Text = "Correo";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(32, 123);
            label1.Name = "label1";
            label1.Size = new Size(134, 20);
            label1.TabIndex = 13;
            label1.Text = "Nombre Completo";
            // 
            // DatosUsuario
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
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
    }
}