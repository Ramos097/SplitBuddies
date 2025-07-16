
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
            button1 = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txt_NombreCompleto = new TextBox();
            txt_Corrreo = new TextBox();
            txt_Edad = new TextBox();
            pictureBox1 = new PictureBox();
            txt_Contraseña = new TextBox();
            label4 = new Label();
            btn_AgregarUsuario = new Button();
            txt_Id = new TextBox();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(639, 195);
            button1.Name = "button1";
            button1.Size = new Size(125, 29);
            button1.TabIndex = 0;
            button1.Text = "Cargar Foto";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(21, 92);
            label1.Name = "label1";
            label1.Size = new Size(134, 20);
            label1.TabIndex = 1;
            label1.Text = "Nombre Completo";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(21, 152);
            label2.Name = "label2";
            label2.Size = new Size(54, 20);
            label2.TabIndex = 2;
            label2.Text = "Correo";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(21, 257);
            label3.Name = "label3";
            label3.Size = new Size(83, 20);
            label3.TabIndex = 3;
            label3.Text = "Contraseña";
            // 
            // txt_NombreCompleto
            // 
            txt_NombreCompleto.Location = new Point(199, 92);
            txt_NombreCompleto.Name = "txt_NombreCompleto";
            txt_NombreCompleto.Size = new Size(222, 27);
            txt_NombreCompleto.TabIndex = 4;
            // 
            // txt_Corrreo
            // 
            txt_Corrreo.Location = new Point(199, 145);
            txt_Corrreo.Name = "txt_Corrreo";
            txt_Corrreo.Size = new Size(222, 27);
            txt_Corrreo.TabIndex = 5;
            // 
            // txt_Edad
            // 
            txt_Edad.Location = new Point(199, 202);
            txt_Edad.Name = "txt_Edad";
            txt_Edad.Size = new Size(222, 27);
            txt_Edad.TabIndex = 6;
            txt_Edad.KeyPress += txt_Edad_KeyPress;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(639, 48);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(125, 119);
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            // 
            // txt_Contraseña
            // 
            txt_Contraseña.Location = new Point(199, 257);
            txt_Contraseña.Name = "txt_Contraseña";
            txt_Contraseña.Size = new Size(222, 27);
            txt_Contraseña.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(21, 209);
            label4.Name = "label4";
            label4.Size = new Size(43, 20);
            label4.TabIndex = 9;
            label4.Text = "Edad";
            // 
            // btn_AgregarUsuario
            // 
            btn_AgregarUsuario.Location = new Point(287, 343);
            btn_AgregarUsuario.Name = "btn_AgregarUsuario";
            btn_AgregarUsuario.Size = new Size(207, 29);
            btn_AgregarUsuario.TabIndex = 10;
            btn_AgregarUsuario.Text = "Agregar Usuario";
            btn_AgregarUsuario.UseVisualStyleBackColor = true;
            btn_AgregarUsuario.Click += btn_AgregarUsuario_Click;
            // 
            // txt_Id
            // 
            txt_Id.Location = new Point(199, 48);
            txt_Id.Name = "txt_Id";
            txt_Id.Size = new Size(222, 27);
            txt_Id.TabIndex = 12;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(21, 48);
            label5.Name = "label5";
            label5.Size = new Size(99, 20);
            label5.TabIndex = 11;
            label5.Text = "Identificación";
            // 
            // FrmUsuario
            // 
            AccessibleName = "Usuario";
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txt_Id);
            Controls.Add(label5);
            Controls.Add(btn_AgregarUsuario);
            Controls.Add(label4);
            Controls.Add(txt_Contraseña);
            Controls.Add(pictureBox1);
            Controls.Add(txt_Edad);
            Controls.Add(txt_Corrreo);
            Controls.Add(txt_NombreCompleto);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button1);
            Name = "FrmUsuario";
            Text = "Usuario";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }



        #endregion

        private Button button1;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txt_NombreCompleto;
        private TextBox txt_Corrreo;
        private TextBox txt_Edad;
        private PictureBox pictureBox1;
        private TextBox txt_Contraseña;
        private Label label4;
        private Button btn_AgregarUsuario;
        private TextBox txt_Id;
        private Label label5;
    }
}
