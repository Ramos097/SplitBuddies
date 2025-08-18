namespace Views.Vistas.Invitaciones
{
    partial class FrmInvitaciones
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            PanelPlantilla = new Panel();
            panel3 = new Panel();
            lbMiembros = new ListBox();
            txtlbmiembros = new Label();
            btnRechazar = new Button();
            cbGrupoInvitado = new ComboBox();
            btnAceptar = new Button();
            label5 = new Label();
            panel2 = new Panel();
            label3 = new Label();
            PanelPlantilla.SuspendLayout();
            panel3.SuspendLayout();
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
            panel3.Controls.Add(lbMiembros);
            panel3.Controls.Add(txtlbmiembros);
            panel3.Controls.Add(btnRechazar);
            panel3.Controls.Add(cbGrupoInvitado);
            panel3.Controls.Add(btnAceptar);
            panel3.Controls.Add(label5);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 47);
            panel3.Name = "panel3";
            panel3.Size = new Size(594, 346);
            panel3.TabIndex = 2;
            // 
            // lbMiembros
            // 
            lbMiembros.FormattingEnabled = true;
            lbMiembros.Location = new Point(207, 80);
            lbMiembros.Name = "lbMiembros";
            lbMiembros.Size = new Size(254, 124);
            lbMiembros.TabIndex = 20;
            // 
            // txtlbmiembros
            // 
            txtlbmiembros.AutoSize = true;
            txtlbmiembros.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            txtlbmiembros.ForeColor = Color.White;
            txtlbmiembros.Location = new Point(28, 80);
            txtlbmiembros.Name = "txtlbmiembros";
            txtlbmiembros.Size = new Size(153, 20);
            txtlbmiembros.TabIndex = 19;
            txtlbmiembros.Text = "Miembros del Grupo";
            // 
            // btnRechazar
            // 
            btnRechazar.BackColor = Color.IndianRed;
            btnRechazar.FlatAppearance.BorderSize = 0;
            btnRechazar.FlatStyle = FlatStyle.Flat;
            btnRechazar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnRechazar.Location = new Point(163, 254);
            btnRechazar.Margin = new Padding(3, 2, 3, 2);
            btnRechazar.Name = "btnRechazar";
            btnRechazar.Size = new Size(110, 37);
            btnRechazar.TabIndex = 18;
            btnRechazar.Text = "Rechazar";
            btnRechazar.UseVisualStyleBackColor = false;
            btnRechazar.Click += btnRechazar_Click;
            // 
            // cbGrupoInvitado
            // 
            cbGrupoInvitado.DropDownStyle = ComboBoxStyle.DropDownList;
            cbGrupoInvitado.FormattingEnabled = true;
            cbGrupoInvitado.Location = new Point(207, 35);
            cbGrupoInvitado.Name = "cbGrupoInvitado";
            cbGrupoInvitado.Size = new Size(254, 23);
            cbGrupoInvitado.TabIndex = 17;
            cbGrupoInvitado.SelectedIndexChanged += cbGrupoInvitado_SelectedIndexChanged;
            // 
            // btnAceptar
            // 
            btnAceptar.BackColor = Color.LightGreen;
            btnAceptar.FlatAppearance.BorderSize = 0;
            btnAceptar.FlatStyle = FlatStyle.Flat;
            btnAceptar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnAceptar.Location = new Point(314, 254);
            btnAceptar.Margin = new Padding(3, 2, 3, 2);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(110, 37);
            btnAceptar.TabIndex = 16;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = false;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label5.ForeColor = Color.White;
            label5.Location = new Point(101, 35);
            label5.Name = "label5";
            label5.Size = new Size(57, 20);
            label5.TabIndex = 9;
            label5.Text = "Grupo ";
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
            label3.Location = new Point(170, 7);
            label3.Name = "label3";
            label3.Size = new Size(255, 28);
            label3.TabIndex = 5;
            label3.Text = "INVITACIONES DE GRUPO";
            // 
            // FrmInvitaciones
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(PanelPlantilla);
            Name = "FrmInvitaciones";
            Size = new Size(594, 393);
            PanelPlantilla.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel PanelPlantilla;
        private Panel panel3;
        private Button btnAceptar;
        private Label label5;
        private Panel panel2;
        private Label label3;
        private ComboBox cbGrupoInvitado;
        private Button btnRechazar;
        private Label txtlbmiembros;
        private ListBox lbMiembros;
    }
}
