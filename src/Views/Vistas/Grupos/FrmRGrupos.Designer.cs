namespace Views.Vistas.Grupos
{
    partial class FrmRGrupos
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            PanelPlantilla = new Panel();
            panel3 = new Panel();
            btnSeleccionarImagen = new Button();
            clbMiembros = new CheckedListBox();
            pbImagenGrupo = new PictureBox();
            btnCrearGrupo = new Button();
            lblImagen = new Label();
            lblMiembros = new Label();
            lblNombreGrupo = new Label();
            txtNombreGrupo = new TextBox();
            panel2 = new Panel();
            label3 = new Label();
            PanelPlantilla.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbImagenGrupo).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // PanelPlantilla
            // 
            PanelPlantilla.BackColor = Color.FromArgb(50, 50, 50);
            PanelPlantilla.Controls.Add(panel3);
            PanelPlantilla.Controls.Add(panel2);
            PanelPlantilla.Dock = DockStyle.Fill;
            PanelPlantilla.Location = new Point(0, 0);
            PanelPlantilla.Name = "PanelPlantilla";
            PanelPlantilla.Size = new Size(594, 393);
            PanelPlantilla.TabIndex = 2;
            // 
            // panel3
            // 
            panel3.Controls.Add(btnSeleccionarImagen);
            panel3.Controls.Add(clbMiembros);
            panel3.Controls.Add(pbImagenGrupo);
            panel3.Controls.Add(btnCrearGrupo);
            panel3.Controls.Add(lblImagen);
            panel3.Controls.Add(lblMiembros);
            panel3.Controls.Add(lblNombreGrupo);
            panel3.Controls.Add(txtNombreGrupo);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 47);
            panel3.Name = "panel3";
            panel3.Size = new Size(594, 346);
            panel3.TabIndex = 2;
            // 
            // btnSeleccionarImagen
            // 
            btnSeleccionarImagen.Location = new Point(365, 80);
            btnSeleccionarImagen.Name = "btnSeleccionarImagen";
            btnSeleccionarImagen.Size = new Size(75, 23);
            btnSeleccionarImagen.TabIndex = 19;
            btnSeleccionarImagen.Text = "Seleccionar";
            btnSeleccionarImagen.UseVisualStyleBackColor = true;
            btnSeleccionarImagen.Click += btnSeleccionarImagen_Click_1;
            // 
            // clbMiembros
            // 
            clbMiembros.FormattingEnabled = true;
            clbMiembros.Location = new Point(218, 135);
            clbMiembros.Name = "clbMiembros";
            clbMiembros.Size = new Size(222, 58);
            clbMiembros.TabIndex = 18;
            // 
            // pbImagenGrupo
            // 
            pbImagenGrupo.Location = new Point(218, 80);
            pbImagenGrupo.Name = "pbImagenGrupo";
            pbImagenGrupo.Size = new Size(131, 21);
            pbImagenGrupo.TabIndex = 17;
            pbImagenGrupo.TabStop = false;
            // 
            // btnCrearGrupo
            // 
            btnCrearGrupo.BackColor = Color.LightGreen;
            btnCrearGrupo.FlatAppearance.BorderSize = 0;
            btnCrearGrupo.FlatStyle = FlatStyle.Flat;
            btnCrearGrupo.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnCrearGrupo.Location = new Point(218, 285);
            btnCrearGrupo.Margin = new Padding(3, 2, 3, 2);
            btnCrearGrupo.Name = "btnCrearGrupo";
            btnCrearGrupo.Size = new Size(110, 37);
            btnCrearGrupo.TabIndex = 16;
            btnCrearGrupo.Text = "Crear";
            btnCrearGrupo.UseVisualStyleBackColor = false;
            // 
            // lblImagen
            // 
            lblImagen.AutoSize = true;
            lblImagen.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblImagen.ForeColor = Color.White;
            lblImagen.Location = new Point(43, 80);
            lblImagen.Name = "lblImagen";
            lblImagen.Size = new Size(139, 20);
            lblImagen.TabIndex = 11;
            lblImagen.Text = "Imagen del Grupo:";
            // 
            // lblMiembros
            // 
            lblMiembros.AutoSize = true;
            lblMiembros.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblMiembros.ForeColor = Color.White;
            lblMiembros.Location = new Point(39, 135);
            lblMiembros.Name = "lblMiembros";
            lblMiembros.Size = new Size(159, 20);
            lblMiembros.TabIndex = 10;
            lblMiembros.Text = "Seleccionar Miembro:";
            // 
            // lblNombreGrupo
            // 
            lblNombreGrupo.AutoSize = true;
            lblNombreGrupo.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblNombreGrupo.ForeColor = Color.White;
            lblNombreGrupo.Location = new Point(43, 38);
            lblNombreGrupo.Name = "lblNombreGrupo";
            lblNombreGrupo.Size = new Size(151, 20);
            lblNombreGrupo.TabIndex = 9;
            lblNombreGrupo.Text = "Nombres del Grupo:";
            // 
            // txtNombreGrupo
            // 
            txtNombreGrupo.Font = new Font("Segoe UI", 11F);
            txtNombreGrupo.Location = new Point(218, 39);
            txtNombreGrupo.Margin = new Padding(3, 2, 3, 2);
            txtNombreGrupo.Name = "txtNombreGrupo";
            txtNombreGrupo.Size = new Size(190, 27);
            txtNombreGrupo.TabIndex = 8;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(50, 150, 50);
            panel2.Controls.Add(label3);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(594, 47);
            panel2.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label3.ForeColor = Color.White;
            label3.Location = new Point(212, 10);
            label3.Name = "label3";
            label3.Size = new Size(116, 28);
            label3.TabIndex = 5;
            label3.Text = "PLANTILLA";
            // 
            // FrmRGrupos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(PanelPlantilla);
            Name = "FrmRGrupos";
            Size = new Size(594, 393);
            PanelPlantilla.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbImagenGrupo).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel PanelPlantilla;
        private Panel panel3;
        private Button btnCrearGrupo;
        private Label lblImagen;
        private Label lblMiembros;
        private Label lblNombreGrupo;
        private TextBox txtNombreGrupo;
        private Panel panel2;
        private Label label3;
        private PictureBox pbImagenGrupo;
        private CheckedListBox clbMiembros;
        private Button btnSeleccionarImagen;
    }
}
