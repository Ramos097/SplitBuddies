namespace Views.Vistas.Grupos
{
    partial class FormcrearGrupo
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
            lblNombreGrupo = new Label();
            txtNombreGrupo = new TextBox();
            lblImagen = new Label();
            pbImagenGrupo = new PictureBox();
            btnSeleccionarImagen = new Button();
            lblMiembros = new Label();
            clbMiembros = new CheckedListBox();
            btnCrearGrupo = new Button();
            ((System.ComponentModel.ISupportInitialize)pbImagenGrupo).BeginInit();
            SuspendLayout();
            // 
            // lblNombreGrupo
            // 
            lblNombreGrupo.AutoSize = true;
            lblNombreGrupo.Location = new Point(3, 9);
            lblNombreGrupo.Name = "lblNombreGrupo";
            lblNombreGrupo.Size = new Size(108, 15);
            lblNombreGrupo.TabIndex = 0;
            lblNombreGrupo.Text = "Nombre del grupo:";
            // 
            // txtNombreGrupo
            // 
            txtNombreGrupo.Location = new Point(128, 9);
            txtNombreGrupo.Name = "txtNombreGrupo";
            txtNombreGrupo.Size = new Size(100, 23);
            txtNombreGrupo.TabIndex = 1;
            txtNombreGrupo.TextChanged += txtNombreGrupo_TextChanged;
            // 
            // lblImagen
            // 
            lblImagen.AutoSize = true;
            lblImagen.Location = new Point(3, 44);
            lblImagen.Name = "lblImagen";
            lblImagen.Size = new Size(104, 15);
            lblImagen.TabIndex = 2;
            lblImagen.Text = "Imagen del grupo:";
            // 
            // pbImagenGrupo
            // 
            pbImagenGrupo.Location = new Point(176, 44);
            pbImagenGrupo.Name = "pbImagenGrupo";
            pbImagenGrupo.Size = new Size(131, 21);
            pbImagenGrupo.TabIndex = 3;
            pbImagenGrupo.TabStop = false;
            pbImagenGrupo.Click += pbImagenGrupo_Click;
            // 
            // btnSeleccionarImagen
            // 
            btnSeleccionarImagen.Location = new Point(176, 71);
            btnSeleccionarImagen.Name = "btnSeleccionarImagen";
            btnSeleccionarImagen.Size = new Size(75, 23);
            btnSeleccionarImagen.TabIndex = 4;
            btnSeleccionarImagen.Text = "Seleccionar";
            btnSeleccionarImagen.UseVisualStyleBackColor = true;
            // 
            // lblMiembros
            // 
            lblMiembros.AutoSize = true;
            lblMiembros.Location = new Point(3, 82);
            lblMiembros.Name = "lblMiembros";
            lblMiembros.Size = new Size(127, 15);
            lblMiembros.TabIndex = 5;
            lblMiembros.Text = "Seleccionar miembros:";
            // 
            // clbMiembros
            // 
            clbMiembros.FormattingEnabled = true;
            clbMiembros.Location = new Point(3, 100);
            clbMiembros.Name = "clbMiembros";
            clbMiembros.Size = new Size(120, 58);
            clbMiembros.TabIndex = 6;
            // 
            // btnCrearGrupo
            // 
            btnCrearGrupo.Location = new Point(3, 199);
            btnCrearGrupo.Name = "btnCrearGrupo";
            btnCrearGrupo.Size = new Size(89, 23);
            btnCrearGrupo.TabIndex = 7;
            btnCrearGrupo.Text = "Crear grupo";
            btnCrearGrupo.UseVisualStyleBackColor = true;
            btnCrearGrupo.Click += btnCrearGrupo_Click;
            // 
            // FormcrearGrupo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(649, 250);
            Controls.Add(btnCrearGrupo);
            Controls.Add(clbMiembros);
            Controls.Add(lblMiembros);
            Controls.Add(btnSeleccionarImagen);
            Controls.Add(pbImagenGrupo);
            Controls.Add(lblImagen);
            Controls.Add(txtNombreGrupo);
            Controls.Add(lblNombreGrupo);
            Name = "FormcrearGrupo";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pbImagenGrupo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNombreGrupo;
        private TextBox txtNombreGrupo;
        private Label lblImagen;
        private PictureBox pbImagenGrupo;
        private Button btnSeleccionarImagen;
        private Label lblMiembros;
        private CheckedListBox clbMiembros;
        private Button btnCrearGrupo;
    }
}